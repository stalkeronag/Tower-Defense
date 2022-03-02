using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public interface IMachine
{
    public void StartMachine();
    public void StopMachine();
}
namespace CameraControl
{
    public abstract class IActionCamera:MonoBehaviour
    {
        [SerializeField] protected float ExitTime;
        [SerializeField] protected List<IActionCamera> linkedAction;
        [SerializeField] protected TriggersHandler handler;
        protected bool isCurrent;
        protected Dictionary<Func<bool>, IActionCamera> dictionaryOfActionCamera;
        protected Func<bool> triggerActive;
        public virtual void Init()
        {
            handler.Triggers = new List<Func<bool>>();
            dictionaryOfActionCamera = new Dictionary<Func<bool>, IActionCamera>();
            isCurrent = true;
            handler.triggerIsActivated += TrigerActivate;
        }
        public virtual void TrigerActivate(Func<bool> triggerActive)
        {
            isCurrent = false;
            this.triggerActive = triggerActive;
            handler.triggerIsActivated -= TrigerActivate;
        }
        public abstract void StartAction();
        public abstract void ExitAction();
    }
    public class CameraController : MonoBehaviour, IMachine
    {
        [SerializeField] private IActionCamera currentState;
        private IActionCamera rootAction;
        public void Start() => StartMachine();
        public void StartMachine()
        {
            rootAction = currentState;
            currentState.StartAction();
        }
        public void StopMachine()
        {
            currentState = rootAction;
        }
    }
}
