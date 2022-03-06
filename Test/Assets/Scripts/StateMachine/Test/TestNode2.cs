using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using StateMachine;
using System;

public class TestNode2 : NodeState
{
    public override List<Func<bool>> GetTriggers()
    {
        var triggers = new List<Func<bool>>();
        triggers.Add(() => Input.GetKeyDown(KeyCode.E));
        triggers.Add(() => Input.GetKeyDown(KeyCode.V));
        return triggers;
    }
    protected override void NodeAction()
    {
        transform.position = transform.position + Vector3.left * Time.deltaTime;
    }
}
