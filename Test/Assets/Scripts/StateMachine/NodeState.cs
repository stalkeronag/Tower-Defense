using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace StateMachine
{
    [System.Serializable]
    public class DescriptionNodeState
    {
        [SerializeField] protected List<NodeState> linkedNodeState;
        [SerializeField] protected int exitTime;
        [SerializeField] protected bool isCurrent;
        [SerializeField] protected bool isNext;
    }
    public abstract class NodeState : MonoBehaviour
    {
        [SerializeField] protected DescriptionNodeState descriptionNodeState;
        public event Action ReadyToSwitch;
        public abstract void StartNodeAction();
        public abstract void ExitNodeAction();
        public abstract NodeState EnterNodeAction();
    }
}

