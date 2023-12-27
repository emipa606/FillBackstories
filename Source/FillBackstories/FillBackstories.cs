using System;
using System.Collections.Generic;
using System.Linq;
using RimWorld;
using Verse;

namespace FillBackstories;

[StaticConstructorOnStartup]
internal class FillBackstories
{
    private static int backstoriesGenerated;

    static FillBackstories()
    {
        var backstories = DefDatabase<BackstoryDef>.AllDefsListForReading.Where(def => def.shuffleable);
        var childBackstoryTags = new Dictionary<string, List<BackstoryDef>>();
        var adultBackstoryTags = new Dictionary<string, List<BackstoryDef>>();
        var amountOfBackstories = LoadedModManager.GetMod<FillBackstoriesMod>().GetSettings<FillBackstoriesSettings>()
            .AmountOfBackstories;
        var extraLogging = LoadedModManager.GetMod<FillBackstoriesMod>().GetSettings<FillBackstoriesSettings>()
            .VerboseLogging;

        foreach (var backstory in backstories)
        {
            foreach (var valueSpawnCategory in backstory.spawnCategories)
            {
                switch (backstory.slot)
                {
                    case BackstorySlot.Childhood:
                        if (childBackstoryTags.TryGetValue(valueSpawnCategory, out var tag))
                        {
                            tag.Add(backstory);
                        }
                        else
                        {
                            childBackstoryTags[valueSpawnCategory] = [backstory];
                        }

                        break;
                    case BackstorySlot.Adulthood:
                        if (adultBackstoryTags.TryGetValue(valueSpawnCategory, out var backstoryTag))
                        {
                            backstoryTag.Add(backstory);
                        }
                        else
                        {
                            adultBackstoryTags[valueSpawnCategory] = [backstory];
                        }

                        break;
                    default:
                        continue;
                }
            }
        }

        foreach (var backstoryTags in new List<Dictionary<string, List<BackstoryDef>>>
                     { childBackstoryTags, adultBackstoryTags })
        {
            foreach (var (categoryKey, backstoryDefs) in backstoryTags)
            {
                if (backstoryDefs.Count >= amountOfBackstories)
                {
                    continue;
                }

                var cycles = (int)Math.Floor((double)amountOfBackstories / backstoryDefs.Count);
                for (var i = 0; i < cycles; i++)
                {
                    foreach (var backstoryDef in backstoryDefs)
                    {
                        DuplicateBackstoryDef(backstoryDef, i.ToString());
                    }
                }

                if (extraLogging)
                {
                    Log.Message($"[FillBackstories]: Generated {cycles} extra copies for category: {categoryKey}");
                }
            }
        }

        Log.Message($"[FillBackstories]: Generated total of {backstoriesGenerated} backstory-copies");
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