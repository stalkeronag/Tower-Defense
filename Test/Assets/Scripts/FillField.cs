using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GridBuilder;
public abstract class IFillView:MonoBehaviour
{
    public abstract void Fill();
}
public class FillField : IFillView
{
    [SerializeField] private SquareGrid gridBuilder;
    [SerializeField] private List<GameObject> prefabsList;
    [SerializeField] private GameObject gameObjec;
    private List<Vector3> points;
    public void Awake()
    {
        gridBuilder.eventFill += FillSquare;
    }
    public override void Fill() => FillSquare(points);
    public void FillSquare(List<Vector3> pointsGrid)
    {
        prefabsList=new List<GameObject>();
        points=pointsGrid;  
        for(int i=0;i<points.Count;i++)
        {
            prefabsList.Add(Instantiate<GameObject>(gameObjec));
            prefabsList[i].transform.position = points[i];
            prefabsList[i].transform.SetParent(transform, false);
        }
    }
}
