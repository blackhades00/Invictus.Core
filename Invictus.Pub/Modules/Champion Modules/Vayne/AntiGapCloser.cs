using InvictusSharp.Hacks.TargetSelector;

namespace InvictusSharp.Modules.Champion_Modules.Vayne
{
    public class AntiGapCloser
    {
        internal static bool IsInRange()
        {
            if (ObjectManager.GetTarget() != 0)
            {
                // if(ObjectManager.GetTarget().GetDistance(GameObject.Me) <= 50)
                //  SpellBook.CastSpell();
            }

            return false;
        }
    }
}