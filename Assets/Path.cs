using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Path : MonoBehaviour
{

    Transform[] tiles;

    public List<Transform> tilesList = new List<Transform>();

    


    void Start()
    {
        FillNodes();
    }
    void FillNodes()
    {
        tilesList.Clear();

        tiles = GetComponentsInChildren<Transform>();

        foreach (Transform tile in tiles)
        {
            if (tile != this.transform)
            {
                tilesList.Add(tile); 
            }
        }
    }

    
}
