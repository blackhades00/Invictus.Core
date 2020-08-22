using Invictus.Pub.Invictus;
using Invictus.Pub.Invictus.Framework.Menu;
using Invictus.Pub.Invictus.Hacks.TargetSelector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Invictus.Core.Invictus.Hacks.TargetSelector
{
    class ObjectManager
    {
        internal static int GetTarget()
        {
            if (Utils.IsKeyPressed(System.Windows.Forms.Keys.X))
                return MinionManager.GetLasthitTarget();

            switch (TargetSelectorSettings.TSMode)
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
