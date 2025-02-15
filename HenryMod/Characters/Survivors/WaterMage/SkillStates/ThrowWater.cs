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

        private Vector3 forwardDirection;
        private Animator animator;

        private Rigidbody projectileRigidbody;

        protected string playbackRateParam = "Slash.playbackRate";

        public override void OnEnter()
        {
            projectilePrefab = WaterMageAssets.waterProjectilePrefab;
            //base.effectPrefab = Modules.Assets.SomeMuzzleEffect;
            //targetmuzzle = "muzzleThrow"

            attackSoundString = "Play_WaterProjectile";

            PlayAnimation(1);

            baseDuration = BaseDuration;
            baseDelayBeforeFiringProjectile = BaseDelayDuration;

            damageCoefficient = DamageCoefficient;
            //proc coefficient is set on the components of the projectile prefab
            force = 80f;

            animator = GetModelAnimator();
            // targetMuzzle = waterMuzzleEffect;

            if (isAuthority && inputBank && characterDirection)
            {
                forwardDirection = (inputBank.moveVector == Vector3.zero ? characterDirection.forward : inputBank.moveVector).normalized;
            }

            EffectManager.SimpleEffect(WaterMageAssets.waterMuzzleEffect,
                animator.transform.position + new Vector3(0f,2f,0f),
                Quaternion.LookRotation(characterDirection.forward), false);;

            //base.projectilePitchBonus = 0;
            //base.minSpread = 0;
            //base.maxSpread = 0;

            recoilAmplitude = 0f;
            bloom = 0f;
            projectilePitchBonus = 0f;

            base.OnEnter();
        }

        protected virtual void PlayAttackAnimation()
        {
        }

        public override void FixedUpdate()
        {
            base.FixedUpdate();

            projectileRigidbody = projectilePrefab.GetComponent<Rigidbody>();

            if(projectileRigidbody)
            {
                projectileRigidbody.useGravity = false;
            }            
        }

        public override InterruptPriority GetMinimumInterruptPriority()
        {
            return InterruptPriority.Skill;
        }

        public override void PlayAnimation(float duration)
        {
            if (GetModelAnimator())
            {
                PlayAnimation("Gesture, Override", "BasicAttack", "ThrowBomb.playbackRate", this.duration);
            }
        }
    }
}
