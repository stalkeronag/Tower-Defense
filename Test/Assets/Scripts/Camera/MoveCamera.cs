using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace CameraControl
{
    public class MoveCamera : IActionCamera
    {
        [SerializeField] private int  speedCamera;
        public override void StartAction() => MoveCameraAction();
        public override void Init()
        {
            base.Init();
            handler.AddTrigger(() => Input.GetKeyDown(KeyCode.A));
            handler.AddTrigger(() => Input.GetKeyDown(KeyCode.R));
            dictionaryOfActionCamera.Add(handler.Triggers[0], linkedAction[0]);
            dictionaryOfActionCamera.Add(handler.Triggers[1], linkedAction[1]);
            handler.triggerIsActivated += TrigerActivate;
        }
        public override void TrigerActivate(Func<bool> triggerActive) => base.TrigerActivate(triggerActive);

        public void MoveCameraAction()
        {
            Init();
            StartCoroutine(MoveCamer());
            
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
            dictionaryOfActionCamera[triggerActive].StartAction();
        }

    }
}

