# 🛰️ RaSAT SIM (FlyingAnalysis) - Gelişmiş Model Uydu Metroloji, Uçuş Dinamiği ve Sensör Kestirim Platformu

[![.NET Version](https://img.shields.io/badge/.NET-8.0-512BD4?style=for-the-badge&logo=dotnet)](https://dotnet.microsoft.com/)
[![UI Framework](https://img.shields.io/badge/UI-Windows%20Forms%20%2B%20OpenTK-0078D4?style=for-the-badge)](https://github.com/opentk/opentk)
[![Status](https://img.shields.io/badge/Status-Production%20Ready-success?style=for-the-badge)]()
[![Validation](https://img.shields.io/badge/Metrological%20Validation-%3C%20%C2%B10.5m%20RMSE-00C853?style=for-the-badge)]()

**RaSAT SIM**, model uydu ve yapay uydu projelerinde (Teknofest, TÜRKSAT Model Uydu vb.) uçuş algoritmalarının, sensör hatalarının ve sensör füzyonu (Kalman Filtresi) başarımlarının hem teorik hem de deneysel olarak doğrulanması amacıyla geliştirilmiş kapsamlı bir mühendislik simülasyon ve analiz ekosistemidir.

---

## 🌟 ANA PROJE (FLAGSHIP): `FlyingAnalysis`
Ekosistemin kalbi ve amiral gemisi olan **`FlyingAnalysis`**, 4 Fazlı uçuş dinamiğini, sensör kalibrasyon matematiklerini, gelişmiş **3x3 Kalman Kestirim Çekirdeğini (EKF)** ve 3D OpenGL görselleştirme altyapısını tek bir modüler arayüzde birleştiren ana analiz laboratuvarımızdır.

### 💡 Temel İşlevi
Model uydunun roketten bırakıldığı andan yere indiği ana kadar geçirdiği tüm aerodinamik evreleri simüle eder. Sensörlerde (Barometre & İvmeölçer) meydana gelebilecek en ağır metrolojik hataları (**%20 Sistematik Bias, %20 Rastgele Beyaz Gürültü, Ani Sıçrama / Spike ve Kesintiler**) modeller ve **Gelişmiş Kalman Filtremizin (EKF)** bu hataları ne kadar süzebildiğini gerçek zamanlı olarak test eder.

### 📥 GİRDİLER (Input - Biz Ne Veriyoruz?)
* **Fiziksel ve Atmosferik Değişkenler:** Uydunun taşıyıcı ve görev yükü kütleleri ($kg$), paraşüt/kanat açık alanları ($m^2$), sürüklenme katsayısı ($C_d$) ve başlangıç atmosferik basınç/sıcaklık profili ($P_0, T_0$).
* **Sensör Metroloji ve Hata Enjeksiyonu:** Barometre ve İvmeölçer için sabit kayma (`Bias`), orantılı ölçek sapması (`Scale Error %`), beyaz gürültü standart sapması (`% FS` veya `% True Value σ`) ve ısıl kayma katsayıları.
* **Senaryo ve Olay Tetikleyicileri (`Timeline Studio`):** Belirli saniyelerde dış kuvvet darbeleri (rüzgar/türbülans), sensör kesintisi (`Sensor Cutoff`) veya özel gürültü şokları (`Special Noise`).
* **Kalman Kestirim Ayarları:** Süreç gürültü matrisi ($Q$) ve sensör ölçüm gürültü matrisi ($R$) temel katsayıları.

### 📤 ÇIKTILAR (Output - Bize Ne Sonuç Veriyor?)
* **Canlı Zaman-Konum ve Kuvvet Grafikleri:** Uydunun saniye saniye irtifa, hız, ivme değişimi ve üzerindeki net kuvvet diyagramı ($F_g, F_d, F_{\text{ext}}$).
* **3D OpenGL Görselleştirme:** Uydunun uzaydaki duruşu (Attitude) ve fiziksel hareket davranışı.
* **🏆 Metrolojik Başarı ve Kestirim Raporu:**
  * **Doğruluk İyileşmesi (% Trueness):** Statik ters kalibrasyon denkleminin sistematik bias ve ölçek hatasını yüzde kaç temizlediği.
  * **Kesinlik Süzme (% Precision / $\sigma$):** EKF Kalman filtresinin rastgele beyaz gürültü titreşimlerini yüzde kaç bastırdığı.
  * **Nihai RMSE (Karesel Ortalama Hata):** Sistemin toplam hata payı. (*Örn: %20 hatalı sensör altında EKF ve Kalibrasyon füzyonumuzun **$< \pm 0.5\text{ m}$ RMSE** payı ile iniş/ayrılma hassasiyeti sağladığının net kanıtı*).

---

## 🔗 YARDIMCI VE DESTEKLEYİCİ MODÜLLER (EKOSİSTEM)
`FlyingAnalysis` amiral gemisini destekleyen, yer sayısal tasarımından gömülü C kodlamasına ve uçuş sonrası log analizine kadar uzanan 3 yardımcı modülümüz:

```
[Sayısıal Similasyon] (Fizik & Telemetri Motoru)
         │
         ▼
[SensorAnalizi / STM32] (Gömülü C Kod Doğrulaması) ──► 【 FlyingAnalysis 】 (Amiral Gemisi / EKF Laboratuvarı)
         ▲                                                     │
         │                                                     ▼
[Veri Analizi] (Sahadaki Gerçek CSV Uçuş Logları) <────────────┘
```

### 1. 🚀 `Sayısıal Similasyon` (Sayısal Uçuş ve Telemetri Motoru)
* **💡 Temel İşlev:** Model uydunun düşüş dinamiğini ve yer istasyonuna göndereceği haberleşme paketlerini matematiksel olarak simüle eden çekirdek motor.
* **📥 GİRDİ:** Bırakılma yüksekliği (`700 m`), görev yükü ayrılma hedefi (`400 m`), telemetri periyodu (`1 Hz`) ve atmosfer verileri.
* **📤 ÇIKTI:** Zaman çizelgesine göre üretilen **Standart Telemetri Veri Paketleri dizisi** (*Paket No, İrtifa, Hız, Sıcaklık, Görev Fazı*) ve algoritmaların hangi saniyede hangi komutu tetiklediğini gösteren log dökümü.

### 2. 🛡️ `SensorAnalizi` (Sensör Arıza & Gömülü STM32 Algoritma Doğrulaması)
* **💡 Temel İşlev:** Sensör arızalarının model uydu üzerindeki algoritmaları aldatıp aldatamayacağını test eden ve gerçek **STM32 C/C++ mikrodenetleyici kodlerinin** simülasyonda doğrulandığı güvenlik modülü.
* **📥 GİRDİ:** En kötü durum (*Worst-Case*) senaryoları: Ani basınç sıçramaları (`Spike`), sensör donması, verinin sıfıra düşmesi (`Cutoff`).
* **📤 ÇIKTI:** **Hatalı Tetikleme (False-Positive) Güvenlik Raporu.** Havada anlık bir basınç şoku geldiğinde sistemin bunu yanlışlıkla *"Yere indik"* veya *"Paraşüt açılmalı"* diye algılayıp algılamadığının, yani gömülü C kodumuzun arızalara karşı direnç analizi.

### 3. 📈 `Veri Analizi` (Uçuş Sonrası CSV & Telemetri Analizörü)
* **💡 Temel İşlev:** Sahada yapılan gerçek atış/uçuş testlerinden veya simülasyonlardan elde edilen büyük log dosyalarını (`.csv`) içeri aktararak grafiğe döküp uçuşun röntgenini çeken analiz aracı.
* **📥 GİRDİ:** Uçuş sırasında kaydedilen `CSV` formatındaki binlerce satırlık ham telemetri kayıt dosyaları (*Örn: `ÖRNEK VERİ.csv`*).
* **📤 ÇIKTI:** Yakınlaştırılabilir ve filtrelebilir karşılaştırmalı uçuş grafikleri ile **Uçuş Özet Kartı** (*Paraşüt açılma anı, görev yükü ayrılma irtifası, maksimum düşüş hızı ve iniş stabilite skoru*).

---

## 📐 METROLOJİK İŞ BÖLÜMÜ KURALI (ALTIN PRENSİP)
Projemizde yapılan simülasyon ve Monte-Carlo testleri, model uydu ve otonom sistemler için şu evrensel kuralı deneysel olarak kanıtlamıştır:

> 🎯 **"Kalman Filtresi (EKF) verinin KESİNLİĞİNİ (`Precision / Standart Sapma σ`) mükemmel hale getirir, ancak verinin DOĞRULUĞUNU (`Trueness / Bias`) tek başına sağlayamaz. Sistematik hataları sıfırlamak için statik/ters sensör kalibrasyonu şarttır."**

Bu prensip doğrultusunda, **RaSAT SIM** üzerinde kalibrasyon ve EKF algoritmalarımız birlikte koşturulduğunda, sensörlerde %20 hata bulunsa dahi sistem hedeflenen ayrılma ve iniş senaryolarını **$< \pm 0.5\text{ m}$ RMSE** payı ile güvenle başarmaktadır.

---

## 🛠️ HIZLI KURULUM VE ÇALIŞTIRMA

### Gereksinimler
* [.NET 8.0 SDK](https://dotnet.microsoft.com/download/dotnet/8.0) veya üzeri.
* Visual Studio 2022 / JetBrains Rider (veya `dotnet CLI`).

### Derleme & Başlatma (`FlyingAnalysis` Amiral Gemisi)
```powershell
# Proje dizinine gidin
cd "m:\Godot\Projeler\RaSAT SIM\FlyingAnalysis"

# Bağımlılıkları geri yükleyin ve derleyin
dotnet restore
dotnet build -c Release

# Ana simülasyon ve analiz laboratuvarını başlatın
dotnet run
```

---
*Geliştirilmiş ve Doğrulanmış Model Uydu Uçuş & Metroloji Ekosistemi — RaSAT SIM*
