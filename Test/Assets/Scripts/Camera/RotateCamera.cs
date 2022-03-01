using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace CameraControl
{
    public class RotateCamera : IActionCamera
    {
        [SerializeField] private CameraEvents cameraEvents;
        [SerializeField] private int speedRotateCamera;
        [SerializeField] private List<IActionCamera> linkedAction;
        private bool isCurrent;
        private int indexNextActionCamera;
        public override List<IActionCamera> LinkedActions
        {
            get { return linkedAction; }
            set { linkedAction = value; }
        }
        private List<Func<bool>> triggers;

        public override void StartAction() => RotateCameraAction();

        public void RotateCameraAction()
        {
            isCurrent = true;
            cameraEvents.EventMoveCamera += OnMove;
            cameraEvents.EventStopCamera += OnIdle;
            StartCoroutine(RotateCamer());

        }
        public void OnMove()
        {
            isCurrent = false;
            cameraEvents.EventMoveCamera -= OnMove;
            indexNextActionCamera = 1;
          
        }
        public void OnIdle()
        {
            isCurrent = false;
            cameraEvents.EventStopCamera -= OnIdle;
            indexNextActionCamera = 0;
        }
        public IEnumerator RotateCamer()
        {
            Debug.Log("Rotate");
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