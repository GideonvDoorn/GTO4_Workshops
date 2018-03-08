using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    PlayerResources resources;

    public void BuyStar()
    {
        resources.BuyStar();
    }

    public void GetCoins(int amount)
    {
        resources.AddCoinsToCoinCount(amount);
    }

    private void Awake()
    {
        resources = GetComponent<PlayerResources>();
    }
}
