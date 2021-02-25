using Verse;

namespace FillBackstories
{
    /// <summary>
    ///     Definition of the settings for the mod
    /// </summary>
    internal class FillBackstoriesSettings : ModSettings
    {
        public int AmountOfBackstories = 20;

        /// <summary>
        ///     Saving and loading the values
        /// </summary>
        public override void ExposeData()
        {
            base.ExposeData();
            Scribe_Values.Look(ref AmountOfBackstories, "AmountOfBackstories", 20);
        }
    }
}