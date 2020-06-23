using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UniformAcceleration
{
    public class RigidbodyDropMove : DropObjectBehaviour
    {
        private Rigidbody rigidbody;

        private new void Start()
        {
            rigidbody = GetComponent<Rigidbody>();
            base.Start();
        }

        protected override void StartAction()
        {
            rigidbody.useGravity = true;
            frameCtr.SetFrameEvent(ActionFrame);
        }

        protected override void ResetAction()
        {
            base.ResetAction();
            rigidbody.useGravity = false;
            rigidbody.velocity = Vector3.zero;
        }

        protected void ActionFrame()
        {
            objectsManager.AbleObject(transform.position);
        }

    }
}