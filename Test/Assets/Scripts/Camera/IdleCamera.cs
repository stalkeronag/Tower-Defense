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
            dictionaryOfActionCamera[triggerActive].StartAction();
        }
        public override void Init()
        {
            base.Init();
            handler.AddTrigger(() => Input.GetKeyDown(KeyCode.M));
            handler.AddTrigger(() => Input.GetKeyDown(KeyCode.R));
            dictionaryOfActionCamera.Add(handler.Triggers[0], linkedAction[0]);
            dictionaryOfActionCamera.Add(handler.Triggers[1], linkedAction[1]);
            handler.triggerIsActivated += TrigerActivate;
        }
        public override void StartAction()
        {
            Init();
            StartCoroutine(HelloWorld());
        }
        public override void TrigerActivate(Func<bool> triggerActive) => base.TrigerActivate(triggerActive);
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

