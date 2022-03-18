using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class HighlightArea : ISelectable
{
   [SerializeField] private Color defaultColor;
   [SerializeField] private Color colorHighlight;
   public override event Action ActionEnd;
   public override void ActionAfterSelect()
   {
       StartCoroutine(timer());
   }
    public override void ActionAfterDeselect() => gameObject.GetComponent<MeshRenderer>().material.color = defaultColor;
    public IEnumerator timer()
   {
       float time = 0;
       gameObject.GetComponent<MeshRenderer>().material.color = colorHighlight;
       while(time<0.5f)
       {
           time+=Time.deltaTime;
           yield return null;
       }  
       ActionEnd.Invoke();

   }
}
