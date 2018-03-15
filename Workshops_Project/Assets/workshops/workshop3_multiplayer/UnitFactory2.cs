using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitFactory2 : MonoBehaviour
{
    public Ownable ProtoType;
    public Map Map;

    public int X;
    public int Y;

    public List<ResourceCost> Cost;

    void Start()
    {
        Map = GameObject.FindGameObjectWithTag("Map").GetComponent<Map>();
        Debug.Log(Map);
    }

    public void SpawnUnit()
    {
        bool canAfford = true;
        for (int i = 0; i < Cost.Count; i++)
        {
            if (!Cost[i].CantAfford())
            {
                canAfford = false;
            }
        }

        Cell cell = Map.GetCell(X, Y);

        if (cell == null)
            return;

        if (canAfford)
        {
            for (int i = 0; i < Cost.Count; i++)
            {
                Cost[i].Pay();
            }
            Ownable newUnit = Instantiate(ProtoType);
            try
            {
                if (gameObject.GetComponentInParent<Player>() != null)
                {
                    newUnit.Owner = gameObject.GetComponentInParent<Player>();
                    for (int i = 0; i < newUnit.transform.childCount; i++)
                    {
                        newUnit.transform.GetChild(i).gameObject.GetComponent<Renderer>().material = newUnit.Owner.playerMaterial;
                    }
                }
                else
                {
                    newUnit.Owner = gameObject.GetComponentInParent<Barracks>().Owner;
                    for (int i = 0; i < newUnit.transform.childCount; i++)
                    {
                        newUnit.transform.GetChild(i).gameObject.GetComponent<Renderer>().material = newUnit.Owner.playerMaterial;
                    }
                }

            }
            catch (Exception e)
            {
                Debug.Log(e);
            }
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
