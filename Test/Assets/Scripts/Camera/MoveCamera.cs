using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace CameraControl
{
    public class MoveCamera : IActionCamera
    {
        [SerializeField] private Camera camera;
        [SerializeField] private int  speedCamera;
        public override void StartAction() => MoveCameraAction();
        public override void Init()
        {
            base.Init();
            handler.AddTrigger(() => Input.GetKeyDown(KeyCode.I));
            handler.AddTrigger(() => Input.GetKeyDown(KeyCode.R));
            dictionaryOfActionCamera.Add(handler.Triggers[0], linkedAction[0]);
            dictionaryOfActionCamera.Add(handler.Triggers[1], linkedAction[1]);
        }
        public override void TrigerActivate(Func<bool> triggerActive) => base.TrigerActivate(triggerActive);

        public void MoveCameraAction()
        {
            Init();
            StartCoroutine(MoveCamer());
            
        }
        public IEnumerator MoveCamer()
        {
            if(camera == null)
                camera = Camera.main;
            Debug.Log("Move");
            while (isCurrent)
            {
                float horizontal = Input.GetAxis("Horizontal"), vertical = Input.GetAxis("Vertical");
                camera.transform.position+=(Vector3.right*horizontal+Vector3.forward*vertical)*Time.deltaTime*speedCamera;
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

