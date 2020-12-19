using InvictusSharp.Hacks.Drawings;
using InvictusSharp.Structures.AI_Manager;
using InvictusSharp.Structures.GameEngine;
using InvictusSharp.Structures.GameObjects;
using InvictusSharp.Structures.Spell_Structure;
using SharpDX;

namespace InvictusSharp.Modules.Champion_Modules
{
    public class LocalChampionInfo
    {
        /// <summary>
        /// SpellBook instance of LocalPlayer
        /// </summary>
        internal static SpellBook SpellBookInstance = GameObject.Me.GetSpellBook();

        /// <summary>
        /// SpellClass Instance for Q Spell of LocalPlayer.
        /// </summary>
        internal static SpellClass QInstance = SpellBookInstance.GetSpellClassInstance(SpellBook.SpellSlotId.Q);

        /// <summary>
        /// SpellClass Instance for W Spell of LocalPlayer.
        /// </summary>
        internal static SpellClass WInstance = SpellBookInstance.GetSpellClassInstance(SpellBook.SpellSlotId.W);

        /// <summary>
        /// SpellClass Instance for E Spell of LocalPlayer.
        /// </summary>
        internal static SpellClass EInstance = SpellBookInstance.GetSpellClassInstance(SpellBook.SpellSlotId.E);

        /// <summary>
        /// SpellClass Instance for R Spell of LocalPlayer.
        /// </summary>
        internal static SpellClass RInstance = SpellBookInstance.GetSpellClassInstance(SpellBook.SpellSlotId.R);

        /// <summary>
        /// AI Manager Instance of LocalPlayer.
        /// </summary>
        internal AiManager AiManager = GameObject.Me.GetAiManger();

        /// <summary>
        /// Returns the LocalPlayer 3D Position.
        /// </summary>
        internal Vector3 GamePosition = Engine.GetLocalObject().GetObj3DPos();

        /// <summary>
        /// Returns the LocalPlayers 2D Position.
        /// </summary>
        internal SharpDX.Point Position
        {
            get
            {
                var w2s = Renderer.WorldToScreen(Engine.GetLocalObject().GetObj3DPos());
                return new Point((int)w2s.X, (int)w2s.Y);
            }
        }

        /// <summary>
        /// Returns current Mana of LocalPlayer.
        /// </summary>
        internal float CurrentMana = Engine.GetLocalObject().GetMana();

        /// <summary>
        /// Returns max mana of LocalPlayer.
        /// </summary>
        internal float MaxMana = Engine.GetLocalObject().GetMaxMana();

    }
}