using UnityEngine;

namespace UniformAcceleration
{
    public class GravityMoveEquation : GravityMoveAbstract
    {
        public override void Update(float time)
        {
            nowVelocity = GRAVITY * (time - startTime) + initVelicity;
            nowPosition = GRAVITY * Mathf.Pow(time - startTime, 2.0f) / 2 + initVelicity * (time - startTime) + initPosition;
        }
    }
}