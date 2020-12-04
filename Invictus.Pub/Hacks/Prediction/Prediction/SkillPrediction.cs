using System.Windows;
using InvictusSharp.Framework;
using InvictusSharp.Hacks.Drawings;
using InvictusSharp.LogService;
using InvictusSharp.Structures.GameEngine;
using InvictusSharp.Structures.GameObjects;
using SharpDX;

namespace InvictusSharp.Hacks.Prediction.Prediction
{
    class SkillPrediction
    {
        internal static Vector2 GetLinePrediction(int target, float range, float missilespeed, float casttime)
        {
            if (target == 0)
                return Vector2.Zero;

            var aim = target.GetAiManger();

            if (!aim.IsMoving())
                return Renderer.WorldToScreen(aim.GetServerPos());

            float t = (target.GetObj3DPos() - Engine.GetLocalObject().GetObj3DPos()).Length() / missilespeed;

            t += casttime;

            var navend = aim.GetNavEnd();
            navend.Y = 0;
            navend.Normalize();

            if (Vector3.Distance(target.GetObj3DPos(), Engine.GetLocalObject().GetObj3DPos()) > range)
                return Vector2.Zero;

            if (navend.X == 0 && navend.Z == 0)
            {
                return Renderer.WorldToScreen(aim.GetServerPos());
            }
           
           // DrawFactory.DrawCircleRange(target.GetObj3DPos(), 300f, Color.Red, 1.5f);

            Vector3 predictedPosition = target.GetObj3DPos() + target.GetMoveSpeed() * navend * t;
            predictedPosition.Y = target.GetObj3DPos().Y;

            Vector2 predict2d = Renderer.WorldToScreen(predictedPosition);
            Vector2 local2d = Renderer.WorldToScreen(target.GetObj3DPos());
           // DrawFactory.DrawLine(local2d.X, local2d.Y, predict2d.X, predict2d.Y, 5f, Color.Red);

            return predict2d;
        }
    }
}