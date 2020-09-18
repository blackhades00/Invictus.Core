using Invictus.Core.Invictus.Framework;

namespace Invictus.Core.Invictus.Hacks.TargetSelector
{
    class ObjectManager
    {
        internal static int GetTarget()
        {
            if (Utils.IsKeyPressed(System.Windows.Forms.Keys.X))
                return MinionManager.GetLasthitTarget();

            if (Utils.IsKeyPressed(System.Windows.Forms.Keys.V))
                return MinionManager.GetWaveclearTarget();

            switch (TargetSelectorSettings.TsMode)
            {
                case "LowestHPTarget":
                    return HeroManager.GetLowestHPTarget();

                case "ClosestTarget":
                    return HeroManager.GetClosestTarget();
            }


            return 0;
        }
    }
}
