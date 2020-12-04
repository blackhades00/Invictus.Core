using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using InvictusSharp.Framework;
using InvictusSharp.Framework.UpdateService;
using InvictusSharp.Hacks.Drawings;
using InvictusSharp.Hacks.TargetSelector;
using InvictusSharp.LogService;
using InvictusSharp.Structures.GameEngine;
using InvictusSharp.Structures.GameObjects;
using InvictusSharp.Structures.Spell_Structure;
using SharpDX;

namespace InvictusSharp.Hacks.Features
{
    public class AutoSmite
    {
        private static int smiteKey = 0x0;
        private static SpellBook.SpellSlotId smiteSlot = SpellBook.SpellSlotId.Summoner2;
        internal static async void Load()
        {


            if (smiteKey == 0x0)
            {
                if (Engine.GetLocalObject().GetSpellBook()
                    .GetSpellClassInstance(SpellBook.SpellSlotId.Summoner1).GetSpellInfo().GetSpellName()
                    .Contains("Smite"))
                {
                    smiteSlot = SpellBook.SpellSlotId.Summoner1;
                    smiteKey = 0x20;
                }
                else if (Engine.GetLocalObject().GetSpellBook()
                    .GetSpellClassInstance(SpellBook.SpellSlotId.Summoner2).GetSpellInfo().GetSpellName().Contains("Smite"))
                    smiteKey = 0x21;
            }

            await Task.Run(() =>
            {
                while (true)
                {

                    if (Properties.Settings.Default.ToggleAutoSmite && Utils.IsKeyPressed(Keys.Y))
                    {
                        if (Engine.GetLocalObject().GetSpellBook().GetSpellClassInstance(smiteSlot).GetCharges() > 0)
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

                            var smiteDmg = smiteDmgArray[Engine.GetLocalObject().GetLevel() - 1];

                            foreach (var minion in MinionManager.GetMinions(true, true).Where(minion => minion.IsNeutral() && minion.GetMaxHp() > 500f))
                            {
                                if (minion.GetHealth() < smiteDmg)
                                {
                                    var w2s = Renderer.WorldToScreen(minion.GetObj3DPos());
                                    var p = Cursor.Position;
                                    Cursor.Position = new System.Drawing.Point((int)w2s.X, (int)w2s.Y);
                                    NativeImport.SendKey(smiteKey);
                                    Cursor.Position = p;
                                }

                            }
                        }
                    }

                }
            });


        }
    }
}