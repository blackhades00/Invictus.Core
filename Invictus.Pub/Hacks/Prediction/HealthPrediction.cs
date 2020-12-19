using System;
using System.Web.UI.WebControls;
using InvictusSharp.Callbacks;
using InvictusSharp.Framework;
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
                if (attack.GetMissileIndex().GetNetworkID() == obj.GetNetworkID())
                {
                    attackTick = attack.GetCastStartTime();
                    var landtime = attackTick + 1000 * Math.Max(0, Vector3.Distance(obj.GetObj3DPos(), attack.GetSpellStartPos()) - obj.GetBoundingRadius()) / attack.GetSpellInfo().GetSpellData().GetMissileSpeed() + delay;
                    if (landtime < Engine.GetGameTimeTickCount() + t)
                    {
                        attackDamage = attack.GetMissileIndex().GetTotalAd();
                    }

                }

                predictedDamage += attackDamage;
            }

            return obj.GetHealth() - predictedDamage;
        }

        public static float LaneClearHealthPrediction(int unit, int time, int delay = 70)
        {

            var predictedDmg = 0f;

            foreach (var attack in OnProcessSpell.GetActiveMinionAttacks())
            {
                // Add this stuff https://github.com/LeagueSharp/LeagueSharp.Common/blob/master/Orbwalking.cs#L1361
                var n = 0;
                var startTick = Environment.TickCount;
                if(Engine.GetGameTimeTickCount() - 100 <= startTick + attack.GetWindupTime() && attack.GetMissileIndex().GetNetworkID() == unit.GetNetworkID())
                {
                    var fromT = Environment.TickCount;
                    var toT = Engine.GetGameTimeTickCount() + time;

                    while(fromT < toT)
                    {
                        if(fromT >= Engine.GetGameTimeTickCount() && (fromT + attack.GetWindupTime()
                            + Math.Max(0, Vector3.Distance(unit.GetObj3DPos(), attack.GetSpellStartPos()) - 65) <toT))
                        {
                            n++;
                        }
                        fromT += (int)attack.GetWindupTime();
                    }
                }

                predictedDmg += n * attack.GetMissileIndex().GetTotalAd();
            }

            return unit.GetHealth() - predictedDmg;
        }

    }
}
