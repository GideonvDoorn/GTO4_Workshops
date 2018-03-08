using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerResources : MonoBehaviour {
    
    private int starCount = 0;
    private int coinCount = 0;
    public Text StarText;
    public Text CoinText;

    public GameObject ResourcesPanel; 

    public int StarCount
    {
        get
        {
            return starCount;
        }
        set
        {
            starCount = value;
            UpdateUI();
        }
    }

    public int CoinCount
    {
        get
        {
            return coinCount;
        }
        set
        {
            if(value < 0)
            {
                CoinCount = 0;
            }
            else
            {
                coinCount = value;
            }
            UpdateUI();
        }
    }

    public void AddCoinsToCoinCount(int coinsToAdd)
    {
        CoinCount += coinsToAdd;
    }

	public void UpdateUI () {
        StarText.text = StarCount.ToString();
        CoinText.text = CoinCount.ToString();
    }

    public bool BuyStar()
    {
        if(CoinCount < 20)
        {
            return false;
        }
        StarCount++;
        CoinCount -= 20;
        return true;
    }
}
