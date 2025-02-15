using RoR2;
using UnityEngine;
using WaterMage.Modules;
using System;
using RoR2.Projectile;

namespace WaterMage.Survivors.WaterMage
{
    public static class WaterMageAssets
    {
        // particle effects
        public static GameObject swordSwingEffect;
        public static GameObject swordHitImpactEffect;

        // Water Sword
        public static GameObject waterSwordSwingEffect;
        public static GameObject waterSwordHitImpactEffect;

        // Water Projectile
        public static GameObject waterProjectileEffect;
        public static GameObject waterMuzzleEffect;

        // Water Impale
        public static GameObject waterImpaleEffect;

        public static GameObject bombExplosionEffect;
        public static GameObject orbExplosionEffect;
        public static GameObject waterExplosionEffect;

        // networked hit sounds
        public static NetworkSoundEventDef swordHitSoundEvent;

        //projectiles
        public static GameObject bombProjectilePrefab;
        public static GameObject orbProjectilePrefab;
        public static GameObject waterProjectilePrefab;

        private static AssetBundle _assetBundle;

        public static void Init(AssetBundle assetBundle)
        {

            _assetBundle = assetBundle;

            // swordHitSoundEvent = Content.CreateAndAddNetworkSoundEventDef("WaterMageSwordHit");
            swordHitSoundEvent = Content.CreateAndAddNetworkSoundEventDef("Play_WaterMelee");

            CreateEffects();

            CreateProjectiles();
        }

        #region effects
        private static void CreateEffects()
        {
            CreateBombExplosionEffect();

            swordSwingEffect = _assetBundle.LoadEffect("WaterMageSwordSwingEffect", true);
            swordHitImpactEffect = _assetBundle.LoadEffect("ImpactWaterMageSlash");

            waterSwordSwingEffect = _assetBundle.LoadEffect("WaterSwordSwingEffect", true);
            waterSwordHitImpactEffect = _assetBundle.LoadEffect("WaterSwordHitImpactEffect");

            waterProjectileEffect = _assetBundle.LoadEffect("WaterProjectileEffect");
            waterMuzzleEffect = _assetBundle.LoadEffect("WaterMuzzleEffect");

            waterImpaleEffect = _assetBundle.LoadEffect("WaterImpaleEffect");
        }

        private static void CreateBombExplosionEffect()
        {
            bombExplosionEffect = _assetBundle.LoadEffect("BombExplosionEffect", "WaterMageBombExplosion");
            orbExplosionEffect = _assetBundle.LoadEffect("OrbExplosionEffect", "WaterMageBombExplosion");
            waterExplosionEffect = _assetBundle.LoadEffect("WaterExplosionEffect", "WaterMageBombExplosion");

            if (!bombExplosionEffect)
                return;

            ShakeEmitter shakeEmitter = bombExplosionEffect.AddComponent<ShakeEmitter>();
            shakeEmitter.amplitudeTimeDecay = true;
            shakeEmitter.duration = 0.5f;
            shakeEmitter.radius = 200f;
            shakeEmitter.scaleShakeRadiusWithLocalScale = false;

            shakeEmitter.wave = new Wave
            {
                amplitude = 1f,
                frequency = 40f,
                cycleOffset = 0f
            };

            ShakeEmitter shakeEmitterOrb = orbExplosionEffect.AddComponent<ShakeEmitter>();
            shakeEmitterOrb.amplitudeTimeDecay = true;
            shakeEmitterOrb.duration = 0.5f;
            shakeEmitterOrb.radius = 200f;
            shakeEmitterOrb.scaleShakeRadiusWithLocalScale = false;

            shakeEmitterOrb.wave = new Wave
            {
                amplitude = 1f,
                frequency = 40f,
                cycleOffset = 0f
            };

            ShakeEmitter shakeEmitterWater = waterExplosionEffect.AddComponent<ShakeEmitter>();
            shakeEmitterWater.amplitudeTimeDecay = true;
            shakeEmitterWater.duration = 0.1f;
            shakeEmitterWater.radius = 1f;
            shakeEmitterWater.scaleShakeRadiusWithLocalScale = false;

            shakeEmitterWater.wave = new Wave
            {
                amplitude = 0.1f,
                frequency = 0.1f,
                cycleOffset = 0f
            };
        }
        #endregion effects

        #region projectiles
        private static void CreateProjectiles()
        {
            CreateBombProjectile();
            CreateOrbProjectile();
            CreateWaterProjectile();
            Content.AddProjectilePrefab(bombProjectilePrefab);
            Content.AddProjectilePrefab(orbProjectilePrefab);
            Content.AddProjectilePrefab(waterProjectilePrefab);
        }

        private static void CreateBombProjectile()
        {
            //highly recommend setting up projectiles in editor, but this is a quick and dirty way to prototype if you want
            bombProjectilePrefab = Asset.CloneProjectilePrefab("CommandoGrenadeProjectile", "WaterMageBombProjectile");

            //remove their ProjectileImpactExplosion component and start from default values
            UnityEngine.Object.Destroy(bombProjectilePrefab.GetComponent<ProjectileImpactExplosion>());
            ProjectileImpactExplosion bombImpactExplosion = bombProjectilePrefab.AddComponent<ProjectileImpactExplosion>();

            // Content.CreateAndAddNetworkSoundEventDef("WaterMageBombExplosion")

            bombImpactExplosion.blastRadius = 16f;
            bombImpactExplosion.blastDamageCoefficient = 1f;
            bombImpactExplosion.falloffModel = BlastAttack.FalloffModel.None;
            bombImpactExplosion.destroyOnEnemy = true;
            bombImpactExplosion.lifetime = 12f;
            bombImpactExplosion.impactEffect = bombExplosionEffect;
            bombImpactExplosion.lifetimeExpiredSound = Content.CreateAndAddNetworkSoundEventDef("Play_WaterSpecial");
            bombImpactExplosion.timerAfterImpact = true;
            bombImpactExplosion.lifetimeAfterImpact = 0.1f;

            ProjectileController bombController = bombProjectilePrefab.GetComponent<ProjectileController>();

            if (_assetBundle.LoadAsset<GameObject>("WaterMageBombGhost") != null)
                bombController.ghostPrefab = _assetBundle.CreateProjectileGhostPrefab("WaterMageBombGhost");
            
            bombController.startSound = "";
        }

        private static void CreateOrbProjectile()
        {
            //highly recommend setting up projectiles in editor, but this is a quick and dirty way to prototype if you want
            orbProjectilePrefab = Asset.CloneProjectilePrefab("CommandoGrenadeProjectile", "WaterMageOrbProjectile");

            //remove their ProjectileImpactExplosion component and start from default values
            UnityEngine.Object.Destroy(orbProjectilePrefab.GetComponent<ProjectileImpactExplosion>());
            ProjectileImpactExplosion orbImpactExplosion = orbProjectilePrefab.AddComponent<ProjectileImpactExplosion>();

            // Content.CreateAndAddNetworkSoundEventDef("WaterMageBombExplosion")

            orbImpactExplosion.blastRadius = 16f;
            orbImpactExplosion.blastDamageCoefficient = 1f;
            orbImpactExplosion.falloffModel = BlastAttack.FalloffModel.None;
            orbImpactExplosion.destroyOnEnemy = true;
            orbImpactExplosion.lifetime = 12f;
            orbImpactExplosion.impactEffect = orbExplosionEffect;
            orbImpactExplosion.lifetimeExpiredSound = Content.CreateAndAddNetworkSoundEventDef("Play_WaterSpecial");
            orbImpactExplosion.timerAfterImpact = true;
            orbImpactExplosion.lifetimeAfterImpact = 0.1f;

            ProjectileController orbController = orbProjectilePrefab.GetComponent<ProjectileController>();

            if (_assetBundle.LoadAsset<GameObject>("WaterMageOrbGhost") != null)
                orbController.ghostPrefab = _assetBundle.CreateProjectileGhostPrefab("WaterMageOrbGhost");

            orbController.startSound = "";
        }

        private static void CreateWaterProjectile()
        {
            //highly recommend setting up projectiles in editor, but this is a quick and dirty way to prototype if you want
            waterProjectilePrefab = Asset.CloneProjectilePrefab("CommandoGrenadeProjectile", "WaterMageWaterProjectile");

            //remove their ProjectileImpactExplosion component and start from default values
            UnityEngine.Object.Destroy(waterProjectilePrefab.GetComponent<ProjectileImpactExplosion>());
            ProjectileImpactExplosion waterImpactExplosion = waterProjectilePrefab.AddComponent<ProjectileImpactExplosion>();

            // Content.CreateAndAddNetworkSoundEventDef("WaterMageBombExplosion");

            waterImpactExplosion.blastRadius = 1f;
            waterImpactExplosion.blastDamageCoefficient = 1f;
            waterImpactExplosion.falloffModel = BlastAttack.FalloffModel.None;
            waterImpactExplosion.destroyOnEnemy = true;
            waterImpactExplosion.lifetime = 12f;
            waterImpactExplosion.impactEffect = waterExplosionEffect;
            waterImpactExplosion.lifetimeExpiredSound = Content.CreateAndAddNetworkSoundEventDef("Play_WaterSpecial");
            waterImpactExplosion.timerAfterImpact = true;
            waterImpactExplosion.lifetimeAfterImpact = 0.1f;

            ProjectileController waterController = waterProjectilePrefab.GetComponent<ProjectileController>();
            waterController.procCoefficient = 800f;
            // waterController.rigidbody.useGravity = false;

            if (_assetBundle.LoadAsset<GameObject>("WaterMageWaterGhost") != null)
                waterController.ghostPrefab = _assetBundle.CreateProjectileGhostPrefab("WaterMageWaterGhost");

            waterController.startSound = "";
        }
        #endregion projectiles
    }
}
