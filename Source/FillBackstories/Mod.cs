using Mlie;
using UnityEngine;
using Verse;

namespace FillBackstories;

[StaticConstructorOnStartup]
internal class FillBackstoriesMod : Mod
{
    private static string currentVersion;

    /// <summary>
    ///     Cunstructor
    /// </summary>
    /// <param name="content"></param>
    public FillBackstoriesMod(ModContentPack content) : base(content)
    {
        Settings = GetSettings<FillBackstoriesSettings>();
        currentVersion =
            VersionFromManifest.GetVersionFromModMetaData(content.ModMetaData);
    }

    /// <summary>
    ///     The instance-settings for the mod
    /// </summary>
    private FillBackstoriesSettings Settings { get; }

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
        var listingStandard = new Listing_Standard();
        listingStandard.Begin(rect);
        listingStandard.Gap();
        listingStandard.Label("FiBa.minimum.label".Translate(), -1, "FiBa.minimum.tooltip".Translate());
        Settings.AmountOfBackstories = (int)Widgets.HorizontalSlider(listingStandard.GetRect(20),
            Settings.AmountOfBackstories, 5, 40, false, Settings.AmountOfBackstories.ToString(), null, null, 1);
        listingStandard.Gap();
        listingStandard.CheckboxLabeled("FiBa.logging.label".Translate(), ref Settings.VerboseLogging);
        listingStandard.Label("FiBa.restart.label".Translate());
        if (currentVersion != null)
        {
            listingStandard.Gap();
            GUI.contentColor = Color.gray;
            listingStandard.Label("FiBa.version.label".Translate(currentVersion));
            GUI.contentColor = Color.white;
        }

        listingStandard.End();
    }
}