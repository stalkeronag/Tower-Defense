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
    public override void StartNodeAction()
    {
        base.StartNodeAction();
        StartCoroutine(StartFisting());
    }
    public IEnumerator StartFisting()
    {
        int i=0;
        while(isCurrent)
        {
            i++;
            string fas = i + " Fucking Slave";
            Debug.Log(fas);
            yield return null;
        }
    }
}
