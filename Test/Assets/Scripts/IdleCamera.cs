using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace CameraControl
{
    public class IdleCamera : IActionCamera
    {

        public override void ExitAction()
        {
          
        }

        public override void StartAction()
        {
            Debug.Log("Hello world");
        }

        public void AddTriger()
        {
            throw new NotImplementedException();
        }

        public override IActionCamera ChangeAction()
        {
            throw new NotImplementedException();
        }
    }
}

