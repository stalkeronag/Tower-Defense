using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace CameraControl
{
    public class MoveCamera : IActionCamera
    {
        [SerializeField] private CameraEvents cameraEvents;
        [SerializeField] private int  speedCamera;
        [SerializeField] private List<IActionCamera> linkedAction;
        private bool isCurrent;
        private int indexNextActionCamera;
        public override List<IActionCamera> LinkedActions
        {
            get { return linkedAction ; }
            set { linkedAction = value ; }
        }
        private List<Func<bool>> triggers;

        public override void StartAction() => MoveCameraAction();

        public void MoveCameraAction()
        {
            isCurrent = true;
            cameraEvents.EventRotateCamera += OnRotate;
            cameraEvents.EventStopCamera += OnIdle;
            StartCoroutine(MoveCamer());
            
        }
        public void OnIdle()
        {
            isCurrent = false;
            cameraEvents.EventStopCamera -= OnIdle;
            indexNextActionCamera = 0;
        }
        public void OnRotate()
        {
            isCurrent = false;
            cameraEvents.EventRotateCamera -= OnRotate;
            indexNextActionCamera = 1;
        }
        public IEnumerator MoveCamer()
        {
            Debug.Log("Move");
            while (isCurrent)
            {
                yield return null;
            }
            ExitAction();
        }
        public override void ExitAction()
        {
            linkedAction[indexNextActionCamera].StartAction();
        }

    }
}

