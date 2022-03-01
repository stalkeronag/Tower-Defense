using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace CameraControl
{
    public class TriggersHandler : MonoBehaviour
    {
        public event Action<Func<bool>> triggerIsActivated;
        private List<Func<bool>> trigers;
        public List<Func<bool>> Triggers
        {
            get { return trigers; }
            set { trigers = value; }
        }
        public void AddTrigger(Func<bool> trigger)
        {
            Triggers = Triggers ?? new List<Func<bool>>();
            Triggers.Add(trigger);   
        }
        void Update()
        {
            for (int i = 0; i < Triggers.Count; i++)
            {
                if(Triggers[i].Invoke())
                {
                    triggerIsActivated.Invoke(trigers[i]);
                }
            }
        }
    }
}

