using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
[Serializable]
public class Slot :MonoBehaviour
{
    [SerializeField] private string path;
    [SerializeField] private GameObject prefab;
    [SerializeField] private string pathMainSaveData;
    [SerializeField] private string pathTransformData;
    [SerializeField] private string pathOtherSaveData;   
    public string Path
    {
        get{
            return path;
        }
    }
    public GameObject Prefab
    {
        get
        {
            return prefab;
        }
    }
    public string PathMainSaveData
    {
        get
        {
            return pathMainSaveData;
        }
    }
    public string PathTransformData 
    {
        get 
        {
            return pathTransformData;
        }
    }
    public string PathOtherSaveData 
    {
        get
        {
            return pathOtherSaveData;
        }
    }
}
