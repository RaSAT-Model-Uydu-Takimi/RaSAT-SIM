# Sensör Kalibrasyonu, Hata Enjeksiyonu ve Metroloji Matematiği

Bu doküman, `RaSAT SIM` ve `FlyingAnalysis` yazılımlarında kullanılan sensör hata modellerini, yer kalibrasyonu algoritmalarını, işlenen veri temizleme formüllerini ve Olasılık Yoğunluk Histogramı (PDF Çan Eğrisi) görselleştirme matematiğini detaylıca açıklar.

---

## 1. Sensör Ölçüm ve Hata Enjeksiyon Modeli

Gerçek dünya fiziksel sensörlerinin (Barometre, Sıcaklık Sensörü, IMU/İvmeölçer vb.) herhangi bir $t_i$ anındaki ham ölçümü ($X_{\text{ölçüm}, i}$) dört temel hata ve gürültü bileşeninden oluşur:

$$X_{\text{ölçüm}, i} = X_{\text{gerçek}, i} \cdot \left(1 + \frac{S_{\text{enjekte}}}{100}\right) + b_{\text{enjekte}} + \eta_{\text{Gauss}, i} + \eta_{\text{Spike}, i}$$

### A. Sistematik Hatalar (Kalibrasyonla Temizlenebilen Bileşenler)
1. **Mutlak Sıfır Kayması Hatası ($b_{\text{enjekte}}$ - Bias):**
   Sensörün sıfır noktasının veya referans tabanının sabit bir miktarda yukarı veya aşağı kaymasıdır. Ölçüm aralığı boyunca sabit kalır ($+\text{birim}$ veya $-\text{birim}$).
2. **Bağıl Ölçek Çarpanı Hatası ($S_{\text{enjekte}}$ - Scale Factor Error %):**
   Sensör kazancının (gain) ideali olan $1.0$'dan sapmasıdır. Ölçülen büyüklük arttıkça hatanın mutlak miktarı da doğrusal olarak artar. Örneğin $S = \%2.0$ ise, $100\text{ m}$'de $+2\text{ m}$ sapma yaparken, $1000\text{ m}$'de $+20\text{ m}$ sapma yapar.

### B. Stokastik Gürültüler (Kalman Filtresi ile Sönümlendirilen Bileşenler)
3. **Gauss Termal ve Elektronik Gürültüsü ($\eta_{\text{Gauss}, i}$):**
   Sıfır ortalamalı ($\mu = 0$) ve standart sapması $\sigma_{\text{toplam}}$ olan sürekli rastgele gürültüdür. Box-Muller dönüşümü kullanılarak standart normal dağılım ($Z \sim \mathcal{N}(0, 1)$) üzerinden üretilir:
   $$u_1, u_2 \in (0, 1) \text{ düzgün rastgele sayılar olmak üzere:}$$
   $$Z = \sqrt{-2 \ln(u_1)} \cdot \cos(2\pi u_2)$$
   $$\sigma_{\text{toplam}} = \sqrt{\sigma_{\text{sabit}}^2 + \left(FS \cdot \frac{\% \text{Rel}}{100}\right)^2}$$
   $$\eta_{\text{Gauss}, i} = Z \cdot \sigma_{\text{toplam}}$$
   *(Burada $FS$: Tam Skala Açıklığı / Full Scale Span).*

4. **Darbe (Spike / Outlier) Gürültüsü ($\eta_{\text{Spike}, i}$):**
   Sensörün elektriksel parazitler, mekanik sarsıntı veya veri otobüsü hataları nedeniyle anlık olarak uç değerler üretmesidir. Belirli bir olasılık ($P_{\text{spike}}\%$) ile $\pm A_{\text{spike}}$ genliğinde darbe eklenir.

---

## 2. İki Noktalı Doğrusal Yer Kalibrasyonu Algoritması

Sistematik hataları ($S$ ve $b$) birbirinden ayırt etmek için sensör, bilinen iki sabit fiziksel referans noktasında (`Ref 1` ve `Ref 2`) teste tabi tutulur.

### Adım 2.1: Stokastik Gürültüyü Sönümleme (Ortalama Alma - $N$ Örneklem)
Sıfır ortalamalı Gauss gürültüsünün beklenen değeri $\mathbb{E}[\eta_{\text{Gauss}}] = 0$ olduğu için, her referans noktasında $N$ adet (örn. $N=500$) hızlı ölçüm alınıp aritmetik ortalaması alındığında stokastik gürültü sıfıra yakınsar:

$$\bar{X}_1 = \frac{1}{N} \sum_{k=1}^{N} X_{\text{ölçüm}, 1, k} \approx X_{\text{gerçek}, 1} \cdot m + b$$
$$\bar{X}_2 = \frac{1}{N} \sum_{k=1}^{N} X_{\text{ölçüm}, 2, k} \approx X_{\text{gerçek}, 2} \cdot m + b$$

*(Burada $m = 1 + \frac{S}{100}$ sensörün kazanç/eğim çarpanıdır).*

### Adım 2.2: İki Bilinmeyenli Denklem Sistemi Çözümü
İkinci ortalama denkleminden birinci denklem çıkarılarak sabit bias ($b$) yok edilir ve gerçek kazanç eğimi ($m$) çözülür:

$$m = \frac{\bar{X}_2 - \bar{X}_1}{X_{\text{gerçek}, 2} - X_{\text{gerçek}, 1}}$$

Buradan **Tespit Edilen Bağıl Ölçek Hatası ($S_{\text{tespit}}\%$)** elde edilir:
$$S_{\text{tespit}}\% = (m - 1) \cdot 100$$

Bulunan eğim çarpanı ($m$) birinci denklemde yerine koyularak **Tespit Edilen Mutlak Bias ($b_{\text{tespit}}$)** çözülür:
$$b_{\text{tespit}} = \bar{X}_1 - (X_{\text{gerçek}, 1} \cdot m)$$

---

## 3. Aktif Hata İşleme ve Temizleme Denklemi

Kalibrasyon algoritmasının bulduğu veya kullanıcının `[ Hata Değerlerini İşle ]` butonuna basarak onayladığı işlenen değerler (`processedBias` ve `processedScalePercent`), simülasyonun anlık okuma fonksiyonu `GetCalibratedValue` tarafından ham veriye uygulanır:

$$X_{\text{kalibre}, i} = \frac{X_{\text{ölçüm}, i} - b_{\text{işlenen}}}{1 + \frac{S_{\text{işlenen}}}{100}}$$

**Kritik Mühendislik Kuralı:** Bu temizleme denklemi yalnızca **sistematik kaymaları ($b$ ve $S$)** sıfırlar. Ölçümün içindeki stokastik Gauss gürültüsü ($\eta_{\text{Gauss}}$) ve darbe gürültüsü ($\eta_{\text{Spike}}$) bu denklemle yok edilemez (sadece ölçek çarpanıyla normalize olur). Bu rastgele gürültülerin uçuş anında sönümlendirilmesi **Gelişmiş Kalman Filtresi / Kestirici** modülünün görevidir.

---

## 4. Olasılık Yoğunluk Histogramı ve Çan Eğrisi (PDF) Çizim Matematiği

Sensörün **Doğruluk (Accuracy)** ve **Kesinlik (Precision)** performansını görselleştirmek için hem ham hem de kalibre edilmiş veri setlerinin histogram çubukları ve teorik Gauss çan eğrileri (PDF) aynı eksende çizilir.

### Adım 4.1: Veri Aralığı ($spanX$) ve Sütun Genişliği ($w_{\text{bin}}$)
Üretilen verilerin minimum ve maksimum değerlerine %15 sağ/sol pay eklenerek çizim aralığı belirlenir:
$$X_{\min} = \min(X) - 0.15 \cdot \text{span}$$
$$X_{\max} = \max(X) + 0.15 \cdot \text{span}$$
$$spanX = X_{\max} - X_{\min}$$

Grafikte $k = 36$ adet dikdörtgen sütun kullanılır. Her sütunun fiziksel birim genişliği:
$$w_{\text{bin}} = \frac{spanX}{36}$$

### Adım 4.2: Sütunlara Veri Sayımı ve Olasılık Yoğunluk Normalizasyonu
Her bir veri noktasının ($x_j$) hangi sütuna düştüğü bulunup frekans ($f_i$) artırılır:
$$\text{Sütun İndeksi } i = \left\lfloor \frac{x_j - X_{\min}}{w_{\text{bin}}} \right\rfloor$$

Sütunların toplam alanını $1.0$ yapmak ve üzerine çizilecek teorik çan eğrisine (PDF) tam oturtmak için her sütunun **Olasılık Yoğunluk Yüksekliği ($d_i$)** hesaplanır:
$$d_i = \frac{f_i}{N \cdot w_{\text{bin}}}$$

### Adım 4.3: Ekran Pikseline Dönüşüm ve Dikdörtgen Çizimi
Çizim alanı piksel boyutları $W_{\text{plot}}$ ve $H_{\text{plot}}$, en yüksek yoğunluk değeri $d_{\max}$ olmak üzere, her dikdörtgenin sol-üst köşe koordinatları ve piksel boyutları şöyledir:
$$\text{Genişlik}_{\text{px}} = \left(\frac{w_{\text{bin}}}{spanX}\right) \cdot W_{\text{plot}}$$
$$\text{Yükseklik}_{\text{px}} = \left(\frac{d_i}{d_{\max} \cdot 1.15}\right) \cdot H_{\text{plot}}$$
$$X_{\text{px}} = \text{plotArea.Left} + \left(\frac{i \cdot w_{\text{bin}}}{spanX} \cdot W_{\text{plot}}\right)$$
$$Y_{\text{px}} = \text{plotArea.Bottom} - \text{Yükseklik}_{\text{px}}$$

### Adım 4.4: Teorik Gauss PDF Çözümü ($f(x)$)
Her iki veri setinin hesaplanan ortalama ($\mu$) ve standart sapması ($\sigma$) kullanılarak teorik sürekli çan eğrisi noktaları çözülür ve çizilir:
$$f(x) = \frac{1}{\sigma \sqrt{2\pi}} \exp\left( -\frac{(x - \mu)^2}{2\sigma^2} \right)$$
$$\text{Piksel Yüksekliği } Y_{\text{curve}}(x) = \text{plotArea.Bottom} - \left(\frac{f(x)}{d_{\max} \cdot 1.15}\right) \cdot H_{\text{plot}}$$

---

## 5. Doğruluk (Trueness) ve Kesinlik (Precision) Ayrımı

| Metrik | Tanım | İlişkili Olduğu Hata | Kalibrasyonun Etkisi |
| :--- | :--- | :--- | :--- |
| **Doğruluk (Accuracy / Trueness)** | Ölçüm dağılımı ortalamasının ($\mu$) gerçek fiziksel değere ($X_{\text{test}}$) yakınlığıdır. | Sistematik Hatalar ($b$ ve $S\%$) | **Mükemmelleştirir (%99.9+ İyileşme).** Çan eğrisinin tepe noktasını tam gerçek değer çizgisine taşır. |
| **Kesinlik (Precision / Repeatability)** | Arka arkaya alınan ölçümlerin kendi arasındaki tutarlılığı ve dağılım darlığıdır ($\pm \sigma$). | Stokastik Gürültüler ($\sigma_{\text{sabit}}$ ve $\sigma_{\text{bağıl}}$) | **Etki Etmez.** Çan eğrisinin genişliği korunur. Bu yayvanlığı daraltmak için uçuş anında **Kalman Filtresi** devreye girer. |

---

## 6. Aykırı Değer Kırpma (Trimmed Mean), Klasik Dosya Formatı ve ScottPlot Analizi (Faz 5 Güncellemesi)

### 6.1. Aykırı Değer Kırpma (%5 Medyan / IQR Budamalı Ortalama)
Sensör kalibrasyonu sırasında alınacak ortalama değerler ($\bar{X}_1$ ve $\bar{X}_2$), eğer sensörde darbe gürültüsü (spike noise) veya anlık elektro-mekanik patlamalar varsa sapabilir (ortalama zehirlenmesi). Bunu önlemek amacıyla 2 noktalı regresyonda **%5 Budamalı Aritmetik Ortalama (Trimmed Mean)** uygulanır:

1. Ölçüm dizisi küçükten büyüğe sıralanır: $X_{(1)} \le X_{(2)} \le \dots \le X_{(N)}$
2. Budanacak veri adedi hesabı: $k = \lfloor N \cdot 0.05 \rfloor$
3. Alttan ve üstten $k$ adet en uç darbe (spike) değeri dışarıda bırakılır:
   $$\bar{X}_{\text{trimmed}} = \frac{1}{N - 2k} \sum_{i = k + 1}^{N - k} X_{(i)}$$
*Not: Bu budama **sadece kalibrasyon parametrelerinin ($m, b, S$) doğru hesaplanması için geçici bir işlemdir.** Ham veri dosyası asla eksiltilmez veya kalıcı olarak silinmez ($N$ adet veri korunur).*

### 6.2. Yeni Standart Dikey Veri Kümesi Formatı (RaSAT Standart Girdi/Çıktı Formatı)
Modüller arası veri transferinde standart, şık ve parse edilebilir **Yeni Dikey Veri Formatı** kullanılır:
* **1. Satır (`True / Reference Value - X_true`):** Bu veri kümesinin üretilirken baz alındığı veya kalibrasyonda referans alınan gerçek değer (Örn: `10.0000`).
* **2. Satır (`Sample Count - N`):** Dosyadaki toplam örneklem adedi (Örn: `500`).
* **3. Satır ve Sonrası (`Satır Satır Değerler`):** Her satırda tek bir örneklem/ölçüm değeri olacak şekilde alt alta toplam $N$ satır.

Örnek çıktı (`SensorOlcum_N500_Gercek10.0.txt`):
```text
10.0000
500
10.1245
9.8942
10.0512
10.0123
...
```
*Not: Okuyucu (`ParseClassicalFile`), hem bu yeni dikey formatı hem de eski format (`500 1` ve alt satırda boşluklu veriler) dosyalarını otomatik algılayarak geriye dönük tam uyumlulukla çalışır.*

### 6.3. Zaman Serisi ile Dağılım Karşılaştırmasının Birlikte Analizi (ScottPlot 5 Tam Entegrasyonu)
Sayfa 2 analiz tuvalinde, girilen veya anlık çekilen veri dosyalarının **iki boyutlu çift analizi** yapılır:
1. **ScottPlot Zaman Serisi (`plotTimeSeries`):** Her bir indeks adımı ($i \in [0, N-1]$) karşısında sensörün anlık titreşim grafiğini çizer. Sarı çizgi gerçek referansı (`sTrue.LineWidth = 3.2f`) gösterirken, Kırmızı ham verinin yukarı/aşağı kaymasını ve yeşil kalibre edilmiş verinin referans etrafındaki sıfır-bias oturmasını görselleştirir.
2. **ScottPlot Olasılık Dağılımı (`plotDistributionGraph`):** Aynı verilerin frekans histogramını (`ScottPlot.Bar`) birbirini kapatmayacak şekilde (`±0.18 * binWidth`) kaydırarak ve yarı şeffaf (`WithAlpha`) çizerek gösterir. Gauss Olasılık Yoğunluk Fonksiyonunu (PDF) eş zamanlı çan eğrisi (`Scatter`) olarak çizer. Sürgü (`trkBinCount`) ile maksimum **1000** dilime kadar mikrometrik histogram çözünürlüğü ayarlanarak 3 Görünüm Modunda (İkili, Zaman Serisi Dev, Dağılım Dev) incelenir.

