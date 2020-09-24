namespace Invictus.Core.Invictus.Modules.Champion_Modules
{
    internal interface IChampionModule<T>
    {
        #region SpellLogics

        void QLogic();

        void WLogic();

        void ELogic();

        void RLogic();

        #endregion
    }
}