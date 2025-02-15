using WaterMage.Survivors.WaterMage.SkillStates;

namespace WaterMage.Survivors.WaterMage
{
    public static class WaterMageStates
    {
        public static void Init()
        {
            Modules.Content.AddEntityState(typeof(SlashCombo));

            Modules.Content.AddEntityState(typeof(SplashCombo));

            Modules.Content.AddEntityState(typeof(Shoot));

            Modules.Content.AddEntityState(typeof(ShootWater));

            Modules.Content.AddEntityState(typeof(Roll));

            Modules.Content.AddEntityState(typeof(RollWater));

            Modules.Content.AddEntityState(typeof(ThrowBomb));

            Modules.Content.AddEntityState(typeof(ThrowOrb));

            Modules.Content.AddEntityState(typeof(ThrowWater));
        }
    }
}
