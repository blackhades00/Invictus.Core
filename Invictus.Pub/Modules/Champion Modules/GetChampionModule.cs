using InvictusSharp.LogService;
using InvictusSharp.Modules.Champion_Modules.KogMaw;
using InvictusSharp.Modules.Champion_Modules.Sona;
using InvictusSharp.Modules.Champion_Modules.Vayne;
using InvictusSharp.Structures.GameEngine;
using InvictusSharp.Structures.GameObjects;

namespace InvictusSharp.Modules.Champion_Modules
{
    public class GetChampionModule
    {
        internal static IChampionModule champModule = null;

        internal static void LoadChampionModule()
        {
            var champName = Engine.GetLocalObject().GetChampionName();
            switch (champName)
            {
                case "Vayne":
                    champModule = new VayneModule();
                    champModule.Init();
                    break;

                case "Sona":
                    champModule = new SonaModule();
                    champModule.Init();
                    break;

                case "KogMaw":
                    champModule = new KogMawModule();
                    champModule.Init();
                    break;

                    default:
                    Logger.Log("No Champion Module could be loaded.", Logger.eLoggerType.Fatal);
                    break;
            }
        }
    }
}