using InvictusSharp.Structures.GameObjects;

namespace InvictusSharp.Hacks.Prediction
{
    public static class HealthPrediction
    {
        internal static float GetEffectiveHealth(this int obj)
        {
            var resistance = obj.GetTotalArmor();
            var effectiveHp = obj.GetHealth();

            effectiveHp *= 1 + resistance / 100;
            return effectiveHp;
        }
    }
}