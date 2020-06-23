using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UniformAcceleration
{
    public class DeltimeDropMove : DropObjectBehaviour
    {
        protected override void StartAction()
        {
            gravity = new GravityMoveDeltime();
            gravity.Init(transform.position, Vector3.zero, Time.time);
            frameCtr.SetFrameEvent(MoveFrame);

        }

    }
}