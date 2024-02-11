using System.Threading.Tasks;
using UnityEngine;

public class CharacterStats : MonoBehaviour
{
    [SerializeField] private int damage;
    [SerializeField] private int critDamage;
    [SerializeField] private int critChance;

    private int damageLvl;
    private int critDamageLvl;
    private int critChanceLvl;

    [SerializeField] private AbilityData[] abilities;

    public int Damage => damage;
    public int CritChance => critChance;
    public int CritDamage => critDamage;

    public AbilityData[] Abilities => abilities;
    public bool AbilityCell1Occupied { get; set; }
    public bool AbilityCell2Occupied { get; set; }

    public void UpgradeStat(StatToUpgrade stat, int value)
    {
        switch (stat)
        {
            case StatToUpgrade.Damage:
                damage += value;
                damageLvl += 1;
                break;
            case StatToUpgrade.CritDamage:
                critDamage += value;
                critDamageLvl += 1;
                break;
            case StatToUpgrade.CritChance:
                critChance += value;
                critChanceLvl += 1;
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

    public int GetStatLvl(StatToUpgrade stat)
    {
		switch (stat)
		{
			case StatToUpgrade.Damage:
				return damageLvl;
			case StatToUpgrade.CritDamage:
				return critDamageLvl;
			case StatToUpgrade.CritChance:
				return critChanceLvl;
			default:
				return 0;
		}
	}

    public async void DoubleDamage()
    {
        int currentDmg = damage;
        damage *= 2;
        await Task.Delay(5000);
        damage = currentDmg;
    }
}
