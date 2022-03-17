using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testCub : MonoBehaviour
{
    [SerializeField] private Selector selector;
    void Start()
    {
         selector.SelectAction+=Mess;
    }
    public void Mess()
    {
        Debug.Log("Ass we can");
        selector.IsWaiting = false;
    }
}
