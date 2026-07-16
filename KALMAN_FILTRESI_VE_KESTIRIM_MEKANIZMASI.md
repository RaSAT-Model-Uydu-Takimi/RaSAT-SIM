# Kalman Filtresi ve Kestirim Çekirdeği Mekanizması

Bu doküman, RaSAT SIM simülasyon platformunda (`FlyingAnalysis/Services/EstimationCoreEngine.cs`) ve model uydu üzerindeki gömülü yazılımda (`SensorAnalizi/STM32_C_Code`) kullanılan Gelişmiş Kalman Filtresinin (EKF) matematiksel temelini ve çalışma mantığını açıklamaktadır.

---

## 1. Kalman Filtresi Kodlarının Projedeki Konumu

1. **Simülasyon Çekirdeği (C#):**
   * Konum: `m:\Godot\Projeler\RaSAT SIM\FlyingAnalysis\Services\EstimationCoreEngine.cs`
   * İşlev: 3x3 Durum Vektörü ([z, v, a]^T) üzerinde zaman ve ölçüm güncellemeleri, sensör kesinti koruması ve dinamik güven (confidence) katsayıları hesaplamalarını yürütür.

2. **Gömülü Mikrodenetleyici Kodu (C/C++):**
   * Konum: `m:\Godot\Projeler\RaSAT SIM\SensorAnalizi\STM32_C_Code\`
   * İşlev: Model uydu üzerinde çalışan STM32 mikrodenetleyicisine yüklenen, donanım kaynaklarına optimize edilmiş gerçek zamanlı filtre kodlarıdır.

---

## 2. Durum Vektörü ve Sistem Matrisleri

Model uydunun düşüş dinamiği tek boyutlu dikey eksende (z ekseni) kinematik olarak modellenir. Durum vektörü (X) 3 değişkenden oluşur:

```
X = [ z ] -> İrtifa (Konum, m)
    [ v ] -> Dikey Hız (m/s)
    [ a ] -> Dikey İvme (m/s²)
```

### Zaman Düzeltme (Prediction / Time Update) Matrisi (F)
İki zaman adımı (dt) arasında sistemin eylemsizlik kanunlarına göre geçişini tanımlar:

```
    [ 1   dt   0.5 * dt² ]
F = [ 0   1       dt     ]
    [ 0   0        1     ]
```

Tahmin edilen yeni durum (`X_pred = F * X`) ile birlikte, sistemin belirsizliğini temsil eden kovaryans matrisi (`P`) süreç gürültüsü (`Q`) eklenerek güncellenir:

```
P_pred = F * P * F^T + Q
```

* **Süreç Gürültüsü Matrisi (Q):** Atmosferik türbülans, rüzgar darbeleri ve modelleme belirsizliklerini temsil eden temel parametredir (`GlobalSimulationConfig.EstProcessNoiseQBase`).

---

## 3. Ölçüm Güncellemesi (Measurement Update / Correction)

Sistem tahmin adımını tamamladıktan sonra sensörlerden gelen gerçek ölçümlerle (`CalibratedBaroPosition` ve `CalibratedAcceleration`) düzeltilir.

### Barometre Güncellemesi (İrtifa Ölçümü)
Barometre sadece konumu (z) ölçtüğü için ölçüm matrisi `H_baro = [1, 0, 0]` şeklindedir.

1. **Yenilik (Innovation / Residual):**
   ```
   y_baro = CalibratedBaroPosition - z_pred
   ```
2. **Yenilik Kovaryansı (S) ve Kalman Kazancı (K):**
   ```
   S = P[0,0] + R_baro
   K = P_pred * H_baro^T / S
   ```
   * **R_baro:** Barometrenin ölçüm gürültü varyansıdır (`EstBaroNoiseRBase`).
3. **Durum ve Kovaryans Düzeltmesi:**
   ```
   X = X_pred + K * y_baro
   P = (I - K * H_baro) * P_pred
   ```

### İvmeölçer Güncellemesi (İvme Ölçümü)
İvmeölçer sadece ivmeyi (a) ölçtüğü için ölçüm matrisi `H_acc = [0, 0, 1]` şeklindedir. Benzer şekilde Kalman Kazancı (`K_acc`) hesaplanarak durum vektöründeki ivme, hız ve konum değerleri entegre şekilde düzeltilir.

---

## 4. Sensör Kesintisi ve Arıza Koruması (Fallback Mekanizması)

`EstimationCoreEngine.cs` içinde uygulanan filtre, standart bir doğrusal Kalman filtresinden farklı olarak arızalara dayanıklı (fault-tolerant) bir yapıya sahiptir:

1. **Sensör Veri Kesintisi (Cutoff):**
   Barometreden `NaN` (geçersiz veri) geldiğinde veya `baroCutoff` bayrağı aktifleştiğinde, barometre ölçüm güncelleme adımı tamamen atlanır. Filtre, ivmeölçerden gelen eylemsizlik verilerinin çift integrali (`z = z + v*dt + 0.5*a*dt²`) ile tahmini uçuşu güvenli bir şekilde sürdürür.

2. **Sıcaklık Sensörü Kesintisi ve R Matrisi Penaltısı:**
   Barometrik basıncın irtifaya çevrilmesi sıcaklığa (`T`) bağımlıdır. Sıcaklık sensörü kesildiğinde (`tempCutoff`), sistem son geçerli sıcaklığı (`_lastValidTemp`) kullanır ve barometrenin ölçüm gürültü varyansını (`R_baro`) çarpanla (`tempPenalty = 1.15`) büyütür. Bu sayede filtrenin barometreye olan güveni azaltılıp ivmeölçere ağırlık verilir.

3. **Dinamik Güven Katsayısı (Confidence Score):**
   Her iterasyonda sensörlerin sağlık durumuna göre %0 ile %100 arasında `_baroConfidence` ve `_accConfidence` değerleri hesaplanarak arayüzde (`TimelineStudioSubPanel`) anlık olarak raporlanır.

---

## 5. Metrolojik Rolü (Neden Kalibrasyon Şarttır?)

Kalman Filtresi, matematiksel doğası gereği sıfır ortalamalı beyaz gürültüyü (Standart Sapma σ) bastırmak için optimal bir tahminleyicidir. Ancak sensörde sabit bir kayma (Bias) veya %20 ölçek hatası varsa, filtre bu kaymayı fiziksel bir gerçeklik olarak kabul eder ve hatalı ortalamaya kilitlenir.

Bu nedenle RaSAT SIM mimarisinde:
* **Statik Sensör Kalibrasyonu:** Verinin **Doğruluğunu (Trueness / Bias sönümleme)** sağlar.
* **Kalman Filtresi (EKF):** Verinin **Kesinliğini (Precision / σ bastırma)** sağlar.
