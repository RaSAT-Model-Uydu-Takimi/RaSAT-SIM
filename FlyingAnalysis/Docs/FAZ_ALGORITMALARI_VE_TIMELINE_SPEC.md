# RaSAT SIM & FlyingAnalysis — Faz Algoritmaları ve Akış Şeması Şartnamesi

Bu doküman, model uydumuzun yükseliş, pasif iniş, ayrılma ve aktif iniş fazlarındaki fiziksel davranışlarını, karar döngülerini (Loop) ve sızdıran kova (Leaky Bucket) kullanım koşullarını tanımlar.

---

## 1. Yüzey Alanı Geçiş Kuralı (Doğrusal Geçiş / Linear Transition)
* **Kritik Kural:** Bir paraşüt veya aerodinamik yüzey açıldığında/değiştiğinde referans yüzey alanı asla **0 m²'den başlamaz**.
* **Doğrusal Geçiş (Linear Transition):** Paraşüt açılma anında (`t_start`), uydunun mevcut aerodinamik yüzey alanından (`A_mevcut`) hedef yüzey alanına (`A_hedef` / örneğin `A_sigma` veya `A_apam`) belirlenen şişme/açılma süresi (`t_şişme`) boyunca **doğrusal (linear) olarak artar**.
* Formül:
  ```
  A(t) = A_mevcut + (A_hedef - A_mevcut) * ((t - t_start) / t_şişme)   [0 <= (t - t_start) <= t_şişme için]
  ```

---

## 2. Faz ve Komut Blokları Detayları

### Faz 1: Yükselme Hali (Roket ile Taşıma)
* Roket içerisinde kapalı mekanda yükseliş gerçekleştirilir.
* İrtifa işlenmiş verisi yerine roketin sağladığı veya girilen sabit/profil hız (`v_roket`) ve maruz kalınacak süre (`t_roket`) üzerinden konum hesaplanır.
* **Geçiş Algoritması:** Sızdıran Kova (Leaky Bucket) kullanılarak roketten ayrılma anı gürültüsüz tespit edilir.

### Faz 2: Pasif İniş Hali (`S2 Komut Blokları`)
* Yükselme halinden sonra ayrılma haline kadar kayda değer bir aktif görev yapılmaz.
* **Komut Bloğu 1:** `Pasif İniş Sistemini Aktif Et`
  - Pasif iniş takımlarını aktif eder. (İleride taşıyıcı paraşütünün bir tetikleyici ile açılacağı bir sistem tasarlanma ihtimaline karşı modüler tutulmuştur).
* **Şart Bloğu:** `Ayrılmalı Mı? (Separation Trigger Condition)`
  - Ayrılma yüksekliğine gelinip gelinmediğini (Örn: `h <= 200m`) veya yer istasyonundan ayrılma komutu alınıp alınmadığını denetleyen döngü bloğudur.
* **Sızdıran Kova:** SİGMA ayrılma kararının gürültüden etkilenmemesi için `SigmaLeakyBucket` burada çalışır.

### Faz 3: Ayrılma Hali (`S3 Komut Blokları`)
* Pasif iniş halinde iken ayrılma şartı sağlandığında model uydu ayrılma haline geçer.
* Model uydu, taşıyıcı ile görev yükü birbirinden tamamen ayrılıp görev yükü güvenle aktif iniş takımlarını (`SİGMA`) açabileceği pozisyona gelene kadar ayrılma halinde kalır.
* **Sızdıran Kova:** **YOKTUR!** (Karar zaten Faz 2'de kesinleşmiştir).
* **Komut Bloğu 1:** `Taşıyıcı ile Görev Yükünü Ayır` (Mekanik/Piroteknik tetikleyici komutu).
* **Şart Bloğu (Döngü):** `Ayrıldı Mı? (Separation Check Loop)`
  - Ayrılmanın sağlıklı tamamlandığını denetleyen, sürekli sorgulayan (`Ayrıldı mı? -> Hayırsa tekrar sor, Evetse çık`) kontrol bloğudur.
  - Parametreler: `Zaman Aşımı / Timeout [sn]`, `Ayrılma Eşiği [cm]`, `Sorgulama Frekansı [Hz]`.
* **Komut Bloğu 2:** `SİGMA Takımlarını Aç`
  - Ayrılma tamamlandıktan sonra SİGMA takımlarını açarak görev yükünü aktif iniş haline hazırlar.
  - Yüzey alanı, `A_taşıyıcı` veya `A_kanat` alanından `A_sigma` alanına doğrusal olarak geçiş yapar.

### Faz 4: Aktif İniş Hali (`S4 Komut Blokları` - Yere İniş Ana Döngüsü)
* Diğer hallerden farklı olarak komutların çoğu **tek bir ana döngü içinde** çalıştırılır ve bu döngü görev yükü yere inene kadar (`FallingStop`) sürer.
* **Faz 4 Alt Fazları (4'e Bölünmüş Kademeli PID Mimarisi):**
  1. **Faz 4.1 - Süzülme Anı 1:** 200m irtifaya kadar PID ile kontrollü hız (`-8 m/s`) ve konum yaklaşması.
  2. **Faz 4.2 - Askıda Kalma Anı (`BONUS-1 Bloğu`):** `h = 200m` civarında havada `10 saniye` asılı kalma (`Hover`). Hedef Hız: `0.0 m/s`.
  3. **Faz 4.3 - Süzülme Anı 2:** Hover sonrası alt irtifaya (Örn: `5m`) doğru yumuşak iniş (`-2 m/s`) PID kontrolü.
  4. **Faz 4.4 - Yere İniş Anı (Touchdown):** Son `5m` mesafede çok yumuşak temas (`-0.5 m/s`) ve yere değdiğinde motor kesme (`Cut-off`).
* **Her Alt Faz İçin Girdiler:** Hedef Konum `[m]`, Hedef Hız `[m/s]`, Hız ve Konum PID Katsayıları (`Kp, Ki, Kd`).
* **`APAM Algoritması` (Acil Durum Koruma Bloğu):**
  - Görev yükü hızı **16 m/s** hızı aştığında VEYA yer istasyonundan (Hakem) **Acil Durum Mesajı** geldiğinde aktif iniş takımlarını (motorları) devre dışı bırakıp acil durum paraşütü (`APAM`) açılmasını sağlar.
  - APAM açıldığında SİGMA kontrol bloğu, Bonus-1 bloğu ve Yere İniş Kontrol bloğu devre dışı kalır.
* **`BONUS - 2 Bloğu` (IoT Telekomut):** Gelen telekomutun okunması ve IoT istasyonuna iletilmesi.
* **`FallingStop` (Şart Bloğu):** Görev yükü yere indi mi? (`İrtifa <= 0` ve darbe algılandı mı?). İndiyse döngüyü sonlandır, inmediyse döngü başa (`SİGMA Kontrol Bloğu`na) döner.

---

## 3. Kanat ve Gövde Aerodinamiği (`SatellitePhysicsSubPanel` Eklemesi)
* Uydunun havada süzülürken veya serbest düşüşteyken maruz kaldığı sürtünme kuvveti (`F_drag`) için kanat/gövde referans alanları kullanılır.
* Parametreler: `A_kanat_kapalı [m²]`, `A_kanat_açık [m²]`, `Cd_gövde`.
