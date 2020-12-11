using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using InvictusSharp.Framework;
using InvictusSharp.Hacks.Drawings;
using InvictusSharp.Hacks.TargetSelector;
using InvictusSharp.LogService;
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
            Logger.Log("TEST",Logger.eLoggerType.Debug);
            if (igniteKey == 0x0)
            {
                if (Engine.GetLocalObject().GetSpellBook()
                    .GetSpellClassInstance(SpellBook.SpellSlotId.Summoner1).GetSpellInfo().GetSpellName()
                    .Contains("SummonerDot"))
                {
                    igniteSlot = SpellBook.SpellSlotId.Summoner1;
                    igniteKey = 0x20;
                }
                else if (Engine.GetLocalObject().GetSpellBook()
                    .GetSpellClassInstance(SpellBook.SpellSlotId.Summoner2).GetSpellInfo().GetSpellName().Contains("SummonerDot"))
                    igniteKey = 0x21;
            }

            await Task.Run(() =>
            {
                while (true)
                {
                    if (Engine.GetLocalObject().GetSpellBook().GetSpellClassInstance(igniteSlot).IsSpellReady() && Engine.GetLocalObject().IsAlive())
                    {
                        int igniteDmg = 50 + 20 * Engine.GetLocalObject().GetLevel();

                        foreach (var enemy in HeroManager.enemyList.Where(enemy => enemy.IsInRange(600f) && enemy.IsAlive() && enemy.IsTargetable()))
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