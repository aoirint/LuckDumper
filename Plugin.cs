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
    static void StartOfRoundPostfix() {
        foreach (var unlockable in StartOfRound.Instance.unlockablesList.unlockables) {
            var shopSelectionNode = unlockable.shopSelectionNode;

            var itemCost = "";
            if (shopSelectionNode != null) {
                itemCost = shopSelectionNode.itemCost.ToString();
            }

            Logger.LogInfo($"{unlockable.unlockableName},{unlockable.luckValue},{itemCost}");
        }
    }
}
