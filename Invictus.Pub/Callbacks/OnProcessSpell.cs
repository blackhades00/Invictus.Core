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
using InvictusSharp.Structures.Spell_Structure;

namespace InvictusSharp.Callbacks
{
    public class OnProcessSpell
    {
        /// <summary>
        /// All current active Minion Missiles.
        /// </summary>
        /// <returns></returns>
        internal static List<SpellCastInfo> GetActiveMinionAttacks()
        {
            MinionManager minionManager = new MinionManager();
            List<SpellCastInfo> activeAttacks = new List<SpellCastInfo>();
            foreach (var minion in minionManager.GetMinions(false,true).Where(minion => minion.IsAutoAttacking()))
            {
                activeAttacks.Add(minion.GetSpellCastInfo());
            }

            return activeAttacks;
        }

        internal static List<SpellCastInfo> GetActiveSpells()
        {
            List<SpellCastInfo> activeAttacks = new List<SpellCastInfo>();
            foreach (var enemy in HeroManager.enemyList)
            {
                if(!enemy.IsAutoAttacking())
                activeAttacks.Add(enemy.GetSpellCastInfo());
            }

            return activeAttacks;
        }
    }
}