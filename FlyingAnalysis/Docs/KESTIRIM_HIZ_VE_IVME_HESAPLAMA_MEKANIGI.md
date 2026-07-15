# KESTİRİM HIZ VE İVME HESAPLAMA MEKANİĞİ

Bu doküman, Gelişmiş Kalman Filtresi (EKF) çekirdeğinin **hız ve ivme tahminini** nasıl ürettiğini,
hiçbir sensör doğrudan hız ölçmemesine rağmen neden güvenilir bir hız kestirimi elde edebildiğini açıklar.

---

## 1. DURUM VEKTÖRÜ

Çekirdek, tek eksenli (Z / İrtifa) kinematiği 3 durumlu bir vektör üzerinden takip eder:

```
X = [ z ]   =  [ Tahmini İrtifa (m)      ]
    [ v ]      [ Tahmini Dikey Hız (m/s)  ]
    [ a ]      [ Tahmini Dikey İvme (m/s²)]
```

## 2. TAHMİN ADIMI (Prediction / Time Update)

Her `dt` adımında kinematik modelden durum ilerletilir:

```
z_pred = z_önceki + v_önceki · Δt + ½ · a_önceki · Δt²
v_pred = v_önceki + a_önceki · Δt           ← İvmenin zaman integrali
a_pred = a_önceki                            ← Sabit ivme varsayımı
```

Matris formunda:

```
       ┌ 1   Δt   ½Δt² ┐       ┌ z ┐
X_k =  │ 0    1     Δt  │   ·   │ v │
       └ 0    0      1  ┘       └ a ┘  (k-1)
```

Bu noktada **hız, bir önceki ivmeden integre edilerek** ilerletilir.
Henüz hiçbir sensör ölçümü dahil edilmemiştir.

---

## 3. BAROMETRE GÜNCELLEMESİ (H_baro = [1, 0, 0])

Barometre **yalnızca konum** (z) ölçer. Ancak Kalman kazancı (K) sayesinde
**hız ve ivme de dolaylı olarak düzeltilir**:

```
Yenilik (Innovation):
    y = z_baro_kalibre − z_tahmin

Yenilik Kovaryansı:
    S = P₀₀ + R_baro

Kalman Kazancı:
    K₀ = P₀₀ / S    →  z düzeltmesi   (doğrudan, baro konum ölçer)
    K₁ = P₁₀ / S    →  v düzeltmesi   (DOLAYLI, çapraz kovaryans P₁₀)
    K₂ = P₂₀ / S    →  a düzeltmesi   (dolaylı, çapraz kovaryans P₂₀)

Durum Güncellemesi:
    z = z_pred + K₀ · y
    v = v_pred + K₁ · y      ← Hız, konum hatasından dolaylı düzeltilir
    a = a_pred + K₂ · y
```

### Neden Çalışıyor?

Eğer barometre "tahmin ettiğinden **yukarıdasın**" diyorsa (y > 0):
- Kalman filtresi "o zaman hızın da tahmin ettiğimden büyük olmalı"
  diye **hızı yukarı düzeltir**.
- Bu düzeltmenin miktarını **çapraz kovaryans P₁₀** belirler.
- P₁₀, konum ve hız belirsizliklerinin birbirine ne kadar bağlı olduğunu temsil eder.

---

## 4. İVMEÖLÇER GÜNCELLEMESİ (H_acc = [0, 0, 1])

İvmeölçer **doğrudan ivme** (a) ölçer. Yine çapraz kovaryans üzerinden
hız ve konum da düzeltilir:

```
Yenilik (Innovation):
    y = a_ivmeölçer_kalibre − a_tahmin

Yenilik Kovaryansı:
    S = P₂₂ + R_acc

Kalman Kazancı:
    K₀ = P₀₂ / S    →  z düzeltmesi   (dolaylı)
    K₁ = P₁₂ / S    →  v düzeltmesi   (DOLAYLI, çapraz kovaryans P₁₂)
    K₂ = P₂₂ / S    →  a düzeltmesi   (doğrudan, ivmeölçer ivme ölçer)

Durum Güncellemesi:
    z = z + K₀ · y
    v = v + K₁ · y      ← Hız, ivme hatasından dolaylı düzeltilir
    a = a + K₂ · y
```

---

## 5. BİLGİ AKIŞ DİYAGRAMI

```
                    ┌─────────────────────────────────────┐
                    │      KİNEMATİK MODEL (F matrisi)    │
  a_önceki ────────►│  v = v + a·dt    (ivme integrali)   │───► v_tahmin
                    │  z = z + v·dt + ½a·dt²              │
                    └─────────────────────────────────────┘
                                    │
                    ┌───────────────┼───────────────┐
                    ▼               ▼               ▼
              ┌──────────┐   ┌──────────┐    ┌──────────┐
              │ Barometre │   │  (yok)   │    │İvmeölçer │
              │ z_ölçüm   │   │ v ölçümü │    │ a_ölçüm  │
              └─────┬─────┘   │  YOK!    │    └─────┬────┘
                    │         └──────────┘          │
                    ▼                               ▼
              K₁ = P₁₀/S                     K₁ = P₁₂/S
              (v dolaylı                      (v dolaylı
               düzeltilir)                     düzeltilir)
                    │                               │
                    └──────────┬────────────────────┘
                               ▼
                    ┌──────────────────────┐
                    │  EstimatedVelocity   │
                    │  (Kaynaştırılmış Hız)│
                    └──────────────────────┘
```

## 6. ÖZET

| Durum Değişkeni | Doğrudan Ölçen Sensör | Dolaylı Düzelten Sensör | Nasıl? |
|:---|:---|:---|:---|
| **Konum (z)** | Barometre | İvmeölçer | Çapraz kovaryans P₀₂ |
| **Hız (v)** | **Hiçbiri!** | Barometre + İvmeölçer | P₁₀ ve P₁₂ çapraz kovaryansları |
| **İvme (a)** | İvmeölçer | Barometre | Çapraz kovaryans P₂₀ |

**Hız hiçbir sensör tarafından doğrudan ölçülmez**, ama Kalman filtresi:
1. İvmeyi zamanda integre ederek hızı tahmin eder (model)
2. Barometrenin konum hatalarından hız sapmasını çıkarır (P₁₀)
3. İvmeölçerin ivme hatalarından hız sapmasını çıkarır (P₁₂)

Bu üç bilgi kaynağının kovaryans-ağırlıklı ortalaması → **EstimatedVelocity**.
