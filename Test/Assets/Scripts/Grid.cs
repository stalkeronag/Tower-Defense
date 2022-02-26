using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GridBuilder
{
    public abstract class IGrid : MonoBehaviour
    {
        public abstract void MadeGrid();
        public abstract void DeleteGrid();
    }
    public class Grid : MonoBehaviour
    {
        [SerializeField] public IGrid gridBuild;
        public void Start()
        {
            gridBuild.MadeGrid();
        }
    }
  
}

