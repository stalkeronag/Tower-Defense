using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace StateMachine
{
    public class SimpleTriggerHandler : NodeBuildTriggerContext
    {
        public override event Action<Func<bool>> TrigerIsActivated;
        public TriggerChecker checker;
        public override void BuildTriggerSystem(List<Func<bool>> triggers)
        {
            checker = new TriggerChecker(triggers);
            StartCoroutine(UntilTriggerStart(checker.CheckTrigger));
        }
        public IEnumerator UntilTriggerStart(Func<bool> triggerCheck)
        {
            while(!triggerCheck.Invoke())
            {
                yield return null;
            }
            Func<bool> trigger = checker.ActiveTrigger;
            TrigerIsActivated(trigger);
        }
    }
}

