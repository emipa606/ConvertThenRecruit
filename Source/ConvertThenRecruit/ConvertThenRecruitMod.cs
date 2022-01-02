using Mlie;
using UnityEngine;
using Verse;

namespace ConvertThenRecruit;

[StaticConstructorOnStartup]
internal class ConvertThenRecruitMod : Mod
{
    /// <summary>
    ///     The instance of the settings to be read by the mod
    /// </summary>
    public static ConvertThenRecruitMod instance;

    private static string currentVersion;

    /// <summary>
    ///     The private settings
    /// </summary>
    private ConvertThenRecruitSettings settings;

    /// <summary>
    ///     Cunstructor
    /// </summary>
    /// <param name="content"></param>
    public ConvertThenRecruitMod(ModContentPack content) : base(content)
    {
        instance = this;
        currentVersion =
            VersionFromManifest.GetVersionFromModMetaData(
                ModLister.GetActiveModWithIdentifier("Mlie.ConvertThenRecruit"));
    }

    /// <summary>
    ///     The instance-settings for the mod
    /// </summary>
    public ConvertThenRecruitSettings Settings
    {
        get
        {
            if (settings == null)
            {
                settings = GetSettings<ConvertThenRecruitSettings>();
            }

            return settings;
        }
        set => settings = value;
    }

    /// <summary>
    ///     The title for the mod-settings
    /// </summary>
    /// <returns></returns>
    public override string SettingsCategory()
    {
        return "Convert Then Recruit";
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
        listing_Standard.CheckboxLabeled("CTR.reduceresistance.label".Translate(),
            ref Settings.ReduceResistance, "CTR.reduceresistance.description".Translate());
        if (currentVersion != null)
        {
            GUI.contentColor = Color.gray;
            listing_Standard.Label("CTR.version.label".Translate(currentVersion));
            GUI.contentColor = Color.white;
        }

        listing_Standard.End();
        Settings.Write();
    }
}