using System.Net;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Selector : MonoBehaviour
{
    private ISelectable currentSelectable;
    private bool isWaiting=false;
    public void Update()
    {
        if(!isWaiting)
        {
            TrySelectArea();
        }
    }
    public void TrySelectArea()
    {      
            RaycastHit hit ;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if(Physics.Raycast(ray,out hit))
             {
                 
              ISelectable selectableObject = hit.collider.gameObject.GetComponent<ISelectable>();  
              if(currentSelectable==selectableObject)
              {
                   UnLock();
                   return;
              }
              else
              {
                  currentSelectable?.ActionAfterDeselect();
              }
              if(selectableObject!=null)
              {
                   OnLock();
                  selectableObject.ActionEnd +=UnLock;
                  selectableObject.ActionAfterSelect();
                  currentSelectable = selectableObject;
              }
              else
              {
                UnLock(); 
              }        
             }
    }
    public void OnLock() =>isWaiting = true;
    public void UnLock() => isWaiting = false;
}
