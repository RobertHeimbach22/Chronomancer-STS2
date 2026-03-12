using Godot;
using HarmonyLib;
using MegaCrit.Sts2.Core.Modding;
using BaseLib.Abstracts;
using BaseLib.Patches.Content;

namespace ChronomancerMod;

[ModInitializer(nameof(Initialize))]
public partial class MainFile : Node
{
    private const string ModId = "ChronomancerMod";

    public static MegaCrit.Sts2.Core.Logging.Logger Logger { get; } =
        new(ModId, MegaCrit.Sts2.Core.Logging.LogType.Generic);

    public static void Initialize()
    {
        Harmony harmony = new(ModId);
        harmony.PatchAll();

        // Register all mod content via BaseLib
        ContentPatcher.RegisterAssembly(typeof(MainFile).Assembly);
    }
}
