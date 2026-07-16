# RaSAT SIM (FlyingAnalysis) - Uçuş Dinamiği, Sensör Kalibrasyonu ve Kestirim Platformu

RaSAT SIM, model uydu projeleri için uçuş algoritmalarının, sensör hatalarının ve sensör füzyonu (Kalman Filtresi) performansının teorik ve deneysel olarak incelenmesi ile doğrulanması amacıyla geliştirilmiş bir simülasyon ve analiz platformudur.

---

## Ana Proje: FlyingAnalysis

Ekosistemin temel analiz aracı olan FlyingAnalysis; 4 fazlı yarışma uçuş dinamiğine ek olarak, belirli anlarda sensörlerin bozulduğu, veri kesintilerinin yaşandığı veya rüzgar darbelerinin etkili olduğu özel uçuş senaryoları (Timeline Studio) oluşturmayı, sensör kalibrasyon modellerini ve 3x3 Kalman Kestirim Çekirdeğini (EKF) modüler bir arayüzde sunar.

### Temel İşlevi
Model uydunun roketten ayrılma, serbest düşüş, 1. ve 2. paraşüt açılma ile görev yükü ayrılma fazlarını simüle eder. Sensörlerde (Barometre ve İvmeölçer) oluşabilecek metrolojik hataları (%20 sistematik kayma, %20 rastgele gürültü, ani sıçramalar ve veri kesintileri) modeller ve Kalman Filtresi (EKF) algoritmalarının bu hataları süzme başarımını gerçek zamanlı test eder.

### Girdiler
* **Fiziksel ve Atmosferik Değişkenler:** Taşıyıcı ve görev yükü kütleleri (kg), paraşüt ve kanat alanları (m²), sürüklenme katsayısı (Cd) ile atmosferik referans basınç ve sıcaklık değerleri (P0, T0).
* **Sensör Metroloji ve Hata Tanımları:** Barometre ve ivmeölçer için sabit kayma (Bias), ölçek hatası (Scale Error %), beyaz gürültü standart sapması (σ) ve ısıl kayma katsayıları.
* **Zaman Çizelgesi ve Senaryo Tanımları:** Belirli saniyelerde tetiklenen dış kuvvet darbeleri (rüzgar/türbülans), sensör veri kesintileri (Cutoff) veya özel gürültü profilleri.
* **Kestirim Ayarları:** Kalman filtresi süreç gürültü matrisi (Q) ve sensör ölçüm gürültü matrisi (R) katsayıları.

### Çıktılar
* **Zaman-Konum ve Kuvvet Grafikleri:** Uydunun irtifa, hız, ivme verileri ile üzerindeki net aerodinamik ve kütleçekim kuvvet diyagramı.
* **Metrolojik Başarı ve Kestirim Raporu:**
  * **Doğruluk İyileşmesi (Trueness):** Ters kalibrasyon denkleminin sistematik kayma ve ölçek hatasını sönümleme oranı.
  * **Kesinlik Süzme (Precision / σ):** Kalman filtresinin rastgele beyaz gürültü titreşimlerini bastırma oranı.
  * **RMSE (Karesel Ortalama Hata):** Sistemin ham veri, kalibre edilmiş veri ve EKF kestirimi arasındaki toplam hata analiz tablosu.

---

## Yardımcı ve Destekleyici Modüller

FlyingAnalysis platformunu destekleyen, tasarım ve doğrulama süreçlerinde kullanılan diğer modüller:

### 1. Sayısıal Similasyon (Fizik ve Telemetri Motoru)
* **Temel İşlevi:** Model uydunun düşüş dinamiğini ve yer istasyonuna iletilecek haberleşme paketlerini matematiksel denklemlerle modelleyen temel motordur.
* **Girdi:** Bırakılma yüksekliği (örn. 700 m), görev yükü ayrılma hedefi (örn. 400 m), telemetri frekansı (1 Hz) ve ortam parametreleri.
* **Çıktı:** Zaman çizelgesine göre üretilen standart telemetri veri paketleri dizisi (Paket No, İrtifa, Hız, Sıcaklık, Görev Fazı) ve komut tetikleme logları.

### 2. SensorAnalizi (Sensör Arıza ve Gömülü STM32 Algoritma Doğrulaması)
* **Temel İşlevi:** Sensör arızalarının model uydu algoritmaları üzerindeki etkisini inceleyen ve gerçek STM32 mikrodenetleyici C/C++ kodlerinin simülasyonda test edildiği doğrulama aracıdır.
* **Girdi:** En kötü durum (Worst-Case) arıza senaryoları (ani basınç sıçramaları, sensör donması, sıfır okuması).
* **Çıktı:** Hatalı tetikleme (False-Positive) analiz raporu. Havada oluşan anlık basınç şoklerinde sistemin yanlış iniş veya ayrılma komutu üretip üretmediğinin değerlendirilmesi.

### 3. Veri Analizi (Uçuş Sonrası CSV ve Telemetri Analizi)
* **Temel İşlevi:** Sahada yapılan gerçek uçuş testelerinden veya simülasyonlardan elde edilen veri log dosyalarını (CSV) içeri aktararak grafik üzerinde inceleme aracıdır.
* **Girdi:** Uçuş sırasında kaydedilen CSV formatındaki telemetri kayıt dosyaları.
* **Çıktı:** Karşılaştırmalı ve yakınlaştırılabilir uçuş grafikleri ile uçuş özet verileri (paraşüt açılma anı, görev yükü ayrılma irtifası, maksimum düşüş hızı).

---

## Metrolojik Değerlendirme Prensibi

Simülasyon ve Monte-Carlo testleri sonucunda uçuş algoritmaları için şu temel prensip esas alınmıştır:

"Kalman Filtresi (EKF) verinin kesinliğini (Precision / Standart Sapma σ) artırır, ancak verinin doğruluğunu (Trueness / Bias) tek başına sağlayamaz. Sistematik hataları elimine etmek için statik ve ters sensör kalibrasyonu uygulanması gereklidir."

---

## Kurulum ve Çalıştırma

### Gereksinimler
* .NET 8.0 SDK veya üzeri
* Visual Studio 2022 / JetBrains Rider veya dotnet CLI

### Derleme ve Çalıştırma
```powershell
cd "m:\Godot\Projeler\RaSAT SIM\FlyingAnalysis"
dotnet restore
dotnet build -c Release
dotnet run
```
