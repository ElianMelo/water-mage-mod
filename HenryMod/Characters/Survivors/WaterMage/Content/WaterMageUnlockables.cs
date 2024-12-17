using WaterMage.Survivors.WaterMage.Achievements;
using RoR2;
using UnityEngine;

namespace WaterMage.Survivors.WaterMage
{
    public static class WaterMageUnlockables
    {
        public static UnlockableDef characterUnlockableDef = null;
        public static UnlockableDef masterySkinUnlockableDef = null;

        public static void Init()
        {
            masterySkinUnlockableDef = Modules.Content.CreateAndAddUnlockbleDef(
                WaterMageMasteryAchievement.unlockableIdentifier,
                Modules.Tokens.GetAchievementNameToken(WaterMageMasteryAchievement.identifier),
                WaterMageSurvivor.instance.assetBundle.LoadAsset<Sprite>("texMasteryAchievement"));
        }
    }
}
