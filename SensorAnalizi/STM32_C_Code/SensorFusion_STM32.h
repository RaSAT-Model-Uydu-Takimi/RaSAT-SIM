/**
 * @file SensorFusion_STM32.h
 * @brief STM32 Gömülü Sistemler İçin İrtifa Sensör Füzyonu (Tamamlayıcı & Kalman Filtresi) ve İniş Kontrolcüsü
 * 
 * TEKNOFEST / TÜRKSAT Model Uydu Yarışması - Aktif İniş Sistemi
 * Barometre (%20 ölçek/gürültü hatalarına karşı) + İvmeölçer + Opsiyonel ToF/Lidar Füzyonu
 */

#ifndef SENSOR_FUSION_STM32_H
#define SENSOR_FUSION_STM32_H

#ifdef __cplusplus
extern "C" {
#endif

#include <stdint.h>
#include <stdbool.h>

/**
 * @brief Sensör Füzyonu ve Durum Kestirim Yapısı
 */
typedef struct {
    float estAltitude;      /**< Kestirilen Gerçek İrtifa (m) */
    float estVelocity;      /**< Kestirilen Dikey Hız (m/s) - aşağı yön eksi */
    float baroAltitudeRaw;  /**< Barometreden gelen son ham irtifa (m) */
    float accelVertical;    /**< Dikey ivme (m/s^2) - yerçekimi arındırılmış */
    
    /* Filtre Katsayıları */
    float kAltitude;        /**< İrtifa düzeltme kazancı (Örn: 0.08f) */
    float kVelocity;        /**< Hız düzeltme kazancı (Örn: 0.02f) */
    float scaleErrorComp;   /**< Bilinen kalibrasyon/ölçekleme hatası çarpanı (varsayılan: 1.0f) */

    /* Lidar / ToF Desteği */
    bool isLidarActive;     /**< Alçak irtifada Lidar aktif mi (<15m) */
    float lidarAltitude;    /**< Lidar irtifası (m) */
} SensorFusion_t;

/**
 * @brief İniş Kontrolcüsü (PID / PD) Yapısı
 */
typedef struct {
    float targetVelocity;   /**< Hedeflenen dikey iniş hızı (m/s) */
    float kp;               /**< Oransal kazanç */
    float kd;               /**< Türevsel kazanç */
    float baseThrottle;     /**< Askıda kalma (hover/süzülme) temel itkisi [0.0 - 1.0] */
    float currentThrottle;  /**< Motorlara uygulanan son itki [0.0 - 1.0] */
} LandingController_t;

/**
 * @brief Sensör füzyonu yapısını sıfırlar ve ilk başlatmayı yapar.
 * @param fusion SensorFusion_t veri yapısı göstericisi
 * @param initialAltitude Başlangıç irtifası (m)
 */
void SensorFusion_Init(SensorFusion_t* fusion, float initialAltitude);

/**
 * @brief Her kontrol döngüsünde (örn: dt = 0.01s / 100Hz) çağrılır. İrtifa ve hız kestirimi yapar.
 * @param fusion SensorFusion_t veri yapısı göstericisi
 * @param baroAlt Barometreden okunan irtifa (m)
 * @param accelY Dikey eksen ivmesi (m/s^2, yukarı pozitif)
 * @param lidarAlt Opsiyonel Lidar mesafesi (m), geçerli değilse < 0 verin
 * @param dt Döngü süresi (saniye, örn: 0.01f)
 */
void SensorFusion_Update(SensorFusion_t* fusion, float baroAlt, float accelY, float lidarAlt, float dt);

/**
 * @brief Aktif İniş Kontrolcüsü Başlatma
 * @param ctrl LandingController_t yapısı göstericisi
 */
void LandingController_Init(LandingController_t* ctrl);

/**
 * @brief Kestirilen irtifa ve hıza göre motor itkisini (throttle 0.0..1.0) hesaplar.
 * @param ctrl LandingController_t yapısı göstericisi
 * @param estAltitude Kestirilen irtifa (m)
 * @param estVelocity Kestirilen dikey hız (m/s)
 * @param dt Döngü süresi (saniye)
 * @return float Motor throttle değeri [0.0f - 1.0f]
 */
float LandingController_Update(LandingController_t* ctrl, float estAltitude, float estVelocity, float dt);

#ifdef __cplusplus
}
#endif

#endif /* SENSOR_FUSION_STM32_H */
