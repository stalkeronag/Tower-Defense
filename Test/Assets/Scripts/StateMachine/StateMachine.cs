using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace StateMachine
{
    public interface ISwitchState
    {
        public void Switch();
    }
    public interface IStateMachine
    {
        public void StartMachine();
        public void StopMachine();  

    }
    public class StateMachine : MonoBehaviour, IStateMachine,ISwitchState
    {
        [SerializeField] private NodeState rootNodeState;
        private NodeState currentState;
        public void StartMachine()
        {
            currentState = rootNodeState;
            currentState.ReadyToSwitch += Switch;
            currentState.StartNodeAction();

        }
        public void StopMachine()
        {
            currentState.ExitNodeAction();
            currentState.ReadyToSwitch -= Switch;   
        }
        public void Switch()
        {
            currentState.ExitNodeAction();
            currentState.ReadyToSwitch-= Switch;    
            currentState = currentState.EnterNodeAction();
            currentState.ReadyToSwitch+=Switch; 
            currentState.StartNodeAction();
        }
    }
}

