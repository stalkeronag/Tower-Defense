using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace StateMachine
{
    public abstract class NodeBuildTriggerContext:MonoBehaviour
    {
        public abstract event Action<Func<bool>> TrigerIsActivated;
        public abstract void BuildTriggerSystem(List<Func<bool>> triggers);
    }
    [System.Serializable]
    public class NodeState : MonoBehaviour
    {
        [SerializeField] protected NodeBuildTriggerContext contextTriggerBuild;
        [SerializeField] protected List<NodeState> linkedNodeState;
        [SerializeField] protected int exitTime;
        [SerializeField] protected bool isCurrent;
        private Dictionary<Func<bool>,NodeState> nodeStateMap;
        private List<Func<bool>> triggers;
        private Func<bool> triggerActive;
        public event Action ReadyToSwitch;
        public virtual void Init()
        {
            OnEnter();
            nodeStateMap = new Dictionary<Func<bool>, NodeState>();
            isCurrent = true;
            contextTriggerBuild.TrigerIsActivated += TriggerShut;
            triggers = GetTriggers();
            for(int i=0; i<linkedNodeState.Count; i++)
            {
                nodeStateMap.Add(triggers[i],linkedNodeState[i]);
            }
        }
        public virtual List<Func<bool>> GetTriggers()
        {
            triggers = new List<Func<bool>>();
            return triggers;
        }
        public virtual void StartNodeAction()
        {
            contextTriggerBuild.BuildTriggerSystem(triggers);
        }
        public void TriggerShut(Func<bool> trigger)
        {
            triggerActive = trigger;
            isCurrent = false;
            contextTriggerBuild.TrigerIsActivated -= TriggerShut;
            ReadyToSwitch.Invoke();
        }
        public virtual void OnEnter()
        {

        }
        public virtual void ExitNodeAction()
        {
           
        }
        public virtual NodeState EnterNodeAction()
        {
            return nodeStateMap[triggerActive];
        }
    }
}

