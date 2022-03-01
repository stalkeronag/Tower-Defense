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
        public event Action EventStopCamera;
        void Update()
        {
            if(Input.GetKeyDown(KeyCode.M))
            {
                EventMoveCamera?.Invoke();
            }
            if(Input.GetKeyDown(KeyCode.R))
            {
                EventRotateCamera?.Invoke();  
            }
            if(Input.GetKeyDown(KeyCode.A))
            {
                EventStopCamera?.Invoke();  
            }
        }
    }
}

