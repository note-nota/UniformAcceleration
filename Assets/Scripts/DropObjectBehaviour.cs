using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UniformAcceleration
{
    public abstract class DropObjectBehaviour : MonoBehaviour
    {
        [SerializeField]
        protected FrameControlPanel frameCtr;
        [SerializeField]
        protected GameObject shadowObject;

        protected GravityMoveAbstract gravity;
        protected Vector3 initPosition;
        protected ShadowObjectsManager objectsManager = new ShadowObjectsManager();

        protected virtual void Start()
        {
            objectsManager.Init(shadowObject);

            initPosition = transform.position;
            frameCtr.SetStartEvent(StartAction);
            frameCtr.SetResetEvent(ResetAction);
        }

        protected abstract void StartAction();

        protected virtual void ResetAction()
        {
            transform.position = initPosition;
            objectsManager.UnableAllObjects();
        }

        protected void MoveFrame()
        {
            objectsManager.AbleObject(gravity.GetPosition());

            gravity.Update(Time.time);
            transform.position = gravity.GetPosition();
        }

    }
}