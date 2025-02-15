using BepInEx;
using WaterMage.Survivors.WaterMage;
using R2API.Utils;
using RoR2;
using System.Collections.Generic;
using System.Security;
using System.Security.Permissions;
using System.IO;

[module: UnverifiableCode]
[assembly: SecurityPermission(SecurityAction.RequestMinimum, SkipVerification = true)]

//rename this namespace
namespace WaterMage
{
    //[BepInDependency("com.rune580.riskofoptions", BepInDependency.DependencyFlags.SoftDependency)]
    [NetworkCompatibility(CompatibilityLevel.EveryoneMustHaveMod, VersionStrictness.EveryoneNeedSameModVersion)]
    [BepInPlugin(MODUID, MODNAME, MODVERSION)]
    public class WaterMagePlugin : BaseUnityPlugin
    {
        // if you do not change this, you are giving permission to deprecate the mod-
        //  please change the names to your own stuff, thanks
        //   this shouldn't even have to be said
        public const string MODUID = "com.elian.WaterMage";
        public const string MODNAME = "WaterMage";
        public const string MODVERSION = "1.0.0";

        // a prefix for name tokens to prevent conflicts- please capitalize all name tokens for convention
        public const string DEVELOPER_PREFIX = "ELIAN";

        public static WaterMagePlugin instance;

        void Awake()
        {
            //using (var bankStream = Assembly.GetExecutingAssembly().GetManifestResourceStream("Riven.RivenSoundBank.bnk"))
            //{
            //    var bytes = new byte[bankStream.length];
            //    bankStream.Read(bytes, 0, bytes.length);
            //    SoundAPI.SoundBanks.Add(bytes);
            //}

                instance = this;

            //easy to use logger
            Log.Init(Logger);

            // used when you want to properly set up language folders
            Modules.Language.Init();

            // character initialization
            new WaterMageSurvivor().Initialize();

            // make a content pack and add it. this has to be last
            new Modules.ContentPacks().Initialize();
        }
    }
}
