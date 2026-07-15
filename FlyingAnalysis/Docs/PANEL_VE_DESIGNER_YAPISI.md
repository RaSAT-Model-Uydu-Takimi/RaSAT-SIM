# FlyingAnalysis - Çoklu Panel ve Ayrı Designer Dosyaları Mimarisi (`UserControl` Yapısı)

Bu doküman, projede **çeşitli paneller arasında geçiş yapılabilmesini** sağlarken aynı zamanda **tüm panellerin Visual Studio'da farklı Designer dosyalarında açılabilmesini** ve yapay zekanın (ve geliştiricinin) `Designer.cs` karmaşası yaşamamasını garantileyen mimariyi açıklar.

---

## 1. Soru: "Tüm panelleri farklı designer dosyalarında görebilmem mümkün mü?"
**Cevap: EVET, %100 Mümkündür ve en doğru profesyonel yöntem tam olarak budur!**

Visual Studio ve .NET Windows Forms altyapısında, arayüzü tek bir devasa `Form` dosyasında (ve tek bir `Designer.cs` içinde) toplamak yerine, her ekranı / paneli bir **`UserControl` (Kullanıcı Kontrolü)** olarak tasarlarız.

### `UserControl` Kullanımının Çalışma Mantığı:
1. Visual Studio'da projeye yeni bir öğe eklerken `Add -> User Control (Windows Forms)` seçilir.
2. Örneğin 4 farklı panelimiz varsa, Solution Explorer'da tam olarak şu dosyalar oluşur:

```text
FlyingAnalysis/
│
├── UI/MainForm.cs                          # Ana Pencere (Menü ve taşıyıcı panel)
│   ├── MainForm.Designer.cs                # (Sadece ana menü ve boş taşıyıcının kodları ~1-2 KB)
│   └── MainForm.resx
│
└── UI/Panels/
    ├── TelemetryPanel.cs                   # 1. Panel: Telemetri ve Grafikler
    │   ├── TelemetryPanel.Designer.cs      # ---> SADECE BU PANELİN GÖRSEL DESIGNER KODLARI
    │   └── TelemetryPanel.resx
    │
    ├── SimulationConfigPanel.cs            # 2. Panel: Simülasyon & Gürültü Ayarları
    │   ├── SimulationConfigPanel.Designer.cs # ---> SADECE BU PANELİN GÖRSEL DESIGNER KODLARI
    │   └── SimulationConfigPanel.resx
    │
    ├── SensorCalibrationPanel.cs           # 3. Panel: Barometre / IMU Kalibrasyonu
    │   ├── SensorCalibrationPanel.Designer.cs # ---> SADECE BU PANELİN GÖRSEL DESIGNER KODLARI
    │   └── SensorCalibrationPanel.resx
    │
    └── AlgorithmStatusPanel.cs             # 4. Panel: İniş & Tetikleme Algoritma Durumları
        ├── AlgorithmStatusPanel.Designer.cs # ---> SADECE BU PANELİN GÖRSEL DESIGNER KODLARI
        └── AlgorithmStatusPanel.resx
```

---

## 2. Visual Studio'da Bu Paneller Nasıl Görünür ve Düzenlenir?

- **Ayrı Sekmeler:** Solution Explorer'da `TelemetryPanel.cs` üzerine çift tıkladığınızda, Visual Studio sadece telemetri grafiklerini barındıran **kendi özel Designer ekranını** açar.
- **Sıfır Karışıklık:** Bir panelde değişiklik yaparken diğer panellerin kontrolleri, butonları veya koordinatları o Designer dosyasının içine kesinlikle girmez.
- **Yapay Zeka (AI) Avantajı:** Ben AI olarak sadece üzerinde çalıştığımız küçük panelin `.cs` veya (gerekirse) `.Designer.cs` dosyasını okurum. 88 KB'lık monolitik bir dosya yerine 2 KB'lık küçük, odaklı dosyalar okunduğu için **bağlam kaybı (`context bloat`) kesinlikle yaşanmaz**.

---

## 3. Paneller Arasında Geçiş Nasıl Yapılır?

`MainForm` (Ana Pencere) üzerinde sol tarafta bir buton menüsü (`Sidebar`), sağ tarafta ise panellerin gösterileceği boş bir taşıyıcı alan (`Panel contentContainer`) yer alır.

Geçiş mantığı çok basittir:
```csharp
public partial class MainForm : Form
{
    // Panellerin örnekleri (instances)
    private TelemetryPanel _telemetryPanel = new TelemetryPanel();
    private SimulationConfigPanel _configPanel = new SimulationConfigPanel();
    private SensorCalibrationPanel _calibrationPanel = new SensorCalibrationPanel();
    private AlgorithmStatusPanel _algorithmPanel = new AlgorithmStatusPanel();

    public MainForm()
    {
        InitializeComponent();
        
        // Başlangıçta tüm panelleri taşıyıcıya ekle ama sadece ilki görünür olsun
        _telemetryPanel.Dock = DockStyle.Fill;
        _configPanel.Dock = DockStyle.Fill;
        _calibrationPanel.Dock = DockStyle.Fill;
        _algorithmPanel.Dock = DockStyle.Fill;

        contentContainer.Controls.Add(_telemetryPanel);
        contentContainer.Controls.Add(_configPanel);
        contentContainer.Controls.Add(_calibrationPanel);
        contentContainer.Controls.Add(_algorithmPanel);

        ShowPanel(_telemetryPanel);
    }

    private void ShowPanel(UserControl panelToShow)
    {
        panelToShow.BringToFront(); // Seçilen paneli en üste getir
    }

    private void btnTelemetry_Click(object sender, EventArgs e) => ShowPanel(_telemetryPanel);
    private void btnConfig_Click(object sender, EventArgs e) => ShowPanel(_configPanel);
    private void btnCalibration_Click(object sender, EventArgs e) => ShowPanel(_calibrationPanel);
    private void btnAlgorithms_Click(object sender, EventArgs e) => ShowPanel(_algorithmPanel);
}
```

### HTML & WebView2 Desteği
Eğer bazı panellerimizde gelişmiş **HTML5/JS tabanlı dinamik grafikler** (Chart.js, ECharts, 3D uydu simülasyonu) göstermek istersek, bir `HtmlReportPanel.cs` adlı `UserControl` açıp içine `Microsoft.Web.WebView2` yerleştirerek doğrudan yerel HTML/CSS/JS dosyalarımızı C# içinde çalıştırıp harika bir görsellik sunabiliriz.
