using BepInEx;
using BepInEx.Logging;

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
    }
}
