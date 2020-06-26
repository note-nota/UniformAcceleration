using UnityEngine;

namespace UniformAcceleration
{
    public abstract class GravityMoveAbstract
    {
        protected static Vector3 GRAVITY = new Vector3(0, -9.80665f, 0f);

        protected Vector3 initPosition;
        protected Vector3 initVelicity;
        protected float startTime;

        protected Vector3 nowPosition;
        protected Vector3 nowVelocity;
        protected float lastTime;

        public void Init(Vector3 position, Vector3 velocity, float start_time)
        {
            initPosition = position;
            initVelicity = velocity;
            startTime = start_time;

            nowPosition = position;
            nowVelocity = velocity;
            lastTime = start_time;
        }

        public abstract void Update(float time);

        public Vector3 GetVelocity()
        {
            return nowVelocity;
        }

        public Vector3 GetPosition()
        {
            return nowPosition;
        }
    }
}