using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public interface IMachine
{
    public void StartMachine();
    public void StopMachine();
}
namespace CameraControl
{
    public interface SwitchActionCamera
    {
        public void SwitchAction();
    }
    public abstract class IActionCamera:MonoBehaviour
    {
        public abstract void StartAction();
        public abstract void ExitAction();
        public abstract IActionCamera ChangeAction();
    }
    public class CameraController : MonoBehaviour, IMachine,SwitchActionCamera
    {
        [SerializeField] private CameraEvents cameraEvents;
        [SerializeField] private List<IActionCamera> actionCamera;
        private IActionCamera currentState;
        public void Start() => StartMachine();
        public void StartMachine()
        {
            currentState = actionCamera[0];
            currentState.StartAction();
            cameraEvents.EventMoveCamera += SwitchAction;
            cameraEvents.EventRotateCamera += SwitchAction;
        }
        public void StopMachine()
        {
            currentState = actionCamera[0];
        }
        
        public void SwitchAction()
        {
          currentState.ExitAction();
          currentState = currentState.ChangeAction();
          currentState.StartAction();
        }
    }
}

