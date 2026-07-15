# FlyingAnalysis - Sistem Girdileri (INPUT) ve Ayar Dashboard Tasarım Şartnamesi

Bu doküman, RaSAT / TÜRKSAT Model Uydu Yarışması (`MUY`) teknik verilerine dayanan fiziksel parametreleri, paraşüt referans alanlarını, motor/itki denklemlerini ve Ayarlar Dashboard'unda (`SimulationConfigPanel`) yer alacak **8 alt panelin kesin girdi (INPUT) listesini** içerir. 
İlerleyen aşamalarda UI ve Backend geliştirilirken **kafa karışıklığını önlemek** amacıyla ana referans belgesi olarak kullanılacaktır.

---

## 1. Matematiksel & Fiziksel Temel Denklemler

### A. Limit Hız Denklemi (Paraşütlü & Paraşütsüz Süzülüş)
Serbest düşüş sonrasında ağırlık kuvvetinin ($F_g = mg$) aerodinamik sürtünme kuvvetine ($F_d = \frac{1}{2} \rho v^2 C_d A$) eşitlendiği andaki sabit limit hız:
$$v = \sqrt{\frac{2mg}{\rho C_d A}}$$

### B. Motor İtki ve RPM Denklemi (EMAX ECO II 2306 - 5" Pervane)
- **İtki Katsayısı ($k$):** $1.5 \times 10^{-8} \text{ N/RPM}^2$
- **Gereken Motor Devri:** $\text{RPM} = \sqrt{\frac{T_m}{k}}$ *(Burada $T_m$, tek bir motor başına düşen itki kuvvetidir, $T_{\text{toplam}}/4$)*

---

## 2. Ayarlar Dashboard'u - 8 Alt Panel Girdi (INPUT) Listesi

### Panel 1: 🌍 Dünya Değişkenleri (Çevresel Koşullar)
| Parametre | Varsayılan Değer | Birim | Açıklama |
| :--- | :--- | :--- | :--- |
| **Yerçekimi İvmesi ($g$)** | `9.81` | $\text{m/s}^2$ | Sabit kabul edilen dünya yerçekimi. |
| **Hava Yoğunluğu ($\rho$)** | `1.10` | $\text{kg/m}^3$ | Aksaray rakımı (~900m) için standart $1.225$ yerine alınan gerçekçi değer. |
| **Sürüklenme Katsayısı ($C_d$)** | `1.50` | Boyutsuz | Çapraz (Cruciform) paraşüt tasarımı ve kumaş direnci varsayımı. |
| **Deniz Seviyesi Sıcaklığı ($T_0$)** | `15.0` | $^\circ\text{C}$ | Barometrik irtifa hesaplamalarında referans sıcaklık ($288.15\text{ K}$). |
| **Test Bölgesi Rakımı** | `900` | Metre | Simülasyon başlangıç rakımı. |

---

### Panel 2: 🛰️ Uydunun Fiziksel ve Paraşüt Özellikleri (Kütle, Alan & Motor)
| Parametre | Varsayılan Değer | Birim | Açıklama |
| :--- | :--- | :--- | :--- |
| **Görev Yükü Kütlesi ($m_{\text{görev}}$)** | `1250` (`1.25`) | $\text{g}$ ($\text{kg}$) | Ağırlık kuvveti: $W = 1250 \times 9.81 = 12.26\text{ N}$. |
| **Taşıyıcı Kütlesi ($m_{\text{taşıyıcı}}$)** | `550` (`0.55`) | $\text{g}$ ($\text{kg}$) | Ayrılma sonrası tek başına inen gövde kütlesi. |
| **Toplam Kütle ($m_{\text{toplam}}$)** | `1800` (`1.80`) | $\text{g}$ ($\text{kg}$) | **[Otomatik Hesap]** $m_{\text{görev}} + m_{\text{taşıyıcı}}$. |
| **Ana Paraşüt Çapı ($D_{\text{ana}}$)** | `40` | $\text{cm}$ | Ayrılma öncesi ve taşıyıcı inişinde kullanılan paraşüt. |
| **Ana Paraşüt Referans Alanı ($A_{\text{ana}}$)** | `0.1256` | $\text{m}^2$ | **[Otomatik/Girdi]** $\pi \times (0.2)^2$. |
| **APAM Paraşüt Çapı ($D_{\text{apam}}$)** | `80` | $\text{cm}$ | Alternatif / büyük paraşüt sistemi. |
| **APAM Referans Alanı ($A_{\text{apam}}$)** | `0.5026` | $\text{m}^2$ | **[Otomatik/Girdi]** $\pi \times (0.4)^2$. |
| **Motor Sayısı** | `4` | Adet | EMAX ECO II 2306 fırçasız motor konfigürasyonu. |
| **Pervane İtki Katsayısı ($k$)** | `1.5e-08` | $\text{N/RPM}^2$ | 5 inç 2-bıçaklı pervane ampirik katsayısı. |

---

### Panel 3: 🚀 Faz 1 - Yükseliş ve Ayrılma Öncesi Süzülüş (Taşıyıcı + Görev Yükü)
- **Aktif Kütle:** `1.8 kg` ($m_{\text{toplam}}$)
- **Aktif Paraşüt Referans Alanı:** `0.1256 m²` ($A_{\text{ana}}$)
- **Otomatik Beklenen Limit Hız ($v_1$):** **`13.05 m/s`** $\left(v_1 = \sqrt{\frac{2 \times 1.8 \times 9.81}{1.1 \times 1.5 \times 0.1256}}\right)$
- *Girdiler:* Başlangıç İrtifası (`400m`), Başlangıç Dikey Hız (`0 m/s`), Simüle Edilecek Rüzgar Gürültüsü.

---

### Panel 4: ✨ Faz 2 - SİGMA Ayrılma Mekanizması & Taşıyıcı İnişi
- **SİGMA Tetikleme Koşulu:** İrtifa $\le$ `400m` veya Tepe Noktası (Apogee) + `1.0 saniye` gecikme.
- **Ayrılma Sonrası Taşıyıcı Kütlesi:** `0.55 kg`
- **Taşıyıcı Limit Hız Hedefi ($v_2$):** **`7.21 m/s`** $\left(v_2 = \sqrt{\frac{2 \times 0.55 \times 9.81}{1.1 \times 1.5 \times 0.1256}}\right)$
- *Girdiler:* SİGMA mekanizması tetikleme gecikme süresi (`0.0 - 5.0 saniye`), Ayrılma anındaki itme/ayrılma darbe hızı.

---

### Panel 5: 🪂 Faz 3 - Görev Yükü Frenleme Fazı (8 m/s Hızın Sıfırlanması / Yavaşlatılması)
- **Frenleme Başlama İrtifası:** `200 metre`
- **Serbest Düşüş Giriş Hızı:** `8.0 m/s`
- **Hedef Frenleme Süresi:** `2.0 saniye` (Mekanik bileşenleri zorlamayacak sarsıntısı yavaşlama)
- **Hedef İvme ($a$):** `4.0 m/s²` ($8 / 2 = 4$)
- **Gereken Toplam İtki ($T$):** **`17.26 N`** ($m_{\text{görev}} \cdot (g + a) = 1.25 \cdot (9.81 + 4)$)
- **Motor Başına İtki ($T_m$):** `4.31 N` (~`440 gram`)
- **Hedef Motor Devri:** **`~16.950 RPM`** $\left(\sqrt{\frac{4.31}{1.5 \times 10^{-8}}}\right)$

---

### Panel 6: ☂️ Faz 4 - Kontrollü İniş Fazı (200m - 50m Arası Geçiş)
- **İrtifa Aralığı:** `200m` - `50m` (150 metrelik kontrollü süzülüş)
- **Hedef Sabit Alçalma Hızı:** `4.0 m/s`
- **Sistem Toplam İtkisi:** `12.19 N`
- **Motor Başına İtki ($T_m$):** `310 gram`
- **Hedef Motor Devri:** **`~14.236 RPM`**

---

### Panel 7: 🏁 Faz 5 - Güvenli ve Sabit Hızlı İniş & Hover (Son 50 Metre)
- **İrtifa Aralığı:** `50m` - `0m` (Yere Temas)
- **Dinamik Durum:** Hız sabit ($v = 4.0\text{ m/s}$), İvme sıfır ($a = 0\text{ m/s}^2$).
- **Hover / Askıda Kalma Toplam İtkisi ($T$):** **`12.26 N`** ($1250\text{ gram-kuvvet}$, sistem ağırlığına eşit)
- **Motor Başına İtki ($T_m$):** `312.5 gram`
- **Hover Motor Devri & Gaz Aralığı:** **`14.282 RPM`** (Ortalama `13.000 - 14.000 RPM`, `%40 - %45 PWM`)

---

### Panel 8: ⚠️ Faz 6 - Hata Enjeksiyonu ve Tolerans Test Senaryoları (Contingency)
- **Sensör & Mekanik Hata Senaryoları:**
  - `[Checkbox]` Barometre gürültüsünü 5 katına çıkar (Gauss gürültüsü $\sigma = 2.5\text{ m}$).
  - `[Checkbox]` SİGMA ayrılma pimi sıkışması (Ayrılmayı 3 saniye geciktir).
  - `[Checkbox]` Paraşüt kısmi açılma / kumaş yırtılması ($C_d$ değerini `1.5` yerine `1.0` yap).
  - `[Checkbox]` Motorlardan birinin (%25 güç kaybı) arızalanması senaryosu.
