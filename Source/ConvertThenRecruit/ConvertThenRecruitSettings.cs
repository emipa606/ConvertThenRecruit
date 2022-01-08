using Verse;

namespace ConvertThenRecruit;

/// <summary>
///     Definition of the settings for the mod
/// </summary>
internal class ConvertThenRecruitSettings : ModSettings
{
    public bool ReduceResistance;

    /// <summary>
    ///     Saving and loading the values
    /// </summary>
    public override void ExposeData()
    {
        base.ExposeData();
        Scribe_Values.Look(ref ReduceResistance, "ReduceResistance");
    }
}