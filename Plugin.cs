using BepInEx;
using BepInEx.Logging;
using HarmonyLib;

namespace LuckDumper;

[BepInPlugin("com.aoirint.luckdumper", "Luck Dumper", "0.1.0")]
[BepInProcess("Lethal Company.exe")]
public class Plugin : BaseUnityPlugin
{
    internal static new ManualLogSource Logger;

    private void Awake()
    {
        Logger = base.Logger;
        Logger.LogInfo("Plugin com.aoirint.luckdumper is loaded!");

        Harmony.CreateAndPatchAll(typeof(Plugin));
    }

    [HarmonyPatch(typeof(StartOfRound), "Awake")]
    [HarmonyPostfix]
    static void StartOfRoundAwakePostfix()
    {
        Logger.LogInfo("[Unlockables list]");
        Logger.LogInfo("Name,Luck Value,Item Cost");
        foreach (var unlockable in StartOfRound.Instance.unlockablesList.unlockables)
        {
            var shopSelectionNode = unlockable.shopSelectionNode;

            var itemCost = "";
            if (shopSelectionNode != null)
            {
                itemCost = shopSelectionNode.itemCost.ToString();
            }

            Logger.LogInfo($"{unlockable.unlockableName},{unlockable.luckValue},{itemCost}");
        }
        Logger.LogInfo("---");
    }

    [HarmonyPatch(typeof(TimeOfDay), "Start")]
    [HarmonyPostfix]
    static void TimeOfDayStartPostfix()
    {
        Logger.LogInfo("[Quota variables]");
        Logger.LogInfo("Base increase: " + TimeOfDay.Instance.quotaVariables.baseIncrease);
        Logger.LogInfo("Increase steepness: " + TimeOfDay.Instance.quotaVariables.increaseSteepness);

        var randomizerCurve = TimeOfDay.Instance.quotaVariables.randomizerCurve;

        Logger.LogInfo("[Quota randomizer curve]");
        Logger.LogInfo("Pre wrap mode: " + randomizerCurve.preWrapMode);
        Logger.LogInfo("Post wrap mode: " + randomizerCurve.postWrapMode);
        Logger.LogInfo("Time,Value,InTangent,OutTangent,WeightedMode,InWeight,OutWeight");
        for (int i = 0; i < randomizerCurve.keys.Length; i++)
        {
            var key = randomizerCurve.keys[i];
            Logger.LogInfo($"{key.time},{key.value},{key.inTangent},{key.outTangent},{key.weightedMode},{key.inWeight},{key.outWeight}");
        }
        Logger.LogInfo("---");
    }
}
