using System;
using System.Collections.Generic;
using AlienRace;
using JetBrains.Annotations;
using RimWorld;
using Verse;

namespace FillBackstories
{
    [StaticConstructorOnStartup]
    [UsedImplicitly]
    internal class FillBackstories
    {
        private static int backstoriesGenerated;

        static FillBackstories()
        {
            var backstories = DefDatabase<BackstoryDef>.AllDefsListForReading;
            var childBackstoryTags = new Dictionary<string, List<BackstoryDef>>();
            var adultBackstoryTags = new Dictionary<string, List<BackstoryDef>>();
            var amountOfBackstories = LoadedModManager.GetMod<FillBackstoriesMod>()
                .GetSettings<FillBackstoriesSettings>().AmountOfBackstories;

            foreach (var backstory in backstories)
            {
                foreach (var valueSpawnCategory in backstory.spawnCategories)
                {
                    switch (backstory.slot)
                    {
                        case BackstorySlot.Childhood:
                            if (childBackstoryTags.ContainsKey(valueSpawnCategory))
                            {
                                childBackstoryTags[valueSpawnCategory].Add(backstory);
                            }
                            else
                            {
                                childBackstoryTags[valueSpawnCategory] = new List<BackstoryDef> {backstory};
                            }

                            break;
                        case BackstorySlot.Adulthood:
                            if (adultBackstoryTags.ContainsKey(valueSpawnCategory))
                            {
                                adultBackstoryTags[valueSpawnCategory].Add(backstory);
                            }
                            else
                            {
                                adultBackstoryTags[valueSpawnCategory] = new List<BackstoryDef> {backstory};
                            }

                            break;
                        default:
                            continue;
                    }
                }
            }

            foreach (var backstoryTags in new List<Dictionary<string, List<BackstoryDef>>>
                {childBackstoryTags, adultBackstoryTags})
            {
                foreach (var (_, backstoryDefs) in backstoryTags)
                {
                    if (backstoryDefs.Count >= amountOfBackstories)
                    {
                        continue;
                    }

                    var cycles = (int) Math.Ceiling((double) amountOfBackstories / backstoryDefs.Count);
                    for (var i = 0; i < cycles; i++)
                    {
                        foreach (var backstoryDef in backstoryDefs)
                        {
                            DuplicateBackstoryDef(backstoryDef, i.ToString());
                        }
                    }
                }
            }

            Log.Message(
                $"Fill Backstories: Generated {backstoriesGenerated} backstory-copies");
        }

        private static void DuplicateBackstoryDef(BackstoryDef backstoryDef, string suffix)
        {
            var oldName = backstoryDef.defName;
            backstoryDef.defName = $"{backstoryDef.defName}_Clone{suffix}";
            backstoryDef.ResolveReferences();
            backstoriesGenerated++;
            backstoryDef.defName = oldName;
        }
    }
}