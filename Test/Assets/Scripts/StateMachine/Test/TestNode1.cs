using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using StateMachine;
using System;
public class TestNode1 : NodeState
{
    public override List<Func<bool>> GetTriggers()
    {
        var triggers = new List<Func<bool>>();
        triggers.Add(() => Input.GetKeyDown(KeyCode.M));
        triggers.Add(() => Input.GetKeyDown(KeyCode.V));
        return triggers;
    }
    public override void StartNodeAction()
    {
        base.StartNodeAction();

        Debug.Log("Fisting is 300 bucks");
    }
}
