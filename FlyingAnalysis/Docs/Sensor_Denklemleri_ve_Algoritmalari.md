# RaSAT SIM & FlyingAnalysis - Sensör Denklemleri, Hata Modelleri ve Kalibrasyon Algoritmaları

Bu doküman, `SensorSettingsSubPanel` modülünde kullanılan matematiksel modelleri, hata simülasyon denklemlerini, kalibrasyon algoritmalarını ve görselleştirme matrislerini detaylı olarak açıklamaktadır.

---

## 1. Ham Sensör Ölçümü Üretim Denklemi (Forward Sensor Error Model)

Bir sensörün gerçek fiziksel büyüklüğü ($x_{\text{true}}$) algılarken maruz kaldığı sistemik hatalar ve rastlantısal gürültü matematiksel olarak aşağıdaki tam denklem ile ifade edilir:

$$y_{\text{raw}}(i) = x_{\text{true}} \cdot (1 + S) + b + n_{\text{thermal}}(i) + n_{\text{rel}}(i) + n_{\text{spike}}(i) + n_{\text{burst}}(i)$$

### Bileşenlerin Tanımları:
1. **Gerçek Değer ($x_{\text{true}}$):** Sensörün ölçmesi gereken ideal referans büyüklük (Örn: 500 metre irtifa).
2. **Bağıl Ölçek Hatası / Scale Error ($S$):** Sensörün kazanç (gain) hatasıdır. Yüzde olarak girilir ($S_{\%}$) ve katsayıya dönüştürülür:
   $$S = \frac{S_{\%}}{100}$$
   Örneğin %2'lik ölçek hatası varsa, 500 m referans değer sadece bu hata nedeniyle $500 \cdot 1.02 = 510$ m olarak okunur.
3. **Mutlak Sabit Sapma / Bias ($b$):** Ölçüm değerinden bağımsız olarak tüm okumalara sabit eklenen sıfır noktası kayması (offset) hatasıdır. Birimi sensör birimiyle aynıdır.
4. **Sabit Termal Gürültü ($n_{\text{thermal}}$):** Sıcaklık ve elektronik bileşenlerden kaynaklanan beyaz gürültüdür. Sıfır ortalamalı ve sabit $\sigma_{\text{sabit}}$ standart sapmalı normal dağılıma sahiptir:
   $$n_{\text{thermal}}(i) \sim \mathcal{N}(0, \sigma_{\text{sabit}}^2)$$
5. **Bağıl Termal Gürültü ($n_{\text{rel}}$):** Sensörün çalışma aralığına (Full Scale Span, $\Delta FS = \text{Range}_{\text{max}} - \text{Range}_{\text{min}}$) bağlı olarak ölçeklenen normal dağılımlı gürültüdür:
   $$\sigma_{\text{bağıl}} = \frac{P_{\text{rel}} \cdot \Delta FS}{100}, \quad n_{\text{rel}}(i) \sim \mathcal{N}(0, \sigma_{\text{bağıl}}^2)$$
6. **Darbe / Sıçrama Gürültüsü ($n_{\text{spike}}$):** Nadiren görülen, anlık elektriksel sıçrama veya veri paket bozulmasıdır. Her $i$ adımında $P_{\text{spike}}$ olasılıkla tetiklenir:
   $$n_{\text{spike}}(i) = \begin{cases} \pm A_{\text{spike}}, & \text{Eğer } U(0,100) < P_{\text{spike}} \\ 0, & \text{Diğer durumlarda} \end{cases}$$
7. **Ayrılma / Faz Gürültüsü ($n_{\text{burst}}$):** Roket/Uydu sistemlerinde kademe ayrılması (separation phase) veya aerodinamik şok anlarında sensörlerin geçici olarak maruz kaldığı yüksek frekanslı titreşim patlamasıdır. Zaman serisinin %25 ile %35 arasındaki adımlarında aktifleşir:
   $$n_{\text{burst}}(i) = \begin{cases} \mathcal{N}(0, \sigma_{\text{burst}}^2), & \text{Eğer } 0.25 \le \frac{i}{N} \le 0.35 \\ 0, & \text{Diğer durumlarda} \end{cases}$$

---

## 2. Normal Dağılımlı Rastgele Sayı Üretimi (Box-Muller Dönüşümü)

Yazılımda standart normal dağılıma ($Z \sim \mathcal{N}(0, 1)$) sahip sayıları üretmek için bilgisayarın düzgün dağılımlı ($U(0, 1]$) rastgele sayı üretecinden yararlanan **Box-Muller Dönüşümü** kullanılır:

$$Z = \sqrt{-2 \ln(u_1)} \cdot \cos(2\pi u_2)$$

Burada $u_1$ ve $u_2$, $(0, 1]$ aralığından çekilen iki bağımsız rastgele sayıdır. Herhangi bir ortalama ($\mu$) ve standart sapmaya ($\sigma$) sahip gürültü değeri elde etmek için doğrusal dönüşüm uygulanır:

$$X = \mu + \sigma \cdot Z$$

---

## 3. İki Noktadan Kalibrasyon Parametreleri Hesaplama Algoritması (Two-Point Calibration)

Sensörün sistematik hatalarını ($S_{\%}$ ve $b$) bulmak için bilinen iki referans noktasına ($x_{\text{ref1}}$ ve $x_{\text{ref2}}$) karşılık gelen ölçüm kümeleri ($Y_1$ ve $Y_2$) analiz edilir.

1. **Ortalamaların Çıkartılması:**
   $$\bar{y}_1 = \frac{1}{N_1} \sum_{i=1}^{N_1} y_{1,i}, \quad \bar{y}_2 = \frac{1}{N_2} \sum_{i=1}^{N_2} y_{2,i}$$
2. **Eğim (Slope / Kazanç) Hesaplaması:**
   $$m = \frac{\bar{y}_2 - \bar{y}_1}{x_{\text{ref2}} - x_{\text{ref1}}}$$
3. **Hesaplanan Bağıl Ölçek Hatası Yüzdesi ($S_{\%\text{calc}}$):**
   $$S_{\%\text{calc}} = (m - 1) \cdot 100$$
4. **Hesaplanan Mutlak Sapma / Bias ($b_{\text{calc}}$):**
   $$b_{\text{calc}} = \bar{y}_1 - m \cdot x_{\text{ref1}}$$

---

## 4. Aykırı Değer Ayıklama Algoritması (3-Sigma Outlier Rejection)

Kalibrasyon hesaplanırken darbe gürültülerinin ($n_{\text{spike}}$) hesaplanan ortalamayı bozmasını engellemek için **$3\sigma$ Kuralı** ile filtreleme yapılır. Bir örneklem kümesi için ortalama $\mu$ ve standart sapma $\sigma$ hesaplandıktan sonra:

$$|y_i - \mu| > 3\sigma$$

koşulunu sağlayan veriler analize dahil edilmez. Bu sayede kalibrasyon parametreleri yalnızca sistematik ve termal davranışları yansıtır.

---

## 5. Ters Kalibrasyon Dönüşümü (Inverse Calibration / Compensation)

Sensör sahadan ham veri ($y_{\text{raw}}$) okuduğunda, daha önce hesaplanan kalibrasyon parametreleri ($b_{\text{calc}}$ ve $S_{\%\text{calc}}$) kullanılarak **tersine çıkarma** işlemi yapılır ve kalibre edilmiş / düzeltilmiş gerçek büyüklük kestirimi ($\hat{x}$) elde edilir:

$$\hat{x} = \frac{y_{\text{raw}} - b_{\text{calc}}}{1 + \frac{S_{\%\text{calc}}}{100}}$$

Bu işlem, bias offsetini sıfırlar ve ölçek çarpanını 1.0'a geri çeker. Matematiksel olarak beklenti değeri $E[\hat{x}] = x_{\text{true}}$ haline gelir; ancak termal gürültü standart sapması ($\sigma$) rastlantısal olduğu için korunur.

---

## 6. Dağılım Grafiği (Histogram ve Gauss Çift Çan Eğrisi) Matematiksel Yapısı

Sayfa 2'deki alt grafikte hem ham verinin hem de kalibre edilmiş verinin frekans dağılımı ile kuramsal normal dağılım eğrisi aynı tuvalde çizilir.

### A. Dilim (Bin) Genişliği ve Aralık Belirleme:
- Veri setindeki minimum ve maksimum değerler bulunarak kenarlara %15 görsel pay eklenir:
  $$\text{Span} = \text{Max}_{\text{genişletilmiş}} - \text{Min}_{\text{genişletilmiş}}$$
- Dilim Sayısı ($K$): Kullanıcının arayüzdeki `trkBinCount` sürgüsünden belirlediği adet (Örn: $K = 36$).
- Dilim Genişliği ($w_{\text{bin}}$):
  $$w_{\text{bin}} = \frac{\text{Span}}{K}$$

### B. Dikdörtgen Çubuğun Yüksekliği (Bin Count & Pixel Height Transformation):
Her bir verinin hangi dilime ($k$) düşeceği şu formülle hesaplanır:
$$k = \left\lfloor \frac{v - \text{Min}}{w_{\text{bin}}} \right\rfloor \quad (0 \le k < K)$$
- Dilime düşen eleman sayısı (Frekans): $C_k$
- Çizim tuvalindeki maksimum çubuk boyuna ($H_{\text{plot}}$) ölçeklendirmek için en yüksek frekansa ($C_{\text{max}} = \max(C_k)$) bölünür:
  $$h_{\text{piksel}}(k) = \frac{C_k}{C_{\text{max}}} \cdot H_{\text{plot}}$$

### C. Kuramsal Gauss Çift Çan Eğrisi (Probability Density Function - PDF):
Veri setinin ampirik ortalaması ($\mu$) ve standart sapması ($\sigma$) kullanılarak sürekli Olasılık Yoğunluk Fonksiyonu (PDF) hesaplanır:

$$f(x) = \frac{1}{\sigma \sqrt{2\pi}} \exp\left( -\frac{(x - \mu)^2}{2\sigma^2} \right)$$

Grafik üzerindeki teorik beklenen frekans boyu ($E[C(x)]$) ve piksel yüksekliği:
$$E[C(x)] = f(x) \cdot N \cdot w_{\text{bin}}$$
$$y_{\text{eğri\_piksel}}(x) = H_{\text{plot}} - \left( \frac{E[C(x)]}{C_{\text{max}}} \cdot H_{\text{plot}} \right)$$

Bu sayede çizilen çan eğrisinin tepe noktası ve alanı, altındaki histogram çubuklarıyla tam olarak matematiksel uyum (normalization match) gösterir.
