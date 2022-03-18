using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public abstract class ISelectable:MonoBehaviour
{
    public abstract event Action ActionEnd;
    public abstract void ActionAfterSelect();
    public abstract void ActionAfterDeselect();
}
