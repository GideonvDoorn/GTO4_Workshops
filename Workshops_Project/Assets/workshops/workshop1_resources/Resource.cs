using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class Resource : MonoBehaviour {

    public int Amount;
    [SerializeField]private int StartAmount;
    public Text resourceText;

    public UnityEvent evt;



    public void AddAmount(int amount)
    {
        if(amount < 0)
        {
            Debug.LogError("Amount must be positive!");
            return;
        }
        this.Amount += amount;
        UpdateUI();
    }

    public void SubtractAMount(int amount)
    {
        if (amount < 0)
        {
            Debug.LogError("Amount must be positive!");
            return;
        }
        this.Amount -= amount;
        UpdateUI();
    }

    public bool CantAfford(int cost)
    {
        return Amount >= cost;
    }

    private void UpdateUI()
    {
        evt.Invoke();
    }
}
