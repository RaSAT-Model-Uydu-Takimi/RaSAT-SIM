/**
 * @file SensorFusion_STM32.c
 * @brief STM32 Gömülü Sistemler İçin İrtifa Sensör Füzyonu ve İniş Kontrolü Gerçeklemesi
 */

#include "SensorFusion_STM32.h"
#include <math.h>

void SensorFusion_Init(SensorFusion_t* fusion, float initialAltitude)
{
    if (!fusion) return;

    fusion->estAltitude = initialAltitude;
    fusion->estVelocity = 0.0f;
    fusion->baroAltitudeRaw = initialAltitude;
    fusion->accelVertical = 0.0f;

    /* Tamamlayıcı filtre katsayıları */
    fusion->kAltitude = 0.08f;
    fusion->kVelocity = 0.03f;
    fusion->scaleErrorComp = 1.0f; /* Eğer barometre %20 fazla ölçüyorsa (1.20) kalibre edilerek bölünebilir */

    fusion->isLidarActive = false;
    fusion->lidarAltitude = -1.0f;
}

void SensorFusion_Update(SensorFusion_t* fusion, float baroAlt, float accelY, float lidarAlt, float dt)
{
    if (!fusion || dt <= 0.0001f) return;

    fusion->baroAltitudeRaw = baroAlt;
    fusion->accelVertical = accelY;

    /* 1) İvmeölçer ile Ön-Kestirim (Prediction Step) */
    float predAltitude = fusion->estAltitude + fusion->estVelocity * dt + 0.5f * accelY * (dt * dt);
    float predVelocity = fusion->estVelocity + accelY * dt;

    /* 2) Ölçüm Düzeltmesi (Correction / Innovation Step) */
    float baroCorrected = baroAlt / fusion->scaleErrorComp;

    /* Eğer alçak irtifada Lidar/ToF mesafesi güvenilir (< 15 metre) ise Lidar verisini yüksek ağırlıkla kullan */
    float referenceAlt = baroCorrected;
    float gainAlt = fusion->kAltitude;
    float gainVel = fusion->kVelocity;

    if (lidarAlt >= 0.05f && lidarAlt <= 15.0f)
    {
        fusion->isLidarActive = true;
        fusion->lidarAltitude = lidarAlt;
        referenceAlt = lidarAlt;
        gainAlt = 0.45f; /* Lidar hassasiyeti çok yüksek, düzeltme kazancı artırılıyor */
        gainVel = 0.20f;
    }
    else
    {
        fusion->isLidarActive = false;
    }

    /* İnovasyon hatası */
    float innovation = referenceAlt - predAltitude;

    /* Durum Güncellemesi */
    fusion->estAltitude = predAltitude + gainAlt * innovation;
    fusion->estVelocity = predVelocity + gainVel * innovation;

    /* Yer altı koruması */
    if (fusion->estAltitude < 0.0f)
    {
        fusion->estAltitude = 0.0f;
        fusion->estVelocity = 0.0f;
    }
}

void LandingController_Init(LandingController_t* ctrl)
{
    if (!ctrl) return;

    ctrl->targetVelocity = -3.0f;
    ctrl->kp = 0.12f;
    ctrl->kd = 0.05f;
    ctrl->baseThrottle = 0.35f;
    ctrl->currentThrottle = 0.0f;
}

float LandingController_Update(LandingController_t* ctrl, float estAltitude, float estVelocity, float dt)
{
    if (!ctrl || dt <= 0.0001f) return 0.0f;

    /* İrtifaya Göre Adaptif Hedef İniş Hızı Belirleme */
    if (estAltitude > 50.0f)
    {
        ctrl->targetVelocity = -8.0f; /* Yüksek irtifada hızlı iniş */
    }
    else if (estAltitude > 15.0f)
    {
        ctrl->targetVelocity = -4.0f; /* Orta irtifada yavaşlama */
    }
    else if (estAltitude > 3.0f)
    {
        ctrl->targetVelocity = -2.0f; /* Yaklaşma fazı */
    }
    else
    {
        ctrl->targetVelocity = -1.2f; /* Yumuşak dokunuş (soft touchdown) */
    }

    /* Hız hatası (İstenen - Gerçek) */
    float velError = ctrl->targetVelocity - estVelocity;

    /* PD Kontrol Çıktısı */
    float throttle = ctrl->baseThrottle - (ctrl->kp * velError);

    /* Sınırlandırma [0.0 - 1.0] */
    if (throttle < 0.0f) throttle = 0.0f;
    if (throttle > 1.0f) throttle = 1.0f;

    ctrl->currentThrottle = throttle;
    return throttle;
}
