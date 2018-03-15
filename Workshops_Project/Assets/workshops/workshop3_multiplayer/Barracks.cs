using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Barracks : Ownable
{

    public string Name;
    public UnitFactory ProtoType;
    public Canvas UI;

    //public void OnPointerClick(PointerEventData eventData)
    //{

    //    if (GameObject.FindGameObjectWithTag("TurnManager").GetComponent<TurnManager>().GetCurrentPlayer() == Owner)
    //    {
    //        GameObject.FindGameObjectWithTag("TurnManager").GetComponent<TurnManager>().changeSelectedObject(gameObject);
    //        UI.gameObject.SetActive(true);
    //        Debug.Log("Clicked on ownable");

    //    }

    //}

}
