using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace CameraControl
{
    public class IdleCamera : IActionCamera
    {
        [SerializeField] private List<IActionCamera> linkedAction;
        [SerializeField] private CameraEvents events;
        public override List<IActionCamera> LinkedActions
        {
            get { return linkedAction; }
            set { linkedAction = value; }
        }
        private List<Func<bool>> trigers;
        private bool isCurrent;
        private int indexNextActionCamera;
        public override void ExitAction()
        {
            linkedAction[indexNextActionCamera].StartAction();
        }
        public override void StartAction()
        {
            isCurrent = true;
            events.EventMoveCamera += OnMove;
            events.EventRotateCamera += OnRotate; 
            StartCoroutine(HelloWorld());
        }
        public void OnRotate()
        {
            isCurrent = false;
            events.EventRotateCamera -= OnRotate;
            indexNextActionCamera = 1;
        }
        public void OnMove()
        {
            isCurrent = false;
            events.EventMoveCamera -= OnMove;
            indexNextActionCamera = 0;
        }
        public IEnumerator HelloWorld()
        {
            Debug.Log("Idle");
            while (isCurrent)
            {
                yield return null;
            }
            ExitAction();
        }
    }
}

