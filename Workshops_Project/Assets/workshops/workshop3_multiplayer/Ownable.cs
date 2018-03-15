using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public abstract class Ownable : MonoBehaviour, IPointerClickHandler
{
    public Player Owner;

    public void OnPointerClick(PointerEventData eventData)
    {
        
        Debug.Log("Clicked on ownable");

        if(GameObject.FindGameObjectWithTag("TurnManager").GetComponent<TurnManager>().GetCurrentPlayer() == Owner)
        {
            GameObject.FindGameObjectWithTag("TurnManager").GetComponent<TurnManager>().changeSelectedObject(gameObject);

        }

    }
}
