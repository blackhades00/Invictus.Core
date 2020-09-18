using Invictus.Core.Invictus.Framework.Input;
using Newtonsoft.Json.Linq;
using System;
using Invictus.Core.Invictus.Framework;
using Invictus.Core.Invictus.Framework.UpdateService;
using SharpDX;

namespace Invictus.Core.Invictus.Structures.Spell_Structure
{

    internal class SpellBook
    {
        private int spellbookInstance { get; set; }

        public static JObject SpellDb;

        /// <summary>
        /// Returns an SpellBook Instance.
        /// </summary>
        /// <param name="obj"></param>
        internal SpellBook(int obj)
        {
            this.spellbookInstance = obj + Offsets.SpellBook.Instance;
        }

        /// <summary>
        /// Returns an SpellClass Instance.
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        public SpellClass GetSpellClassInstance(SpellSlotId ID)
        {
            SpellClass sClass = new SpellClass(spellbookInstance, ID);
            return sClass;
        }

        public int GetSpellRadius(SpellSlot slot)
        {
            string spellSlotName = Enum.GetName(typeof(SpellSlot), slot);

            return SpellDb[spellSlotName].ToObject<JObject>()["Range"][0].ToObject<int>();
        }

        public int GetActiveSpell(int obj)
        {
            return Utils.ReadInt(spellbookInstance + 0x24);
        }



        public static void CastSpell(int hardwareScanCode)
        {
            //Keyboard.SendKey((short)Slot);
            NativeImport.SendKey(hardwareScanCode);
        }

        public static void CastSpell(SpellSlot Slot, int X, int Y)
        {
            Mouse.MouseMove(X, Y);
            Keyboard.SendKey((short)Slot);

        }

        public static void CastSpell(SpellSlot Slot, Point SpellLocation)
        {

            Mouse.MouseMove(SpellLocation.X, SpellLocation.Y);
            Keyboard.SendKey((short)Slot);

        }

        /*
        public static void CastMultiSpells(SpellSlot[] SlotArray)
        {
            foreach (SpellSlot Spell in SlotArray)
            {
                CastSpell(Spell);
            }
        }
        */
        public static void CastMultiSpells(SpellSlot[] SlotArray, int X, int Y)
        {
            foreach (SpellSlot Spell in SlotArray)
            {
                CastSpell(Spell, X, Y);
            }
        }

        public static void CastMultiSpells(SpellSlot[] SlotArray, Point SpellLocation)
        {
            foreach (SpellSlot Spell in SlotArray)
            {
                CastSpell(Spell, SpellLocation);
            }
        }

        public static void CastSummonerSpell(SummonerSpellSlot Slot)
        {
            Keyboard.SendKey((short)Slot);
        }

        public static void CastSummonerSpell(SummonerSpellSlot Slot, int X, int Y)
        {

            Mouse.MouseMove(X, Y);
            Keyboard.SendKey((short)Slot);

        }

        public static void CastSummonerSpell(SummonerSpellSlot Slot, Point SpellLocation)
        {

            Mouse.MouseMove(SpellLocation.X, SpellLocation.Y);
            Keyboard.SendKey((short)Slot);

        }

        public static void CastItem(ItemSlot Slot)
        {
            Keyboard.SendKey((short)Slot);
        }

        public static void CastItem(ItemSlot Slot, int X, int Y)
        {


            Mouse.MouseMove(X, Y);
            Keyboard.SendKey((short)Slot);

        }

        public static void CastItem(ItemSlot Slot, Point SpellLocation)
        {

            Mouse.MouseMove(SpellLocation.X, SpellLocation.Y);
            Keyboard.SendKey((short)Slot);

        }


        public enum SpellSlot
        {
            Q = Keyboard.KeyBoardScanCodes.KeyQ,
            W = Keyboard.KeyBoardScanCodes.KeyW,
            E = Keyboard.KeyBoardScanCodes.KeyE,
            R = Keyboard.KeyBoardScanCodes.KeyR
        }

        public enum SummonerSpellSlot
        {
            Summoner1 = Keyboard.KeyBoardScanCodes.KeyD,
            Summoner2 = Keyboard.KeyBoardScanCodes.KeyF,
            Recall = Keyboard.VirtualKeyCodes.KeyB
        }

        public enum ItemSlot
        {
            Item1 = Keyboard.KeyBoardScanCodes.Key1,
            Item2 = Keyboard.KeyBoardScanCodes.Key2,
            Item3 = Keyboard.KeyBoardScanCodes.Key3,
            Item4 = Keyboard.KeyBoardScanCodes.Key5,
            Item5 = Keyboard.KeyBoardScanCodes.Key6,
            Item6 = Keyboard.KeyBoardScanCodes.Key7,
            Trinket = Keyboard.KeyBoardScanCodes.Key4,
        }

        public enum SpellSlotId
        {
            Q = 0,
            W = 1,
            E = 2,
            R = 3,
            Summoner1 = 4,
            Summoner2 = 5,
            Item1 = 6,
            Item2 = 7,
            Item3 = 8,
            Item4 = 9,
            Item5 = 10,
            Item6 = 11,
            Trinket = 12,
            Recall = 13
        }
    }
}

