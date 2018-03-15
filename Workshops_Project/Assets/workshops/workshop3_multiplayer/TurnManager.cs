using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.WSA;

public class TurnManager : MonoBehaviour
{
    private List<Player> players;
    public GameObject ProtoType;
    public int CurrentPlayer = 0;
    public int CurrentTurn;
    public List<Material> playerMaterials;
    [Range(1,4)] public int PlayerCount;

    public GameObject selectedObject;


    void Start()
    {
        for (int i = 0; i < PlayerCount; i++)
        {
            GameObject newPlayer = Instantiate(ProtoType);
            newPlayer.transform.SetParent(gameObject.transform);
            newPlayer.transform.GetComponent<Player>().Name += i+1;
            newPlayer.transform.GetComponent<Player>().UpdateName();
        }
        players = new List<Player>();
        foreach (GameObject go in GameObject.FindGameObjectsWithTag("Player"))
        {
            players.Add(go.GetComponent<Player>());
        }

        int index = 0;
        foreach (Player player in players)
        {
            player.playerMaterial = playerMaterials.ElementAt(index);
            if (index != 0)
            {
                player.gameObject.SetActive(false);
            }
            index++;
        }
    }

    public void NextTurn()
    {
        selectedObject = null;
        if (CurrentPlayer == (players.Count -1))
        {
            CurrentPlayer = 0;
        }
        else
        {
            CurrentPlayer++;
        }

        int index = 0;
        foreach (Player player in players)
        {
            if (index != CurrentPlayer)
            {
                player.gameObject.SetActive(false);
            }
            else
            {
                player.gameObject.SetActive(true);
            }

            index++;
        }
    }

    public Player GetCurrentPlayer()
    {
        int index = 0;
        foreach (Player player in players)
        {
            if (index == CurrentPlayer)
            {
                return player;
            }

            index++;
        }
        Debug.LogError("No player has been found!");
        return null;
    }

    public void changeSelectedObject(GameObject go)
    {
        if(go.GetComponent<Barracks>() != null)
        {
            go.GetComponent<Barracks>().UI.gameObject.SetActive(true);
        }
        else if(go.GetComponent<Barracks>() == null && selectedObject.GetComponent<Barracks>().UI != null)
        {
            selectedObject.GetComponent<Barracks>().UI.gameObject.SetActive(false);
        }
        selectedObject = go;
    }
}
