using UnityEngine;

public class Upgrade
{
    public string Name;
    public string Description;
    public int Cost;
    public bool Owned;

    public Upgrade(string name, string description, int cost)
    {
        Name = name;
        Description = description;
        Cost = cost;

        // Restore the purchase from the save file, so an upgrade bought in an
        // earlier session still counts as owned.
        Owned = GameData.IsUpgradeOwned(name);
    }

    public bool TryPurchase()
    {
        if (Owned)
        {
            return false;
        }

        // Spend() checks the balance itself and changes nothing if the player is
        // short, so the score and the Owned flag can never disagree.
        if (!GameData.Spend(Cost))
        {
            return false;
        }

        Owned = true;
        GameData.MarkUpgradeOwned(Name);
        return true;
    }
}

public class upgrades : MonoBehaviour
{
    private Upgrade _autoclicker;
    private Upgrade _doubleClick;
    private Upgrade _tripleClick;
    private Upgrade _quadrupleClick;

    void Awake()
    {
        _autoclicker = new Upgrade("Autoclicker", "automatically clicks for you", 10000);
        _doubleClick = new Upgrade("DoubleClick", "each click gives 2 coins", 100);
        _tripleClick = new Upgrade("TripleClick", "each click gives 3 coins", 200);
        _quadrupleClick = new Upgrade("QuadrupleClick", "each click gives 4 coins", 300);
    }

    public void upgrade_button_press(string upgrade)
    {
        Upgrade target = Find(upgrade);

        if (target == null)
        {
            // Loud rather than silent. A name that matched nothing used to do
            // absolutely nothing with no explanation at all.
            Debug.LogWarning(
                $"{name}: no upgrade called '{upgrade}'. Check the Upgrade Name on " +
                "the button matches a name in upgrades.cs.",
                this);
            return;
        }

        if (target.TryPurchase())
        {
            Debug.Log($"Bought {target.Name}. Score left: {GameData.Clicks}");
        }
        else
        {
            Debug.Log(
                $"Could not buy {target.Name}. Cost {target.Cost}, " +
                $"score {GameData.Clicks}, already owned: {target.Owned}.");
        }
    }

    private Upgrade Find(string upgrade)
    {
        if (upgrade == _autoclicker.Name) return _autoclicker;
        if (upgrade == _doubleClick.Name) return _doubleClick;
        if (upgrade == _tripleClick.Name) return _tripleClick;
        if (upgrade == _quadrupleClick.Name) return _quadrupleClick;
        return null;
    }
}
