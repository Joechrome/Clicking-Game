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
}
public class upgrades : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Upgrade Autoclicker = new Upgrade("automatically clicks for you",10000);
        Upgrade DoubleClick = new Upgrade("each click gives 2 coins", 100);
        Upgrade TripleClick = new Upgrade("each click gives 3 coins", 200);
        Upgrade QuadrupleClick = new Upgrade("each click gives 4 coins", 300);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
