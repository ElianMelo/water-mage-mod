using EntityStates;
using WaterMage.Survivors.WaterMage;
using RoR2;
using RoR2.Projectile;
using UnityEngine;

namespace WaterMage.Survivors.WaterMage.SkillStates
{
    public class ThrowWater : GenericProjectileBaseState
    {
        public static float BaseDuration = 0.1f;
        //delays for projectiles feel absolute ass so only do this if you know what you're doing, otherwise it's best to keep it at 0
        public static float BaseDelayDuration = 0.0f;

        public static float DamageCoefficient = 4f;

        private Rigidbody projectileRigidbody;

        public override void OnEnter()
        {
            projectilePrefab = WaterMageAssets.waterProjectilePrefab;
            //base.effectPrefab = Modules.Assets.SomeMuzzleEffect;
            //targetmuzzle = "muzzleThrow"

            attackSoundString = "WaterMageBombThrow";

            baseDuration = BaseDuration;
            baseDelayBeforeFiringProjectile = BaseDelayDuration;

            damageCoefficient = DamageCoefficient;
            //proc coefficient is set on the components of the projectile prefab
            force = 800f;

            //base.projectilePitchBonus = 0;
            //base.minSpread = 0;
            //base.maxSpread = 0;

            recoilAmplitude = 0f;
            bloom = 0f;
            projectilePitchBonus = 0f;

            rigidbody.useGravity = false;

            base.OnEnter();
        }

        public override void FixedUpdate()
        {
            base.FixedUpdate();

            projectileRigidbody = projectilePrefab.GetComponent<Rigidbody>();

            if(projectileRigidbody)
            {
                projectileRigidbody.velocity *= 2;
                projectileRigidbody.useGravity = false;
            }
            rigidbody.useGravity = false;
        }

        public override InterruptPriority GetMinimumInterruptPriority()
        {
            return InterruptPriority.Skill;
        }

        public override void PlayAnimation(float duration)
        {

            if (GetModelAnimator())
            {
                PlayAnimation("Gesture, Override", "ThrowBomb", "ThrowBomb.playbackRate", this.duration);
            }
        }
    }
}
