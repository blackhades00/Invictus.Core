using InvictusSharp.Framework;
using InvictusSharp.Framework.Input;
using InvictusSharp.Framework.UpdateService;
using Newtonsoft.Json.Linq;
using SharpDX;

namespace InvictusSharp.Structures.Spell_Structure
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
            spellbookInstance = obj + Offsets.SpellBook.Instance;
        }

        /// <summary>
        /// Returns an SpellClass Instance.
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        public SpellClass GetSpellClassInstance(SpellSlotId ID)
        {
            var sClass = new SpellClass(spellbookInstance, ID);
            return sClass;
        }


        internal SpellCastInfo GetSpellCastInfo()
        {
            var spellCastInfoInstance =
                Utils.ReadInt(spellbookInstance + Offsets.SpellStructs.SpellCastInfo.SpellInfoInstance);

            return new SpellCastInfo(spellCastInfoInstance);
        }


        public static void CastSpell(int hardwareScanCode)
        {
            NativeImport.SendKey(hardwareScanCode);
        }

        public static void CastSpell(SpellSlot Slot, int X, int Y)
        {
            Mouse.MouseMove(X, Y);
            Keyboard.SendKey((short) Slot);
        }

        public static void CastSpell(SpellSlot Slot, Point SpellLocation)
        {
            Mouse.MouseMove(SpellLocation.X, SpellLocation.Y);
            CastSpell(0x2b);
        }

        public static void CastMultiSpells(SpellSlot[] SlotArray, int X, int Y)
        {
            foreach (var Spell in SlotArray) CastSpell(Spell, X, Y);
        }

        public static void CastMultiSpells(SpellSlot[] SlotArray, Point SpellLocation)
        {
            foreach (var Spell in SlotArray) CastSpell(Spell, SpellLocation);
        }

        public static void CastSummonerSpell(SummonerSpellSlot Slot)
        {
            Keyboard.SendKey((short) Slot);
        }

        public static void CastSummonerSpell(SummonerSpellSlot Slot, int X, int Y)
        {
            Mouse.MouseMove(X, Y);
            Keyboard.SendKey((short) Slot);
        }

        public static void CastSummonerSpell(SummonerSpellSlot Slot, Point SpellLocation)
        {
            Mouse.MouseMove(SpellLocation.X, SpellLocation.Y);
            Keyboard.SendKey((short) Slot);
        }

        public static void CastItem(ItemSlot Slot)
        {
            Keyboard.SendKey((short) Slot);
        }

        public static void CastItem(ItemSlot Slot, int X, int Y)
        {
            Mouse.MouseMove(X, Y);
            Keyboard.SendKey((short) Slot);
        }

        public static void CastItem(ItemSlot Slot, Point SpellLocation)
        {
            Mouse.MouseMove(SpellLocation.X, SpellLocation.Y);
            Keyboard.SendKey((short) Slot);
        }


        public enum SpellSlot
        {
            Q = Keyboard.KeyBoardScanCodes.KeyQ,
            W = Keyboard.KeyBoardScanCodes.KeyW,
            E = Keyboard.KeyBoardScanCodes.KeyE,
            R = Keyboard.KeyBoardScanCodes.KeyR,

            D = Keyboard.KeyBoardScanCodes.KeyD,
            F = Keyboard.KeyBoardScanCodes.KeyF
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
            Trinket = Keyboard.KeyBoardScanCodes.Key4
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