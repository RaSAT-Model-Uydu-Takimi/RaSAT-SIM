# FlyingAnalysis - Proje Çalışma Kuralları ve Prensipleri

Bu dosya, kullanıcı ile yapay zeka (AI) geliştirici arasındaki çalışma prensiplerini ve uyulması gereken zorunlu kuralları barındırır.

---

## KURAL 1: "Önce Anla ve Anlat, Onay Alınca İşe Koyul" (Pre-Approval Principle)
**Tanım:** Kullanıcı herhangi bir geliştirme, yeni panel, özellik veya değişiklik istediğinde;
1. **Kod yazmaya veya uygulamaya kesinlikle başlanmayacaktır.**
2. İlk olarak kullanıcının isteğinden **ne anlaşıldığı** ve bu isteğin **nasıl yapılacağı / nasıl görüneceği** detaylı ve net bir şekilde anlatılacaktır (görsel taslak, tel çerçeve, şema veya açıklama ile).
3. Kullanıcı tasarımı ve planı inceleyip **"Onaylıyorum / İşe koyul"** dedikten sonra kodlama/uygulama aşamasına geçilecektir.

---

## KURAL 2: "Çoklu Panel & Ayrı Designer Mimarisi" (No Monolithic Designers)
**Tanım:** Tüm arayüz bileşenleri (paneller, alt paneller, ayar sayfaları) ayrı `UserControl` dosyalarında ve her birinin kendine ait ayrı `Designer.cs` dosyasında bulunacaktır. Tek bir formda toplanıp bağlam kaybı (`context bloat`) yaratılması yasaktır.

---

## KURAL 3: "Sadece Çizim ve Planlama Fazında Backend/Kod Eklememek"
**Tanım:** UX ve tasarım aşamalarında (özellikle belirtilmediği sürece) backend, fizik motoru veya simülasyon mantığı kodu yazılmaz; sadece arayüzün nasıl duracağı ve verilerin nereden girileceği tasarlanır.

---

## KURAL 4: "Sade, Düz Renk ve Emojisiz Tasarım" (Flat & No-Emoji UI)
**Tanım:** Arayüz (`UI`) tasarımları, metin etiketleri, butonlar, başlıklar ve dokümantasyon şemaları **mümkün olduğunca sade, düz renk (Flat / Solid Color)** felsefesiyle inşa edilecektir. Arayüz elemanlarında **asla emoji kullanılmayacaktır**. Profesyonel, ciddi ve net bir mühendislik arayüzü dili benimsenecektir.

---

## KURAL 5: "Sözdizimi Koruması ve 5 Parantez Kuralı"
**Tanım:** C# Windows Forms Designer (`.Designer.cs`) dosyalarında renk atamaları yapılırken Visual Studio derleyicisinin beklediği tam 5 parantezli yapı (`System.Drawing.Color.FromArgb(((int)(((byte)(R)))), ((int)(((byte)(G)))), ((int)(((byte)(B)))))`) kesinlikle bozulmayacak, eksik parantez hatasına yol açılmayacaktır.

---

## KURAL 6: "Teorik Limit Hız, APAM Paraşütü ve Kuvvet Diyagramı Standardı"
**Tanım:** 
* **APAM (Acil Paraşüt Modu):** APAM bir alt faz atlama mekanizması değil, acil durumda açılan ekstra bir kurtarma paraşütüdür ($A_{\text{apam}}$). Ayarlar yan menüsünde bağımsız panel (`ApamSubPanel`) olarak yönetilir.
* **Limit Hız & Kuvvet Diyagramı:** Faz 2, Faz 3, Faz 4 ve APAM panellerinde uydunun o fazdaki aktif kütlesine ve aerodinamik alanına bağlı olarak aşağı çeken yerçekimi ($F_g = m \cdot g$) ve yukarı iten sürtünme ($F_d = F_g$) kuvvetleri ile **Teorik Limit Hız ($v_{\text{limit}} = \sqrt{2mg / (\rho C_d A)}$)** mutlaka gösterilecektir.
* **Faz 4 ve Faz 5 Sızdıran Kova:** Faz 4 alt faz geçişlerinde (4.1-4.4) sensör gürültüsü koruması için sızdıran kova zorunludur. Faz 5'te ise zemin temas doğrulaması, yerde kalma süresi ve iniş sertliği değerlendirmesi (İyi/Normal/Kötü) yer alacaktır.
