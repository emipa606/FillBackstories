using UnityEngine;
using Verse;

namespace FillBackstories
{
    [StaticConstructorOnStartup]
    internal class FillBackstoriesMod : Mod
    {
        /// <summary>
        ///     The private settings
        /// </summary>
        private FillBackstoriesSettings settings;

        /// <summary>
        ///     Cunstructor
        /// </summary>
        /// <param name="content"></param>
        public FillBackstoriesMod(ModContentPack content) : base(content)
        {
        }

        /// <summary>
        ///     The instance-settings for the mod
        /// </summary>
        private FillBackstoriesSettings Settings
        {
            get
            {
                if (settings == null)
                {
                    settings = GetSettings<FillBackstoriesSettings>();
                }

                return settings;
            }
        }

        /// <summary>
        ///     The title for the mod-settings
        /// </summary>
        /// <returns></returns>
        public override string SettingsCategory()
        {
            return "Fill Backstories";
        }

        /// <summary>
        ///     The settings-window
        ///     For more info: https://rimworldwiki.com/wiki/Modding_Tutorials/ModSettings
        /// </summary>
        /// <param name="rect"></param>
        public override void DoSettingsWindowContents(Rect rect)
        {
            var listing_Standard = new Listing_Standard();
            listing_Standard.Begin(rect);
            listing_Standard.Gap();
            listing_Standard.Label("Minimum amount of backstories per spawncategory", -1,
                "A minimum of this many backstories will be generated for each spawncategory. 20 is standard but more can be needed if they are very specific.");
            Settings.AmountOfBackstories = (int) Widgets.HorizontalSlider(listing_Standard.GetRect(20),
                Settings.AmountOfBackstories, 5, 40, false, Settings.AmountOfBackstories.ToString(), null, null, 1);
            listing_Standard.Gap();
            listing_Standard.Label("Backstories will be generated during the next restart");
            listing_Standard.End();
            Settings.Write();
        }
    }
}