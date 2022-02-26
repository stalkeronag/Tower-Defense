using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
namespace GridBuilder
{
    public class SquareGrid : IGrid
    {
        [SerializeField] private List<Vector3> points;
        [SerializeField] private float sizeSquare=10;
        [SerializeField] private int width;
        [SerializeField] private int height;
        public event Action<List<Vector3>> eventFill;
        public override void DeleteGrid()
        {
           points.Clear();
        }
        public override void MadeGrid()
        {
            points = new List<Vector3>();
            var countOfSquares=width*height;
            Vector3 position=transform.position;    
            for(int i=0; i<width; i++)
            {
                for(int j=0; j<height; j++)
                {
                    Vector3 offset = new Vector3(i * sizeSquare, position.y, j * sizeSquare);
                    Vector3 point = offset + position;       
                    points.Add(position+offset);
                }
            }
            eventFill.Invoke(points);
        }
    }
}

