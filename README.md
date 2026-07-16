# RaSAT SIM (FlyingAnalysis) - Uçuş Dinamiği, Sensör Kalibrasyonu ve Kestirim Platformu

RaSAT SIM, model uydu projeleri için uçuş algoritmalarının, sensör hatalarının ve sensör füzyonu (Kalman Filtresi) performansının teorik ve deneysel olarak incelenmesi ile doğrulanması amacıyla geliştirilmiş bir simülasyon ve analiz platformudur.

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

---

## Ana Proje: FlyingAnalysis

Ekosistemin temel analiz aracı olan FlyingAnalysis; 4 fazlı yarışma uçuş dinamiğine ek olarak, belirli anlarda sensörlerin bozulduğu, veri kesintilerinin yaşandığı veya rüzgar darbelerinin etkili olduğu özel uçuş senaryoları oluşturmayı sağlar, sensör kalibrasyon modellerini ve 3x3 Kalman Kestirim Çekirdeğini (EKF) modüler bir arayüzde sunar.

### Temel İşlevi
Model uydunun roketten ayrılma, serbest düşüş, ayrılma ve aktif iniş  fazlarını simüle eder. Sensörlerde (Barometre ve İvmeölçer) oluşabilecek metrolojik hataları (%20 sistematik kayma, %20 rastgele gürültü, ani sıçramalar ve veri kesintileri) modeller ve Kalman Filtresi (EKF) algoritmalarının bu hataları süzme başarımını gerçek zamanlı test eder.

### Girdiler
* **Fiziksel ve Atmosferik Değişkenler:** Taşıyıcı ve görev yükü kütleleri (kg), paraşüt ve kanat alanları (m²), sürüklenme katsayısı (Cd) ile atmosferik referans basınç ve sıcaklık değerleri (P0, T0).
* **Sensör Metroloji ve Hata Tanımları:** Barometre ve ivmeölçer için sabit kayma (Bias), ölçek hatası (Scale Error %), beyaz gürültü standart sapması (σ) ve ısıl kayma katsayıları.
* **Zaman Çizelgesi ve Senaryo Tanımları:** Belirli saniyelerde tetiklenen dış kuvvet darbeleri (rüzgar/türbülans), sensör veri kesintileri (Cutoff) veya özel gürültü profilleri.
* **Kestirim Ayarları:** Kalman filtresi süreç gürültü matrisi (Q) ve sensör ölçüm gürültü matrisi (R) katsayıları.

### Çıktılar
* **Zaman-Konum ve Kuvvet Grafikleri:** Uydunun irtifa, hız, ivme verileri ile üzerindeki net aerodinamik ve kütleçekim kuvvet diyagramı.
* **Metrolojik Başarı ve Kestirim Raporu:**
  * **Doğruluk Başarısı (Trueness):** Ters kalibrasyon denkleminin sistematik kayma ve ölçek hatasını sönümleme oranı.
  * **Kesinlik Başarısı (Precision):** Kalman filtresinin rastgele beyaz gürültü titreşimlerini bastırma oranı.
  * **RMSE (Karesel Ortalama Hata):** Sistemin ham veri, kalibre edilmiş veri ve EKF kestirimi arasındaki toplam hata analiz tablosu.

---

## Yardımcı ve Destekleyici Programlar

FlyingAnalysis platformunu destekleyen, tasarım ve doğrulama süreçlerinde kullanılan diğer programlar:

### 1. Sayısıal Similasyon (İlk Gözağrımız)
* **Temel İşlevi:** Flying Analysis ilk halidir. Proje geliştirilmesi yarım kalmıştır. Bazı güzel özellikleri flyin analysise taşında uygun görünen diğer özelikler taşındıktan sonra depodan kaldırılacaktır
### 2. SensorAnalizi (Sensör Arıza ve Gömülü STM32 Algoritma Doğrulaması)
* **Temel İşlevi:** Sensör arızalarının model uydu algoritmaları üzerindeki etkisini inceleyen ve gerçek STM32 mikrodenetleyici C/C++ kodlerinin simülasyonda test edildiği doğrulama aracıdır.
* **Girdi:** STM32 Mikrodenetleyicimizin uçuş sırasında müdahale edebileceği her şeyin bulunduğu (mesela sol ön motor yüzde kaç güçle çalışacak) bir emirler dosyası).
* **Çıktı:** Gelen Emire göre davrandığında uydu sensörlerinin okuyacağı telemetri verilerinin dosyası 

### 3. Veri Analizi (Uçuş Sonrası CSV ve Telemetri Analizi)
* **Temel İşlevi:**  Sahada yapılan gerçek uçuş testelerinden veya Sensor Analizi programından elde edilen veri log dosyalarını (CSV) içeri aktararak grafik üzerinde inceleme aracıdır.
* **Girdi:** SayısalSimilasyondan elde edilen csv dosyası
* **Çıktı:** CVS içindeki dosyaların zaman göre veya paket numrasına göre grafikleri


