# KESTİRİM ÇEKİRDEĞİ (ESTIMATION CORE) VE GELİŞMİŞ KALMAN FİLTRESİ MEKANİĞİ

Bu doküman, RaSAT SIM / FlyingAnalysis simülasyon yazılımında yer alan **Kestirim Çekirdeği (Estimation Core)** mimarisini, kalibre edilmiş sensör verilerinin (İvmeölçer, Barometre, Sıcaklık) **Gelişmiş Kalman Filtresi (Advanced / Extended Kalman Filter - EKF)** ile nasıl kaynaştırıldığını (Sensor Fusion), sensör kesintileri (Cutoff/Blackout) ve gürültü durumlarında **Güven Katsayısının (Confidence Coefficient)** nasıl dinamik olarak yönetildiğini detaylandırmak amacıyla hazırlanmıştır.

---

## 1. MİMARİ VE MODÜLER YAPILANMA

Kestirim Çekirdeği, arayüzden ve simülasyon döngüsünden tamamen bağımsız, test edilebilir ve modüler bir arka plan servisi (`Backend Engine`) olarak tasarlanmıştır:

```
[TimelineSimulationEngine] ──(Kalibre Edilmiş Veriler: Baro, İvme, Sıcaklık)──► [EstimationCoreEngine (Backend)]
                                                                                       │
                                                                                       ├─► Gelişmiş Kalman (EKF) Kestirimi (z, v, a)
                                                                                       ├─► Dinamik Kovaryans & Gözlem Matrisleri (P, R, Q)
                                                                                       └─► Güven Katsayısı (Confidence %: 0-100)
                                                                                               │
                                                                                               ▼
[SensorEstimationSubPanel (Sayfa 3 UI)] ◄──(Kestirim & Güven Metrikleri)─────────── [Grafik Çizim & Analiz Panelleri]
```

1. **Backend Servisi (`EstimationCoreEngine.cs`):** 
   * Simülasyondan gelen her adımda (`dt`) kalibre edilmiş barometrik irtifa (`CalibratedBaroPosition`), kalibre edilmiş dikey ivme (`CalibratedAcceleration`) ve sıcaklık (`Temperature`) verilerini alarak durum tahmini yapar.
2. **Modüler Arayüz (`SensorEstimationSubPanel.cs` - Sayfa 3):**
   * Sensör ayarları panelindeki 3. modüler alt sekmedir (`Sayfa 1: Sensörler`, `Sayfa 2: Grafik Katmanları`, `Sayfa 3: Kestirim Çekirdeği`).
   * Çekirdeğin Kalman kazanç parametrelerinin ($Q, R$ varsayılanları, Güven Katsayısı düşüş oranları, Sıcaklık yedekleme stratejileri) ayarlandığı ve gelecekte yeni kestirim algoritmalarının (UKF, Complementary Filter vb.) eklenebileceği esnek bir arayüzdür.

---

## 2. GELİŞMİŞ KALMAN FİLTRESİ (ADVANCED KALMAN FILTER) MATEMATİĞİ

Kestirim çekirdeği, roket ve uydunun tek eksenli (Z ekseni / İrtifa) kinematiğini 3 durumlu bir vektör ($X_k$) üzerinden takip eder:

\[
X_k = \begin{bmatrix} z_k \\ v_k \\ a_k \end{bmatrix} = \begin{bmatrix} \text{Tahmini İrtifa (m)} \\ \text{Tahmini Dikey Hız (m/s)} \\ \text{Tahmini Dikey İvme (m/s}^2\text{)} \end{bmatrix}
\]

### A. Tahmin (Prediction / Time Update) Adımı
İvmeölçerden gelen kalibre edilmiş ivme ($a_{\text{meas}}$) doğrudan bir kontrol girdisi ($u_k$) veya durumun bir parçası olarak kullanılabilir. Sürekli zaman kinematiği ayrık zamana ($\Delta t$) dönüştürüldüğünde durum geçiş matrisi ($F$) ve tahmin denklemi:

\[
X_{k|k-1} = F \cdot X_{k-1|k-1} \quad \text{burada} \quad F = \begin{bmatrix} 1 & \Delta t & \frac{1}{2}\Delta t^2 \\ 0 & 1 & \Delta t \\ 0 & 0 & 1 \end{bmatrix}
\]

Hata Kovaryans Matrisi ($P$) Güncellemesi:
\[
P_{k|k-1} = F \cdot P_{k-1|k-1} \cdot F^T + Q
\]
*(Burada $Q$, sistem/süreç gürültüsü kovaryans matrisidir; rüzgar türbülansı, model belirsizlikleri ve ani manevraları temsil eder).*

### B. Güncelleme (Update / Measurement Correction) Adımı
Barometreden gelen kalibre edilmiş irtifa ($z_{\text{baro}}$) gözlem vektörü ($Z_k$) olarak alınır. Gözlem matrisi ($H$) barometrenin sadece irtifayı ($z$) ölçtüğünü belirtir:

\[
H = \begin{bmatrix} 1 & 0 & 0 \end{bmatrix}, \quad Z_k = [z_{\text{baro}}]
\]

Kalman Kazancı ($K_k$), Yenilik (Innovation $y_k$) ve Durum Güncellemesi:
\[
y_k = Z_k - H \cdot X_{k|k-1}
\]
\[
S_k = H \cdot P_{k|k-1} \cdot H^T + R_k \quad \implies \quad K_k = P_{k|k-1} \cdot H^T \cdot S_k^{-1}
\]
\[
X_{k|k} = X_{k|k-1} + K_k \cdot y_k
\]
\[
P_{k|k} = (I - K_k \cdot H) \cdot P_{k|k-1}
\]
*(Burada $R_k$, sensör ölçüm gürültüsü kovaryans matrisidir. Sensör sağlığına, gürültü seviyesine ve kesinti durumlarına göre **dinamik olarak** değiştirilir).*

---

## 3. SENSÖR KESİNTİSİ (CUTOFF), GÜRÜLTÜ VE GÜVEN KATSAYISI (CONFIDENCE COEFFICIENT) MEKANİĞİ

Uçuş sırasında sensörlerin arızalanması, aşırı gürültüye maruz kalması veya verinin kesilmesi durumunda Kestirim Çekirdeği **Dinamik Gözlem Kovaryansı ($R_k$) ve Güven Katsayısı ($C_{\text{conf}}$)** mekanizmasını çalıştırır.

Güven Katsayısı $C_{\text{conf}} \in [0.0, 100.0]$ yüzdesel bir değerdir ve sensörlerin sağlığı ile yenilik (innovation $y_k$) tutarlılığına bağlı olarak her adımda hesaplanır.

### Sensör Bazlı Etki ve Mantık Tablosu

| Sensör / Olay Türü | Kestirim Çekirdeği Tepkisi (Matematiksel Mantık) | Güven Katsayısı ($C_{\text{conf}}$) Etkisi | Neden Bu Mantık Seçildi? |
| :--- | :--- | :--- | :--- |
| **İvmeölçer (Accelerometer) Kesintisi / Arızası** | İvmeölçer verisi (`NaN` veya $R_{\text{acc}} \to \infty$) kesildiğinde, tahmin adımında $a_k$ modelden veya barometrik türevden ($\Delta z / \Delta t$) kestirilir. | **% -30 Düşüş** (Örn: %100'den %70'e iner) | İvmeölçer kısa vadeli ani değişimleri ve yüksek frekanslı hareketleri yakalar. Kesildiğinde sistem barometrenin gecikmeli ve gürültülü verisine kalır, ancak irtifa konumu kaybolmaz. |
| **Barometre (Barometer) Kesintisi / Arızası** | Barometre verisi (`NaN`) kesildiğinde, Kalman güncelleme adımı devre dışı bırakılır ($H=0$ veya $R_{\text{baro}} \to \infty$). Sistem tamamen **İvme Çift İntegrali (Dead Reckoning)** moduna geçer. | **% -40 Düşüş** (Örn: %100'den %60'a iner ve zamanla sürüklenme arttıkça her saniye %2 daha düşer) | İrtifa referansı kaybolmuştur. İvmeölçer çift integrali zamanla karesel hataya ($t^2$) yol açar. Bu nedenle güven hızla azalmalıdır. |
| **Sıcaklık Sensörü (Temperature) Kesintisi / Arızası** | Sıcaklık verisi kesildiğinde (`NaN`), barometre verisi **REDDEDİLMEZ!** Çekirdek **"Sıcaklık Yedekleme Modeli"ne (Temperature Fallback Model)** geçer. | **% -5 ile -10 Arası Çok Hafif Düşüş** (Örn: %100'den %92'ye iner) | **Sıcaklık Çok Yavaş Değişen Bir Parametredir:** İrtifaya bağlı sıcaklık değişimi standart atmosferde saniyeler içinde aniden sıçramaz ($6.5^\circ\text{C/km}$). Sıcaklık sensörü bozulursa, en son bilinen geçerli sıcaklık veya $T = 15 - 0.0065 \cdot z_{\text{est}}$ formülü kullanılır. Barometrenin hidromekânik formülünde küçük bir ölçek hatası yaratacağı için güven sadece minimal düzeyde kırpılır. |
| **Yüksek Gürültü (Special Condition Noise) Eklenmesi** | Timeline üzerinden sensörlere aşırı gürültü eklendiğinde, yenilik (innovation $y_k$) ve standart sapma $\sigma$ büyür. Çekirdek $R_k$ değerini otomatik artırarak o sensöre daha az güvenir. | **% -15 ile -25 Arası Dinamik Düşüş** ($y_k / \sqrt{S_k}$ mahalanobis mesafesine bağlı) | Sensör veri göndermeye devam etmektedir ancak veri kirli ve dalgalıdır. Kalman filtresi gürültülü sensörü bastırır ve model tahminine (veya temiz olan diğer sensöre) ağırlık verir. |
| **Tam Kesinti (Blackout - Tüm Sensörler Kapalı)** | $R_{\text{baro}} \to \infty, R_{\text{acc}} \to \infty$. | **%0'a Doğru Hızlı Düşüş** (%10/saniye erime) | Sistem tamamen kördür; aerodinamik serbest düşüş / paraşüt sürüklenme modeline göre tahmini sürdürür ama güven sıfıra yaklaşır. |

---

## 4. TIMELINE OLAYLARININ SENSÖR BAZLI HEDEFLEMESİ (TARGETING)

Şu ana kadar Timeline üzerindeki `SensorCutoff` ve `SpecialConditionNoise` olayları ayrım yapmaksızın tüm sensörleri etkiliyordu. Yeni yapı ile her olay için bir **Hedef Sensör (`TargetSensor`)** seçilebilecektir:

* `TargetSensor.All` (Tüm Sensörler)
* `TargetSensor.Accelerometer` (Sadece İvmeölçer)
* `TargetSensor.Barometer` (Sadece Barometre)
* `TargetSensor.Temperature` (Sadece Sıcaklık Sensörü)

Bu sayede örneğin simülasyonun 10. ile 15. saniyeleri arasında *Sadece Sıcaklık Sensörü* kesildiğinde barometrenin ve Kalman Kestirim Çekirdeğinin nasıl akıllıca yedeklemeye geçtiği (`Fallback`) ve güven katsayısının nasıl makul bir seviyede tutulduğu hem grafiklerde hem de loglarda analiz edilebilecektir.

---

## 5. GRAFİK VE VERİ ENTEGRASYONU

Simülasyon tamamlandığında veya canlı akarken, `TimelineSimulationEngine` her frame için `EstimationCoreEngine.Step(...)` metodunu çağırır ve şu yeni çıktıları `TimelineSimulationFrame` yapısına ekler:

1. `EstimatedPosition` (Kalman Tahmini İrtifa - Metre) $\to$ **Konum-Zaman Grafiğinde (`posCharts`) yeşil/altın renginde kalın bir katman olarak çizilir.**
2. `EstimatedVelocity` (Kalman Tahmini Hız - m/s) $\to$ **Hız-Zaman Grafiğinde (`velCharts`) çizilir.**
3. `EstimatedAcceleration` (Kalman Tahmini İvme - m/s²) $\to$ **İvme-Zaman Grafiğinde (`accCharts`) çizilir.**
4. `ConfidenceScore` (Genel Kestirim Güven Katsayısı - % 0..100) $\to$ **`TimelineStudioSubPanel` üstbilgisinde yeşil/sarı bar olarak çizilir.**
5. `BaroConfidenceScore` (Barometre + Sıcaklık Zinciri Güveni - % 0..100) $\to$ **`TimelineStudioSubPanel` üstbilgisinde mavi bar olarak çizilir.**
6. `AccConfidenceScore` (İvmeölçer Güveni - % 0..100) $\to$ **`TimelineStudioSubPanel` üstbilgisinde sarı/turuncu bar olarak çizilir.**

---

## 6. BAROMETRE FİZİKSEL DÖNÜŞÜMÜ, BMP580 DATASHEET ANALİZİ VE 3'LÜ GÜVEN BARLARI

### 6.1. Barometrik Basınç ve İrtifa Eşdeğeri (`[m]`) İlişkisi
Barometrik sensörler doğrudan metre ölçmez; ortam basıncını ($P$, Pascal veya hPa) ve iç termal zemin sıcaklığını ($T$) ölçer. 
Uluslararası Standart Atmosfer (ISA) hidrostatik denge bağıntısına göre deniz seviyesine yakın konumlarda:
$$\Delta P \approx -\rho \cdot g \cdot \Delta h \implies 1 \text{ metre irtifa artışı } \approx 11.77 - 12.0 \text{ Pa basınç düşüşü}$$

Bu nedenle RaSAT SIM & FlyingAnalysis arayüzünde (`Sayfa 1 - Hata Enjeksiyonu ve Kalibrasyon`) kullanıcı dostu olması amacıyla girdiğiniz tüm Barometre sapma ve gürültü değerleri **İrtifa Eşdeğeri Metre (`[m]`)** birimindedir. Arka planda simülasyon motoru bu metre gürültüsünü önce ortam basıncına ($Pa$) çevirip, sıcaklık sensöründen gelen verille birlikte tekrar hidrostatik dönüşümden geçirerek gerçekçi sensör davranışı üretir (`Barometre (İrtifa Eşdeğeri [m])`).

### 6.2. Modern MEMS Barometre (Örn. BMP580) Datasheet Değerlerinin Eşdeğeri
* **Mutlak Doğruluk (Absolute Accuracy / Statik Offset):** Geniş aralıkta tipik $\pm 30 - 50 \text{ Pa}$.
  * İrtifa Eşdeğeri: $\frac{30..50 \text{ Pa}}{11.77 \text{ Pa/m}} \approx \mathbf{2.5 \text{ m} - 4.2 \text{ m}}$
* **Lehimleme Kayması (Solder Drift):** $\pm 0.3 \text{ hPa} = \pm 30 \text{ Pa}$.
  * İrtifa Eşdeğeri: $\approx \mathbf{2.5 \text{ m}}$
  * *Tavsiye Edilen `Sabit Sapma (Bias)`:* Eğer uçuş öncesi yerde sıfırlama kalibrasyonu yapılmazsa, mutlak hata + lehimleme kayması toplamı için **`BaroBiasMeter = 3.0 m - 4.0 m`** verilmesi fiziksel olarak tam doğru olacaktır (Sistem varsayılanımız: `3.5 m`).
* **Bağıl Doğruluk (Relative Accuracy / RMS Noise):** Kısa mesafeli yükseklik değişimlerinde $\pm 6 \text{ Pa}$.
  * İrtifa Eşdeğeri: $\approx \mathbf{0.5 \text{ m}}$
  * *Tavsiye Edilen `Standart Sapma (\sigma)`:* Uçuş anındaki rüzgar dinamik basıncı ve türbülansla birlikte **`BaroSigmaMeter = 0.5 m - 0.8 m`** aralığı en gerçekçi sonucu verir (Sistem varsayılanımız: `0.8 m`).
* **Sıcaklık Kayması (Temperature-Induced Offset):** $\pm 0.5 \text{ Pa/K}$.
  * $30^\circ\text{C}$'lik bir termal şokta dahi $\pm 15 \text{ Pa} (\approx 1.25 \text{ m})$ kayma oluşturur. Bu da dahili kompanzasyon ve `BaroScaleError = 0.005 (%0.5)` parametresi ile mükemmel simüle edilir.

### 6.3. Üçlü Dinamik Güven Katsayısı (3-Bar Confidence UI)
Kestirim çekirdeğinin o an hangi sensör beslemesine güvendiğini izlemek için `TimelineStudioSubPanel` üst menüsüne 3 ayrı canlı gösterge yerleştirilmiştir:
1. **Genel Kestirim (EKF) Güveni (`🟢/🟡/🔴`):** İki sensör zincirinin kovaryans ağırlıklı toplamı ve kör uçuş (`Dead Reckoning`) sürüklenme performansı.
2. **Baro + Sıcaklık (İrtifa) Güveni (`🔵/🟡/🔴`):** Doğrudan basınç ve sıcaklık sensörünün sağlığı. Sıcaklık sensörü kesildiğinde (`Cutoff`), barometrenin hidrostatik basınç-irtifa dönüşümü etkileneceğinden bu bar otomatik olarak ceza yer (`EstTempCutoffPenalty`).
3. **İvmeölçer (IMU) Güveni (`⚡/🟡/🔴`):** İvmeölçerin kesinti veya aşırı titreşim/şok gürültüsü durumu. Barometre kesikken ivmeölçer %100 sağlamsa, roket çift integrasyonla ataletsel tahmine devam eder.
