using UnityEngine;

namespace UniformAcceleration
{
    public class GravityMoveDeltime : GravityMoveAbstract
    {

        public override void Update(float time)
        {
            nowPosition += nowVelocity * (time - lastTime);
            nowVelocity += GRAVITY * (time - lastTime);
            lastTime = time;
        }

    }
}