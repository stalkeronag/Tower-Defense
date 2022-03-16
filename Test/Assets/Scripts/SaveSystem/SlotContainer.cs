using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;

public class SlotContainerExepction :Exception
{
    public SlotContainerExepction(string message) : base(message) { }
}
public class SlotContainer : MonoBehaviour
{
    [SerializeField] private List<Slot> slots;
    public string PathRoot =>Application.persistentDataPath;
    public void AddSlot(Slot slot) 
    {
        CheckNameSlot(slot);
        slots.Add(slot);
        string pathSlot = Path.Combine(PathRoot, slot.Path);
        Directory.CreateDirectory(pathSlot);
    }
    public void RemoveSlot(Slot slot) 
    {
        slots.Remove(slot);
        string pathSlot = Path.Combine(PathRoot, slot.Path);
        if (Directory.Exists(pathSlot))
        Directory.Delete(pathSlot,true);
    }
    public void CheckNameSlot(Slot slot)
    {
        if(slots.Contains(slot))
        throw new SlotContainerExepction("не уникальное имя");
    }
}
