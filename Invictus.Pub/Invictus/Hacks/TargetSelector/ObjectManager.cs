using Invictus.Core.Invictus.Framework;
using Invictus.Core.Invictus.Framework.UpdateService;

namespace Invictus.Core.Invictus.Hacks.TargetSelector
{
    internal class ObjectManager
    {
        private static int ObjManager = Utils.ReadInt(Offsets.Base + Offsets.ObjectManager.oObjManager);

        internal static int GetTarget()
        {
            if (Utils.IsKeyPressed(System.Windows.Forms.Keys.X))
                return MinionManager.GetLasthitTarget();

            if (Utils.IsKeyPressed(System.Windows.Forms.Keys.V))
                return MinionManager.GetWaveclearTarget();

            switch (Properties.Settings.Default.TargetSelector_Mode)
            {
                case "LowestHPTarget":
                    return HeroManager.GetLowestHPTarget();

                case "ClosestTarget":
                    return HeroManager.GetClosestTarget();
            }


            return 0;
        }

        internal static int GetFirst()
        {
            return Utils.ReadInt(Offsets.Base + Offsets.ObjectManager.oGetFirst) + ObjManager;
        }

        internal static int GetNext(int obj)
        {
            return Utils.ReadInt(Offsets.Base + Offsets.ObjectManager.oGetNext) + (ObjManager + obj);
        }

    }
}