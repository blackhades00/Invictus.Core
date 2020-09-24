using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Documents;
using InvictusSharp.Framework;
using InvictusSharp.Hacks.Orbwalker;
using InvictusSharp.Hacks.TargetSelector;
using InvictusSharp.LogService;
using InvictusSharp.Structures.GameEngine;
using InvictusSharp.Structures.GameObjects;

namespace InvictusSharp.Callbacks
{
    public class OnProcessSpell
    {
        /// <summary>
        /// All current active Minion Missiles.
        /// </summary>
        /// <returns></returns>
        internal static List<int> GetActiveMinionAttacks()
        {
            List<int> activeAttacks = new List<int>();
            foreach (var minion in MinionManager.GetMinions(false,true).Where(minion => minion.IsAutoAttacking()))
            {
                activeAttacks.Add(minion.GetSpellBook().GetSpellCastInfo().GetMissileIndex());
            }

            return activeAttacks;
        }
    }
}