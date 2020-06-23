using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UniformAcceleration
{
    public class EquationDropMove : DropObjectBehaviour
    {
        protected override void StartAction()
        {
            gravity = new GravityMoveEquation();
            gravity.Init(transform.position, Vector3.zero, Time.time);
            frameCtr.SetFrameEvent(MoveFrame);
        }
    }
}