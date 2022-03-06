using System;
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
    public class TriggerChecker
    {
        private List<Func<bool>> triggers;
        private Func<bool> activeTrigger;
        public Func<bool> ActiveTrigger
        {
            get { return activeTrigger; }
            set { activeTrigger = value; }
        }

        public TriggerChecker(List<Func<bool>> triggers)
        {
            this.triggers = triggers;
        }
        public bool CheckTrigger()
        {

            for (int i = 0; i < triggers.Count; i++)
            {
                if (triggers[i].Invoke())
                {
                    activeTrigger = triggers[i];
                    return true;
                }
            }
            return false;
        }
    }
    public class StateMachine : MonoBehaviour, IStateMachine,ISwitchState
    {
        [SerializeField] private NodeState rootNodeState;
        private NodeState currentState;
        public void Start()
        {
            StartMachine();
        }
        public void StartMachine()
        {
            currentState = rootNodeState;
            currentState.Init();
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
            currentState.Init();
            currentState.ReadyToSwitch+=Switch;
            currentState.StartNodeAction();
        }
    }
}

