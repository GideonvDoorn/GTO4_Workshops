using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Map : MonoBehaviour
{

    public int SizeX;
    public int SizeY;

    public Cell ProtoType;

    public float TileOffset = 1;

    public void Start()
    {
        Spawn();
    }

    public void Spawn()
    {
        float xoffset = 0;
        for (int x = 0; x < SizeX; x++)
        {
            float yoffset = 0;
            for (int y = 0; y < SizeY; y++)
            {
                Cell newTile = Instantiate(ProtoType);
                newTile.transform.SetParent(transform);
                newTile.transform.localPosition = new Vector3(xoffset,0,yoffset);
                newTile.name = String.Format("Cell {0}x{1}", x, y);

                newTile.X = x;
                newTile.Y = y;

                yoffset += TileOffset;
            }

            xoffset += TileOffset;
        }
    }

    [ContextMenu("Test Cell 3,4")]
    public void Test()
    {
        Cell test = GetCell(3, 4);
        Debug.Log(test.name,test);
    }

    public Cell GetCell(int x, int y)
    {
        if (x >= SizeX || y >= SizeY)
        {
            Debug.Log("OutOfBounds");
            return null;
        }

        if (transform.GetChild((x * SizeX) + y).GetComponent<Cell>().transform.childCount > 1)
        {
            Debug.LogError(String.Format("Already a unit on that space ({0},{1})",x,y));
            return null;
        }
        return transform.GetChild((x * SizeX)+y).GetComponent<Cell>();
    }
}
