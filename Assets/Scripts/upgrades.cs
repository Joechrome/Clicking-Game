using System.Diagnostics;
using System.Runtime.ConstrainedExecution;
using UnityEngine;

public class Upgrade
{
    public string Description;
    public int Cost;
    public bool Owned;
    public Upgrade(string description,int cost)
    {
        Description = description;
        Cost = cost;
        Owned = false;
    }
    public int purchase(int coins)
    {
        if (Owned == false)
        {
            if (coins >= Cost) 
            {
                Owned = true;
                coins -= Cost;
                return coins;
            } 
            else 
            {
                return coins;
            }
        }
        else
        {
            return coins;
        }
    }
}

public class upgrades : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        coins = 100000;
        UnityEngine.Debug.Log(coins);
    }
    int coins;
    Upgrade Autoclicker = new Upgrade("automatically clicks for you",10000);
    Upgrade DoubleClick = new Upgrade("each click gives 2 coins", 100);
    Upgrade TripleClick = new Upgrade("each click gives 3 coins", 200);
    Upgrade QuadrupleClick = new Upgrade("each click gives 4 coins", 300);
    public void upgrade_button_press(string upgrade)
    {
        if (upgrade == "Autoclicker")
        {
            coins = Autoclicker.purchase(coins);
        }
        else if (upgrade == "DoubleClick")
        {
            coins = DoubleClick.purchase(coins);
        }
        else if (upgrade == "TripleClick")
        {
            coins = TripleClick.purchase(coins);
        }
        else if (upgrade == "QuadrupleClick")
        {
            coins = QuadrupleClick.purchase(coins);
        }
        UnityEngine.Debug.Log(coins);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
