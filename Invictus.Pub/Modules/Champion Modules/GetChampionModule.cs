using InvictusSharp.LogService;
using InvictusSharp.Modules.Champion_Modules.Vayne;
using InvictusSharp.Structures.GameEngine;
using InvictusSharp.Structures.GameObjects;

namespace InvictusSharp.Modules.Champion_Modules
{
    public class GetChampionModule
    {
        internal static void LoadChampionModule()
        {
            var champName = Engine.GetLocalObject().GetChampionName();

            switch (champName)
            {
                case "Vayne":
                    var vayneModule = new VayneModule();
                    vayneModule.Init();
                    break;

                default:
                    Logger.Log("No Champion Module could be loaded.", Logger.eLoggerType.Fatal);
                    break;
            }
        }
    }
}