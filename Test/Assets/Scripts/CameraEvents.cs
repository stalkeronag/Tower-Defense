using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
namespace CameraControl
{
    public class CameraEvents : MonoBehaviour
    {
        public event Action EventRotateCamera;
        public event Action EventMoveCamera;
        void Update()
        {
            if(Input.GetKeyDown(KeyCode.R))
            {
                EventRotateCamera?.Invoke();
            }
            if(Input.GetKeyDown(KeyCode.M))
            {
                EventMoveCamera?.Invoke();  
            }
        }
    }
}

