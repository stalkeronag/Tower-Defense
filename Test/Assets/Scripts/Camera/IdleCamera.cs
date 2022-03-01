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
        private Dictionary<Func<bool>, IActionCamera> dictionaryOfActionCamera;
        private Func<bool> triggerActive;
        [SerializeField] private TriggersHandler handler;
        public override List<IActionCamera> LinkedActions
        {
            get { return linkedAction; }
            set { linkedAction = value; }
        }
        private bool isCurrent;
        public override void ExitAction()
        {
            dictionaryOfActionCamera[triggerActive].StartAction();
        }
        public void Init()
        {
            handler.Triggers=new List<Func<bool>>();
            dictionaryOfActionCamera = new Dictionary<Func<bool>, IActionCamera>(); 
            isCurrent = true;
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
        public void TrigerActivate(Func<bool> triggerActive)
        {
            isCurrent = false;
            this.triggerActive=triggerActive;  
            handler.triggerIsActivated -= TrigerActivate;   
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

