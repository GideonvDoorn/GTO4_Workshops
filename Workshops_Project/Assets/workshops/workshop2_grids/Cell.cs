using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Cell : MonoBehaviour, IPointerClickHandler
{

    

    public int X;

    public int Y;

    public void OnPointerClick(PointerEventData eventData)
    {

        Debug.Log("clicked on tile");

        GameObject selectedObject = GameObject.FindGameObjectWithTag("TurnManager").GetComponent<TurnManager>().selectedObject;

        if(selectedObject == null || transform.childCount > 1)
        {
            return;
        }

        selectedObject.transform.SetParent(gameObject.transform);
        selectedObject.transform.localPosition = new Vector3(0, 0, 0);

        GameObject.FindGameObjectWithTag("TurnManager").GetComponent<TurnManager>().selectedObject = null;
    }
}
