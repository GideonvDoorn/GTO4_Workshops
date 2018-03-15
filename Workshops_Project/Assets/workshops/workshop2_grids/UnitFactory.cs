using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitFactory : MonoBehaviour
{
    public Unit ProtoType;
    public Map Map;

    public int X;
    public int Y;

    public List<ResourceCost> Cost;


    public void SpawnUnit()
    {
        bool cantafford = true;
        for (int i = 0; i < Cost.Count; i++)
        {
            if (!Cost[i].CantAfford())
            {
                cantafford = false;
            }
        }

        Cell cell = Map.GetCell(X, Y);

        if (cell == null)
            return;

        if (cantafford)
        {
            for (int i = 0; i < Cost.Count; i++)
            {
                Cost[i].Pay();
            }
            Unit newUnit = Instantiate(ProtoType);
            
            newUnit.transform.SetParent(cell.transform, false);
        }
        else
        {
            Debug.Log("Insufficient Funds.");
        }
    }

    [Serializable]
    public class ResourceCost
    {
        public Resource Resource;
        public int Cost = 1;

        public bool CantAfford()
        {
            return Resource.CantAfford(Cost);
        }

        public void Pay()
        {

            Resource.SubtractAMount(Cost);
        }
    }
}
