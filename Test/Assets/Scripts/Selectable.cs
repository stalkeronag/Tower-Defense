using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public interface ISelectable
{
    public event Action ActionEnd;
    public void ActionAfterSelect();
}
public class Selectable:MonoBehaviour,ISelectable
{
   public event Action ActionEnd;
   public void ActionAfterSelect()
   {
     ActionEnd.Invoke();
   }

}
