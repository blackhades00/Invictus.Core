using Invictus.Core.Invictus.LogService;
using Invictus.Core.Invictus.Structures.GameEngine;
using Invictus.Core.Invictus.Structures.GameObjects;

namespace Invictus.Core.Invictus.Modules.Champion_Modules
{
    public class GetChampionModule
    {
       internal static void LoadChampionModule()
        {
            var champName = Engine.GetLocalObject().GetChampionName();

            switch (champName)
            {
                case "Vayne":
                    VayneModule vayneModule = new VayneModule();
                    vayneModule.Init();
                    break;

                default:
                    Logger.Log("No Champion Module could be loaded.",Logger.eLoggerType.Fatal);
                    break;
            }
        }
    }
}