using Invictus.Core.Invictus.Framework.Input;
using Newtonsoft.Json.Linq;
using System;
using System.Drawing;
using Invictus.Core.Invictus.Framework;
using Invictus.Core.Invictus.Framework.UpdateService;

namespace Invictus.Core.Invictus.Structures.Spell_Structure
{

    class SpellBook
    {

        private static int GetSpellBookInstance(int obj)
        {
            return Utils.ReadInt(obj + Offsets.SpellBook.Instance);
        }

        public static JObject SpellDb;

        public static int SpellArray
        {
            get
            {
                return 0x508;
            }
        }

        public static SpellClass GetSpellClassById(int obj, SpellSlotId iD)
        {
            SpellClass sClass = new SpellClass();
            sClass.CurrentSpell = Utils.ReadInt(GetSpellBookInstance(obj) + SpellArray + (0x4 * (int)iD));
            return sClass;
        }

        public static int GetSpellRadius(SpellSlot slot)
        {
            string spellSlotName = Enum.GetName(typeof(SpellSlot), slot);

            return SpellDb[spellSlotName].ToObject<JObject>()["Range"][0].ToObject<int>();
        }

        public static int GetActiveSpell(int obj)
        {
            return Utils.ReadInt(GetSpellBookInstance(obj) + 0x24);
        }

        public static void CastStaticSpell(int obj, SpellSlot slot)
        {
            if (Utils.IsGameInForeground() && IsSpellReady(obj, slot)) Keyboard.SendKey((short)slot);
        }

        public static void CastSpellAtPoint(int obj, SpellSlot slot, Point spellLocation)
        {
            if (Utils.IsGameInForeground() && IsSpellReady(obj, slot))
            {
                Mouse.MouseMove(spellLocation.X, spellLocation.Y);
                Keyboard.SendKey((short)slot);
            }
        }

        public static void CastMultiSpells(int obj, SpellSlot[] slotArray)
        {
            foreach (SpellSlot spell in slotArray)
            {
                if (Utils.IsGameInForeground() && IsSpellReady(obj, spell)) CastStaticSpell(obj, spell);
            }
        }


        public static void CastMultiSpells(int obj, SpellSlot[] slotArray, Point spellLocation)
        {
            foreach (SpellSlot spell in slotArray)
            {
                if (Utils.IsGameInForeground() && IsSpellReady(obj, spell)) CastSpellAtPoint(obj, spell, spellLocation);
            }
        }

        public static void CastSummonerSpell(int obj, SummonerSpellSlot slot)
        {
            if (Utils.IsGameInForeground() && IsSummonerSpellReady(obj, slot)) Keyboard.SendKey((short)slot);
        }

        public static void CastSummonerSpell(int obj, SummonerSpellSlot slot, int x, int y)
        {
            if (Utils.IsGameInForeground() && IsSummonerSpellReady(obj, slot))
            {
                Mouse.MouseMove(x, y);
                Keyboard.SendKey((short)slot);
            }
        }

        public static void CastSummonerSpell(int obj, SummonerSpellSlot slot, Point spellLocation)
        {
            if (Utils.IsGameInForeground() && IsSummonerSpellReady(obj, slot))
            {
                Mouse.MouseMove(spellLocation.X, spellLocation.Y);
                Keyboard.SendKey((short)slot);
            }
        }

        public static void CastItem(ItemSlot slot)
        {
            if (Utils.IsGameInForeground()) Keyboard.SendKey((short)slot);
        }

        public static void CastItem(ItemSlot slot, int x, int y)
        {
            if (Utils.IsGameInForeground())
            {
                Mouse.MouseMove(x, y);
                Keyboard.SendKey((short)slot);
            }
        }

        public static void CastItem(ItemSlot slot, Point spellLocation)
        {
            if (Utils.IsGameInForeground())
            {
                Mouse.MouseMove(spellLocation.X, spellLocation.Y);
                Keyboard.SendKey((short)slot);
            }
        }

        private static bool IsSpellReady(int obj, SpellSlot slot)
        {
            SpellSlotId findSlotId = (SpellSlotId) Enum.Parse(typeof(SpellSlotId), Enum.GetName(typeof(SpellSlot), slot));

            return GetSpellClassById(obj, findSlotId).IsSpellReady();
        }

        private static bool IsSummonerSpellReady(int obj, SummonerSpellSlot slot)
        {
            SpellSlotId findSlotId = (SpellSlotId) Enum.Parse(typeof(SpellSlotId), Enum.GetName(typeof(SummonerSpellSlot), slot));

            return GetSpellClassById(obj, findSlotId).IsSpellReady();
        }

        /* Broken ATM
        private static bool IsItemReady(ItemSlot Slot)
        {
            SpellSlotID FindSlotID = (SpellSlotID)Enum.Parse(typeof(SpellSlotID), Enum.GetName(typeof(ItemSlot), Slot));
            return GetSpellClassByID(FindSlotID).IsSpellReady();
        }*/

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

