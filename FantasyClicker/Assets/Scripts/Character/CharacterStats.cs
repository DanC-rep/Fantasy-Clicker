using UnityEngine;

public class CharacterStats : MonoBehaviour
{
    [SerializeField] private int damage;
    [SerializeField] private int critDamage;
    [SerializeField] private int critChance;

    [SerializeField] private AbilityData[] abilities;

    private int coins;
    public int Coins => coins;

    public int Damage => damage;
    public int CritChance => critChance;
    public int CritDamage => critDamage;

    public AbilityData[] Abilities => abilities;
    public bool AbilityCell1Occupied { get; set; }
    public bool AbilityCell2Occupied { get; set; }

    private void Awake()
    {
        EventManager.OnCharacterRewarded.AddListener(AddCoins);
    }

    private void AddCoins(int reward)
    {
        coins += reward;
        EventManager.SendCharacterCoinsChanged(this);
    }

    public void DecreaseCoins(int value)
    {
        coins -= value;
        EventManager.SendCharacterCoinsChanged(this);
    }

    public void UpgradeStat(StatToUpgrade stat, int value)
    {
        switch (stat)
        {
            case StatToUpgrade.Damage:
                damage += value;
                break;
            case StatToUpgrade.CritDamage:
                critDamage += value;
                break;
            case StatToUpgrade.CritChance:
                critChance += value;
                break;
        }
    }

    public int GetStatValue(StatToUpgrade stat)
    {
        switch (stat)
        {
            case StatToUpgrade.Damage:
                return damage;
            case StatToUpgrade.CritDamage:
                return critDamage;
            case StatToUpgrade.CritChance:
                return critChance;
            default:
                return 0;
        }
    }
}
