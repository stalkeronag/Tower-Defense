using System.Security.AccessControl;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
public class SlotContainer : MonoBehaviour
{
    [SerializeField] private List<Slot> slots;
    public void AddSlot(Slot slot) 
    {
        slots.Add(slot);
        Directory.CreateDirectory(slot.Path);
    }
    public void RemoveSlot(Slot slot) 
    {
        slots.Remove(slot);
        Directory.Delete(slot.Path,true);
    }
}
