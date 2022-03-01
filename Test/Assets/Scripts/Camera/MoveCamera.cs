using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace CameraControl
{
    public class MoveCamera : IActionCamera
    {
        private Dictionary<Func<bool>, IActionCamera> dictionaryOfActionCamera;
        private Func<bool> triggerActive;
        [SerializeField] private TriggersHandler handler;
        [SerializeField] private CameraEvents cameraEvents;
        [SerializeField] private int  speedCamera;
        [SerializeField] private List<IActionCamera> linkedAction;
        private bool isCurrent;
        public override List<IActionCamera> LinkedActions
        {
            get { return linkedAction ; }
            set { linkedAction = value ; }
        }
        

        public override void StartAction() => MoveCameraAction();
        public void Init()
        {
          
            handler.Triggers = new List<Func<bool>>();
            dictionaryOfActionCamera = new Dictionary<Func<bool>, IActionCamera>();
            isCurrent = true;
            handler.AddTrigger(() => Input.GetKeyDown(KeyCode.A));
            handler.AddTrigger(() => Input.GetKeyDown(KeyCode.R));
            dictionaryOfActionCamera.Add(handler.Triggers[0], linkedAction[0]);
            dictionaryOfActionCamera.Add(handler.Triggers[1], linkedAction[1]);
            handler.triggerIsActivated += TrigerActivate;
        }
        public void TrigerActivate(Func<bool> triggerActive)
        {
            isCurrent = false;
            this.triggerActive = triggerActive;
            handler.triggerIsActivated -= TrigerActivate;
        }
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

