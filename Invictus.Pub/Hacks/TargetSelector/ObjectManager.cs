using InvictusSharp.Framework;
using InvictusSharp.Framework.UpdateService;

namespace InvictusSharp.Hacks.TargetSelector
{
    internal class ObjectManager
    {
        private static int ObjManager = Utils.ReadInt(Offsets.Base + Offsets.ObjectManager.oObjManager);

        internal int GetTarget()
        {
            HeroManager heroManager = new HeroManager();
            MinionManager minionManager = new MinionManager();

            if (Utils.IsKeyPressed(System.Windows.Forms.Keys.X))
                return minionManager.GetLasthitTarget();

            if (Utils.IsKeyPressed(System.Windows.Forms.Keys.V))
                return minionManager.GetWaveclearTarget();

            switch (Properties.Settings.Default.TargetSelector_Mode)
            {
                case "LowestHPTarget":
                    return heroManager.GetLowestHPTarget();

                case "ClosestTarget":
                    return heroManager.GetClosestTarget();
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