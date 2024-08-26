using System.Collections;
using System.Collections.Generic;
using System.Net.Http.Headers;
using Unity.VisualScripting;
using UnityEngine;
using Core.Singleton;
using TMPro;

public class ItemManager : Core.Singleton.Singleton<ItemManager>
{
    public TextMeshProUGUI txCoin;
    public TextMeshProUGUI txPlanet;
    
    public SOInt coins;
    public SOInt planets;
    public void Start()
    {
        Reset();
    }
    private void Reset()
    {
        coins.value = 0;
        planets.value = 0;
    }
    public void AddCoins(int amount = 1)
    {
        coins.value += amount;
        txCoin.text = "x "+coins.ToString();
    }
    public void AddPlanets(int amount = 1)
    {
        planets.value += amount;
        txPlanet.text = "x "+planets.ToString();
    }
}
