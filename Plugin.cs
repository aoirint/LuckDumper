using BepInEx;
using BepInEx.Logging;
using HarmonyLib;

namespace LuckDumper;

[BepInPlugin("com.aoirint.luckdumper", "Luck Dumper", "0.1.0.0")]
[BepInProcess("Lethal Company.exe")]
public class Plugin : BaseUnityPlugin
{
    internal static new ManualLogSource Logger;
        
    private void Awake()
    {
        // Plugin startup logic
        Logger = base.Logger;
        Logger.LogInfo("Plugin com.aoirint.luckdumper is loaded!");

        Harmony.CreateAndPatchAll(typeof(Plugin));
    }

    [HarmonyPatch(typeof(Terminal), "BeginUsingTerminal")]
    [HarmonyPrefix]
    static bool BeginUsingTerminalPrefix() {
        foreach (var unlockable in StartOfRound.Instance.unlockablesList.unlockables) {
            var shopSelectionNode = unlockable.shopSelectionNode;

            Logger.LogInfo($"{unlockable.unlockableName},{unlockable.luckValue},{shopSelectionNode.itemCost}");
        }

        return true;
    }
}
