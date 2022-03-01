using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace CameraControl
{
    public class MoveCamera : IActionCamera
    {
        [SerializeField] private int  speedCamera;
        public override void StartAction() => MoveCameraAction();

        public void MoveCameraAction()
        {

        }

        public override void ExitAction()
        {
           
        }

        public override IActionCamera ChangeAction()
        {
            throw new System.NotImplementedException();
        }
    }
}

