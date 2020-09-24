using System.Linq;
using InvictusSharp.Framework.UpdateService;
using InvictusSharp.Hacks.TargetSelector;
using InvictusSharp.Structures.GameEngine;
using InvictusSharp.Structures.GameObjects;
using InvictusSharp.Structures.Spell_Structure;
using SharpDX;

namespace InvictusSharp.Hacks.Features
{
    public class AutoSmite
    {
        internal static void Load()
        {
            int[] smiteDmgArray =
            {
                390,
                410,
                430,
                450,
                480,
                510,
                540,
                570,
                600,
                640,
                680,
                720,
                760,
                800,
                850,
                900,
                950,
                1000
            };

            var smiteDmg = smiteDmgArray[Engine.GetLocalObject().GetLevel()-1];

            foreach (var minion in MinionManager.GetMinions(true,true).Where(minion => minion.IsNeutral()))
            {
                if (minion.GetHealth() < smiteDmg)
                {
                    Point pos;
                    var w2sPos = minion.GetObj2DPos();
                    pos.X = w2sPos.X;
                    pos.Y = w2sPos.Y;
                    SpellBook.CastSpell(SpellBook.SpellSlot.F,pos);
                }
                    
            }
        }
    }
}