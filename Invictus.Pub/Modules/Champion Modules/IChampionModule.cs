namespace InvictusSharp.Modules.Champion_Modules
{
    internal interface IChampionModule
    {
        /// <summary>
        /// OnStart is being called once upon gamestart.
        /// </summary>
        void OnStart();

        /// <summary>
        /// Initiates the module.
        /// </summary>
        void Init();


        /// <summary>
        /// OnDraw: All drawings should be placed in here.
        /// </summary>
        void OnDraw();

        /// <summary>
        /// Everything combo, farming related should be done in here.
        /// </summary>
        void OnTick();

        /// <summary>
        /// For AA resets etc
        /// </summary>
        void OnUpdate();

    }
}