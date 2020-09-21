using Invictus.Core.Invictus.Hacks.TargetSelector;

namespace Invictus.Core.Invictus.Modules.Champion_Modules
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