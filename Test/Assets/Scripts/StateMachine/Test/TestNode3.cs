using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using StateMachine;
using System;
public class TestNode3 : NodeState
{
    public override List<Func<bool>> GetTriggers()
    {
        var triggers = new List<Func<bool>>();
        triggers.Add(() => Input.GetKeyDown(KeyCode.E));
        triggers.Add(() => Input.GetKeyDown(KeyCode.M));
        return triggers;
    }
    public override void StartNodeAction()
    {
        base.StartNodeAction();
        Debug.Log("Oh shit i am sorry");
    }
  }
