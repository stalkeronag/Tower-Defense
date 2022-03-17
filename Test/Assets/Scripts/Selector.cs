using System.Net;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Selector : MonoBehaviour
{

    public event Action SelectAction;
    private bool isWaiting=false;
    public bool IsWaiting
    {
        get{return isWaiting;}
        set{isWaiting=value;}
    }
    public void Update()
    {
        
       if(!isWaiting)
       {
             RaycastHit nextHit ;
             Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if(Physics.Raycast(ray,out nextHit))
             {
                 
              isWaiting = true;
              SelectAction.Invoke();
              StartCoroutine(UntilAction());
             }
       } 
    }
    public IEnumerator UntilAction()
    {
        while(isWaiting)
        {
            yield return null;
        }
    }
}
