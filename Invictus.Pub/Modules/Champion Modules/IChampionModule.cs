namespace InvictusSharp.Modules.Champion_Modules
{
    internal interface IChampionModule
    {

        /// <summary>
        /// OnDraw: All drawings should be placed in here.
        /// </summary>
        void OnDraw();

        /// <summary>
        /// Combo: All Combo stuff should be placed here.
        /// </summary>
        void Combo();

        /// <summary>
        /// Farm: Everything farm related (waveclear, lasthit).
        /// </summary>
        void Farm();

        /// <summary>
        /// Jungleclear logic. If not set, waveclear logic should be used.
        /// </summary>
        void JungleClear();

        /// <summary>
        /// Initiates the module.
        /// </summary>
        void Init();

        /// <summary>
        /// Everything combo, farming related should be done in here.
        /// </summary>
        void OnTick();

    }
}