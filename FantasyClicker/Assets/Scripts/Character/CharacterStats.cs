using System.Collections.Generic;
using UnityEngine;

public class CharacterStats : MonoBehaviour
{
    [SerializeField] private int damage;
    [SerializeField] private int critDamage;
    [SerializeField] private int critChance;

        private int coins;

    public int Coins => coins;

    public int Damage => damage;
    public int CritChance => critChance;
    public int CritDamage => critDamage;

    private void Awake()
    {
        EventManager.OnCharacterRewarded.AddListener(AddCoins);
    }

    private void AddCoins(int reward)
    {
        coins += reward;
    }

    public void DecreaseCoins(int value)
    {
        coins -= value;
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
