using UnityEngine;

namespace UniformAcceleration
{
    public class GravityMoveDeltime : GravityMoveAbstract
    {

        public override void Update(float time)
        {
            nowVelocity += GRAVITY * (time - lastTime);
            nowPosition += nowVelocity * (time - lastTime);
            lastTime = time;
        }

    }
}