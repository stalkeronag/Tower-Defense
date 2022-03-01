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
    public abstract class IActionCamera:MonoBehaviour
    {
        public abstract List<IActionCamera> LinkedActions { get; set; }
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

