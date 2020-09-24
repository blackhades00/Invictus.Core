using System;
using System.Web.UI.WebControls;
using InvictusSharp.Callbacks;
using InvictusSharp.Structures.GameEngine;
using InvictusSharp.Structures.GameObjects;
using SharpDX;
using Math = System.Math;

namespace InvictusSharp.Hacks.Prediction
{
    public static class HealthPrediction
    {
        /*
        internal static float GetEffectiveHealth(this int obj)
        {
            var resistance = obj.GetTotalArmor();
            var effectiveHp = obj.GetHealth();

            effectiveHp *= (1 + resistance / 100);
            return effectiveHp;
        }
        */

        internal static float PredictHealth(int obj, int delay = 20)
        {
            var predictedDamage = 0f;

            var t = (int) (Engine.GetAttackCastDelay() * 1000) - 100 + Engine.GetPing() / 2
                                                              + 1000 * (int) Math.Max(0,
                                                                  Engine.GetLocalObject().GetDistance(obj) -
                                                                  Engine.BoundingRadius);
                                                                 

            foreach (var attack in OnProcessSpell.GetActiveMinionAttacks())
            {
                var attackDamage = 0f;
                var attackTick = 0f;
                if (attack.GetNetworkID() == obj.GetNetworkID())
                {
                    attackTick = Environment.TickCount;
                    var landtime = attackTick + +  1000 * Math.Max(0, Vector3.Distance(obj.GetObj3DPos(), attack.GetSpellBook().GetSpellCastInfo().GetSpellStartPos()) - 65)+ delay;
                    if (landtime < Engine.GetGameTimeTickCount() + t)
                    {
                        attackDamage = attack.GetTotalAd();
                    }

                }

                predictedDamage += attackDamage;
            }

            return obj.GetHealth() - predictedDamage;
        }

    }
}
