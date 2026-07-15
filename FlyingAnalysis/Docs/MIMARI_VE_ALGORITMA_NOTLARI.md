# RaSAT SIM & FlyingAnalysis — Mimari ve Algoritma Notları

Bu doküman, yazılımın genel mimari yapısını, UI kararlarını ve kritik algoritmalarını (Sızdıran Kova, Kademeli PID, Doğrusal Alan Geçişi, APAM Acil Paraşütü, Teorik Limit Hız & Kuvvet Dengesi) açıklar.

---

## 1. Modüler UI Mimarisi (`UserControl` Yapısı & Kural 2)
* **Temel Kural:** Tüm UI kontrolleri asla tek bir `Form1.Designer.cs` içine yığılmaz (`context degradation` önlemi).
* **`Form1` (Ana Pencere & Üst Gezinme Menüsü):**
  - Form1 en üstünde sabit bir **Üst Gezinme Çubuğu (`MainNavigationBar`)** barındırır:
    - `[ PARAMETRE VE AYARLAR MERKEZİ ]` (`SimulationConfigDashboard` yükler)
    - `[ SİMÜLASYON VE UÇUŞ EKRANI ]`
    - `[ SENSÖR VE VERİ ANALİZİ ]`
  - Bu sayede kullanıcı, programın farklı modülleri arasında anlık geçiş yapabilir.
* **`SimulationConfigDashboard` (Ana Ayar Ekranı & Yan Menü Sıralaması):**
  - Sol taraftaki dikey gezinme menüsü (`SidebarMenu`) 8 ana modülden oluşur. **(Not: Simülasyonda "Faz 6" yoktur, kaldırılmıştır):**
    1. `1. Dünya ve Çevre Değişkenleri` (`WorldVariablesSubPanel`)
    2. `2. Uydunun Fiziksel Özellikleri` (`SatellitePhysicsSubPanel`)
    3. `3. Faz 1: Roketle Yükseliş & Ayrılma` (`Phase1SubPanel`)
    4. `4. Faz 2: Paraşütlü Süzülüş & SİGMA` (`Phase2SubPanel`)
    5. `5. Faz 3: Ayrılma Hali (S3 Blokları)` (`Phase3SubPanel`)
    6. `6. Faz 4: Aktif İniş (4 Alt Faz & PID)` (`Phase4SubPanel`)
    7. `7. APAM: Acil Paraşüt & Kurtarma` (`ApamSubPanel` — YENİ Bağımsız Panel)
    8. `8. Faz 5: Yere Temas & İniş Değerlendirmesi` (`Phase5SubPanel`)

---

## 2. Tasarım Kuralları ve Estetik (`Kural 4`)
* **Sade ve Düz Renk Paleti:** Emoji veya karmaşık ikonlar kullanılmaz. Flat, kurumsal, koyu lacivert/gri ve temiz beyaz/açık gri tonları kullanılır (`#0F172A`, `#1E293B`, `#F8FAFC`).
* **Sözdizimi Koruması:** `.Designer.cs` dosyalarında `System.Drawing.Color.FromArgb(((int)(((byte)(R)))), ((int)(((byte)(G)))), ((int)(((byte)(B)))))` yapısındaki parantezler derleyici hatasını önlemek için tam `5 parantez` kuralına uyularak yazılır.

---

## 3. Algoritmik Notlar ve Fizik Denklemleri

### A. Doğrusal Yüzey Alanı Geçişi (Linear Transition)
Paraşüt veya aerodinamik yüzeyler açılırken yüzey alanı 0'dan başlamaz. Mevcut alandan (`A_mevcut`) hedef alana (`A_hedef`), belirlenen `t_şişme` süresi boyunca doğrusal artış gösterir:
$$A(t) = A_{\text{mevcut}} + (A_{\text{hedef}} - A_{\text{mevcut}}) \cdot \frac{t}{t_{\text{şişme}}}$$

### B. Sızdıran Kova (Leaky Bucket) Sınırları, İntegral Modeli ve Uygulama Alanları
* **Matematiksel Karar Modeli (Zamana Göre İntegral & Zaman Tabanlı Birikim):**
  - Karesel fark yaklaşımı (`(Fark)^2`) anlık büyük sensör gürültüsü veya rüzgar darbesi sıçramalarında aşırı büyüdüğü için iptal edilmiş, yerine **Zamana Göre Doğrudan İntegral ($\int e(t) dt$)** modeli benimsenmiştir.
  - **Hatayla Orantılı Zaman İntegrali:** $\Delta L = (x(t) - x_{\text{eşik}}) \cdot \Delta t \cdot k_{\text{fill}}$ (Eşik aşım miktarı ve süresi birlikte birikir).
  - **Zaman Tabanlı Doğrusal Kova (Debouncer):** $\Delta L = k_{\text{fill}} \cdot \Delta t$ (Sadece süre tabanlı birikim). Kova kapasitesi doğrudan **saniye (sn)** veya **m/s·sn** birimindedir.
* **Kullanıldığı Yerler:**
  - **Faz 1 -> Faz 2 Geçişi:** Roketten ayrılma algılanması.
  - **Faz 2 -> Faz 3 Geçişi:** Ana paraşütlü süzülmede SİGMA ayrılma kararının verilmesi.
  - **Faz 4 Alt Faz Geçişleri (`4.1 -> 4.2 -> 4.3 -> 4.4`):** Sensör gürültüsü (barometre/IMU sıçraması veya rüzgar darbesi) nedeniyle erken fren veya motor kesmeyi önlemek için **her alt faz geçişine** ayrı sızdıran kova tanımlanır.
  - **APAM Tetiklenmesi:** Aşırı dikey düşüş veya tilt açısı sapmalarında yanlış alarmı önlemek için özel **APAM Sızdıran Kovası**.
  - **Faz 5 Temas Doğrulaması:** Zeminden sekmeleri elemeye yönelik zemin temas kovası.
* **Kullanılmadığı Yerler:**
  - **Faz 3 (`S3 Ayrılma Hali`):** Ayrılma kararı zaten verildiği için sadece mekanik ayrılmanın gerçekleştiğini sorgulayan `Ayrıldı Mı?` döngüsünden ibarettir.


### C. APAM (Acil Paraşüt & Kurtarma Modu) — `ApamSubPanel`
* **Çalışma Prensibi:** APAM, Faz 4'te veya uçuş sırasında dikey hız veya eğim tehlike sınırlarını aştığı zaman **APAM Sızdıran Kovası dolup taşarsa** devreye giren acil kurtarma sistemidir.
* **Alt Faza Atlama Yoktur:** APAM devreye girdiğinde alt fazlar arası geçiş yapmaz; uydunun **APAM Acil Paraşütü açılır**!
* **Etkisi:** Yüzey alanı doğrusal olarak **APAM Paraşütü Yüzey Alanına ($A_{\text{apam}}$)** ve $C_{\text{d,apam}}$ değerine oturur, yüksek hava sürtünmesi oluşturarak uydunun hızını güvenli limit hıza düşürür.

### D. Teorik Limit Hız ($v_{\text{limit}}$) ve Kuvvet Vektör Dengesi (`F_g = F_d`)
Her fazda uydunun aktif kütlesi ($m$) ve açık olan yüzey alanı ($A \times C_d$) farklı olduğu için, her fazın serbest süzülmede ulaşacağı teorik limit hız farklıdır.
* **Kuvvet Dengesi Formülü:** Limit hızda aşağı çeken yerçekimi kuvveti ($F_g$), yukarı iten hava sürtünme kuvvetine ($F_d$) eşit olur ($F_{\text{net}} = 0$):
  $$F_g = m \cdot g$$
  $$F_d = \frac{1}{2} \cdot \rho \cdot v^2 \cdot C_d \cdot A$$
* **Teorik Limit Hız ($v_{\text{limit}}$):**
  $$v_{\text{limit}} = \sqrt{\frac{2 \cdot m \cdot g}{\rho \cdot C_d \cdot A}}$$
* **UI Gösterimi (`Phase2`, `Phase3`, `Phase4`, `APAM`):** Her panelin içinde yer alan **Teorik Limit Hız & Kuvvet Vektör Diyagramı Kutusu (`GroupBox`)** sayesinde, o faz için aşağı çeken $F_g$ kuvveti, yukarı iten $F_d$ kuvveti ve limit hız ($m/s$ ve $km/h$) anlık hesaplanıp görselleştirilir.

### E. Faz 5 — Yere Temas ve İniş Değerlendirmesi (`Phase5SubPanel`)
* **Yerde Kalma Süresi (sn):** Uydunun yere temas ettikten sonra hareketsiz ve stabil kaldığını doğruladığı bekleme süresi (Örn: $10\text{ sn}$).
* **İniş Sertliği Değerlendirme Kademeleri:** Temas anındaki dikey çarpma hızına ($v_z$) göre otomatik simülasyon değerlendirmesi yapılır:
  - `Mükemmel / İyi İniş Sınırı:` $v \le 1.0\text{ m/s}$
  - `Normal İniş Sınırı:` $1.0 < v \le 3.0\text{ m/s}$
  - `Kötü İniş / Hasar Sınırı:` $v > 3.0\text{ m/s}$

### F. Sıcaklık Düşüş Oranı (Lapse Rate - L) & Standart Atmosfer
* **Dünya Fizik Parametresi:** `WorldVariablesSubPanel` içerisinde tanımlanır (`Varsayılan: L = 6.5 °C/km` veya `0.0065 °C/m`).
* **Sıcaklık Değişimi Formülü:** Uydu irtifa kazandıkça ortam sıcaklığı referans olarak doğrusal düşer:
  $$T(h) = T_0 - L \cdot h$$
  Burada $T_0$ deniz seviyesi (yer) referans sıcaklığı, $h$ ise uydunun anlık irtifasıdır.

### G. Sensör Hata Enjeksiyonu, Yer Kalibrasyonu ve Kestirim Ayrımı (`SensorSettingsSubPanel`)
* **Ferah ve Katmanlı Arayüz Tasarımı:**
  - Kontroller iç içe geçmeyecek şekilde geniş kaydırılabilir panel (`AutoScroll = true`) üzerinde konumlandırılmıştır.
  - Hata enjeksiyon alanında enjekte edilen hataların hemen yanında **`-> İşlenen Mutlak Bias (b)`** ve **`-> İşlenen Bağıl Scale (%)`** göstergeleri (`0.0000` başlangıçlı) yer alır.
* **Tam Skala (Full Scale Span - FS) Referans Modeli:**
  - $0\text{ °C}$ veya irtifa sıfır noktasında yüzdelik hesaplamaların sonsuza gitmesini önlemek amacıyla sensör çalışma aralığı (`[Min, Max]`) alınır.
  - Tam Skala: $FS = \text{Max} - \text{Min}$ olarak hesaplanır. Bağıl yüzdelik gürültü ve hataların tümü $FS$ üzerinden ölçeklenir.
* **Hata / Gürültü Sınıflandırması:**
  1. **Sistematik Hatalar (Kalibrasyonla Temizlenecekler):**
     - `Mutlak Hata (Bias - b):` Ölçüme doğrudan sabit bir miktar ekleyen sıfır kayması hatası.
     - `Bağıl Hata (Scale Factor - S %):` Ölçümün büyüklüğüyle ve $FS$ yüzdesiyle orantılı ölçek hatası.
  2. **Stokastik Gürültüler (Kalibrasyonda Korunup Gelecekteki Kalman/Kestirim Modülüne Aktarılacaklar):**
     - `Sabit Termal Gauss Gürültüsü (σ_sabit):` Sabit standart sapmalı rastgele termal gürültü.
     - `Bağıl Termal Gürültü (σ_bağıl):` Sinyal şiddetine bağlı Gauss gürültüsü (`% FS`).
     - `Darbe Hatası (Spike):` Belirli olasılıkla anlık aşırı sıçrama yaratan darbe gürültüleri.
* **Manuel Referans Seçimi ve Dosya İşlemleri (`SaveFileDialog` / `OpenFileDialog`):**
  - Kullanıcı, kalibrasyonda kullanılacak iki fiziksel referans noktasını (`Ref 1` ve `Ref 2`) arayüzden serbestçe belirleyebilir.
  - **Yalın Dosya Formatı:** Ölçüm dosyaları karmaşıklıktan arındırılmış yalın formatta tutulur:
    - **1. Satır:** Örneklem sayısı ($N$) ve referans nokta sayısı ($2$), örneğin: `500 2`
    - **2. Satır:** `Ref 1` noktası için alınan $N$ adet ölçüm değeri (aralarında boşluk bırakılarak).
    - **3. Satır:** `Ref 2` noktası için alınan $N$ adet ölçüm değeri (aralarında boşluk bırakılarak).
  - Kullanıcı `[ Ölçüm Verisi Üret ]` butonuna bastığında `SaveFileDialog` ile kayıt yolunu kendisi belirler; `[ Kalibrasyon Çalıştır ]` butonuna bastığında `OpenFileDialog` ile istediği dosyayı seçip analizi başlatır.
* **Ortak Örneklem Üretim Motoru (`GenerateSampleSet`):**
  - Hem kalibrasyon (`Ref 1` ve `Ref 2`) hem de dağılım analizi (`X_test`) için tek bir merkezi örneklem üretim metodu (`GenerateSampleSet(double trueVal, int count)`) kullanılır. Böylece hata ve gürültü enjeksiyonu tüm analiz modüllerinde %100 eşgüdümlü ve tutarlı hale getirilmiştir.
* **4. Bölüm: Doğruluk (Accuracy) & Kesinlik (Precision) Dağılım Analizi ve Çift Çan Eğrisi Gösterimi:**
  - Kullanıcı, istediği bir test referans noktası (`X_test`) ve örneklem sayısı (`N`) girerek **`[ Analiz Et ve Dağılım Grafiğini Çiz ]`** butonuna bastığında:
    1. **Ham Ölçüm Seti ($X_{\text{ham}}$):** Enjekte edilen aktif hatalar (`b`, `S%`) ve gürültüler (`σ_sabit`, `σ_bağıl`, `Spike`) ile $N$ adet ham ölçüm üretilir.
    2. **Kalibre Edilmiş Ölçüm Seti ($X_{\text{cal}}$):** Üretilen veriler aktif işlenen hatalarla temizleme denkleminden geçirilir:
       $$X_{\text{cal}} = \frac{X_{\text{ham}} - b_{\text{işlenen}}}{1 + \frac{S_{\text{işlenen}}}{100}}$$
  - **Görselleştirme (`picDistributionGraph` GDI+ Çizimi):**
    - Her iki veri setinin **36 Sütunlu Olasılık Yoğunluk Histogramı** ile tam teorik **Gauss Çan Eğrisi (PDF)** aynı eksen üzerinde çizilir.
    - Kırmızı / Turuncu eğri (`Ham Dağılım`) ve Yeşil eğri (`Kalibre Edilmiş Dağılım`) ile Sarı dikey gerçek referans çizgisi (`X_test`) karşılaştırılır.
  - **Metroloji & Mühendislik Sonucu (`txtDistributionMetrics`):**
    - **Doğruluk (Accuracy / Trueness - Merkezi Sapma):** Kalibrasyon sayesinde çan eğrisinin ortalaması ($\mu_{\text{cal}}$) tam olarak gerçek değer ($X_{\text{test}}$) çizgisine oturur (`Doğruluk İyileşme Oranı %99.9+`).
    - **Kesinlik (Precision / Repeatability - Standart Sapma $\sigma$):** Çan eğrisinin genişliği ve tekrarlanabilirlik aralığı ($\mu \pm 2\sigma$) gürültüye bağlı olarak korunur. Bu durum, kalibrasyonun sistematik kaymayı sıfırladığını ancak fiziksel gürültünün uçuş sırasında çalışacak **Gelişmiş Kalman Kestiricisi** ile daraltılması gerektiğini ispatlar.



