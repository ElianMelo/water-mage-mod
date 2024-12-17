using RoR2;
using WaterMage.Modules.Achievements;

namespace WaterMage.Survivors.WaterMage.Achievements
{
    //automatically creates language tokens "ACHIEVMENT_{identifier.ToUpper()}_NAME" and "ACHIEVMENT_{identifier.ToUpper()}_DESCRIPTION" 
    [RegisterAchievement(identifier, unlockableIdentifier, null, 10, null)]
    public class WaterMageMasteryAchievement : BaseMasteryAchievement
    {
        public const string identifier = WaterMageSurvivor.WaterMage_PREFIX + "masteryAchievement";
        public const string unlockableIdentifier = WaterMageSurvivor.WaterMage_PREFIX + "masteryUnlockable";

        public override string RequiredCharacterBody => WaterMageSurvivor.instance.bodyName;

        //difficulty coeff 3 is monsoon. 3.5 is typhoon for grandmastery skins
        public override float RequiredDifficultyCoefficient => 3;
    }
}