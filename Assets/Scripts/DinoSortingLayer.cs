using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DinoSortingLayer : MonoBehaviour
{

     public GameObject target;

    public void ChangeOrderInLayer() 
    {
        target.GetComponent<Renderer>().sortingLayerID = SortingLayer.NameToID("Covered Enemy"); 
    }
}
