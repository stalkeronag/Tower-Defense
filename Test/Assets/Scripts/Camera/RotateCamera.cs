using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace CameraControl
{
    public class RotateCamera : IActionCamera
    {
        [SerializeField] private int speedRotateCamera;

        public override void StartAction() => RotateCameraAction();

        public void RotateCameraAction()
        {
            Init();
            isCurrent = true;
            StartCoroutine(RotateCamer());

        }
        public override void Init()
        {
            base.Init();
            handler.AddTrigger(() => Input.GetKeyDown(KeyCode.I));
            handler.AddTrigger(() => Input.GetKeyDown(KeyCode.M));
            dictionaryOfActionCamera.Add(handler.Triggers[0], linkedAction[0]);
            dictionaryOfActionCamera.Add(handler.Triggers[1], linkedAction[1]);
        }
        public override void TrigerActivate(Func<bool> triggerActive) => base.TrigerActivate(triggerActive);

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
            dictionaryOfActionCamera[triggerActive].StartAction();
        }

    }
}