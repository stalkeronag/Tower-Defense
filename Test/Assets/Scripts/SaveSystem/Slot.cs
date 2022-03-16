using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
[Serializable]
public class Slot :MonoBehaviour
{
    [SerializeField] private string path;
    [SerializeField] private SavePosition savePosition;
    [SerializeField] private SaveRotation saveRotation;
    [SerializeField] private GameObject prefab;
    [SerializeField] private string pathMainSaveData;
    [SerializeField] private string pathTransformData;
    [SerializeField] private string pathOtherSaveData;
    public string Path => path;
    public GameObject Prefab => prefab;
    public string PathMainSaveData => pathMainSaveData;
    public string PathTransformData => pathTransformData;
    public string PathOtherSaveData => pathOtherSaveData;
    public void Init()
    {
      
    }
}
