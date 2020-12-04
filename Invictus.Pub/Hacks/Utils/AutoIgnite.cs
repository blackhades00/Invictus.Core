using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using InvictusSharp.Framework;
using InvictusSharp.Hacks.Drawings;
using InvictusSharp.Hacks.TargetSelector;
using InvictusSharp.Modules.Champion_Modules;
using InvictusSharp.Structures.GameEngine;
using InvictusSharp.Structures.GameObjects;
using InvictusSharp.Structures.Spell_Structure;

namespace InvictusSharp.Hacks.Features
{
    public class AutoIgnite
    {
        private static int igniteKey = 0x0;
        private static SpellBook.SpellSlotId igniteSlot = SpellBook.SpellSlotId.Summoner2;
        public static async void Load()
        {

            if (igniteKey == 0x0)
            {
                if (Engine.GetLocalObject().GetSpellBook()
                    .GetSpellClassInstance(SpellBook.SpellSlotId.Summoner1).GetSpellInfo().GetSpellName()
                    .Contains("Ignite"))
                {
                    igniteSlot = SpellBook.SpellSlotId.Summoner1;
                    igniteKey = 0x20;
                }
                else if (Engine.GetLocalObject().GetSpellBook()
                    .GetSpellClassInstance(SpellBook.SpellSlotId.Summoner2).GetSpellInfo().GetSpellName().Contains("Ignite"))
                    igniteKey = 0x21;
            }

            await Task.Run(() =>
            {
                while (true)
                {
                    if (Engine.GetLocalObject().GetSpellBook().GetSpellClassInstance(igniteSlot).IsSpellReady())
                    {
                        int igniteDmg = 50 + 20 * Engine.GetLocalObject().GetLevel();

                        foreach (var enemy in HeroManager.enemyList.Where(enemy => enemy.IsInRange(600f)))
                        {
                            if (enemy.GetHealth() < igniteDmg)
                            {
                                var w2s = Renderer.WorldToScreen(enemy.GetObj3DPos());
                                var p = Cursor.Position;
                                Cursor.Position = new System.Drawing.Point((int)w2s.X, (int)w2s.Y);
                                NativeImport.SendKey(igniteKey);
                                Cursor.Position = p;
                            }
                        }

                    }
                }
            });
        }
    }
}