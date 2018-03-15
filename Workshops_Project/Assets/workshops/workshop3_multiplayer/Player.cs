using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public string Name;
    public int Score;
    public Text UIPlayerName;
    public Material playerMaterial;

    void Awake()
    {
        UIPlayerName.text = Name;
    }

    public void UpdateName()
    {
        UIPlayerName.text = Name;
    }
}
