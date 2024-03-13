using System.Collections;
using System.Threading.Tasks;
using Unity.VisualScripting.Dependencies.NCalc;
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
    [SerializeField] private HeroData heroInfo;

    public int CritChance => critChance;
    public int CritDamage => critDamage;
    public int BaseDamage => damage;

    public AbilityData[] Abilities => abilities;
    public bool AbilityCell1Occupied { get; set; }
    public bool AbilityCell2Occupied { get; set; }

    public HeroData HeroInfo => heroInfo;

	private void Start()
	{
        damageLvl = heroInfo.DamageLvl;
        critChanceLvl = heroInfo.CritChanceLvl;
        critDamageLvl = heroInfo.CritDamageLvl;

        damage = heroInfo.Damage;
        critChance = heroInfo.CritChance;
        critDamage = heroInfo.CritDamage;
	}

	public void UpgradeStat(StatToUpgrade stat, int value)
    {
        switch (stat)
        {
            case StatToUpgrade.Damage:
                damage += value;
                damageLvl += 1;

                heroInfo.Damage = damage;
                heroInfo.DamageLvl = damageLvl;
                break;
            case StatToUpgrade.CritDamage:
                critDamage += value;
                critDamageLvl += 1;

                heroInfo.CritDamage = critDamage;
                heroInfo.CritDamageLvl = critDamageLvl;
                break;
            case StatToUpgrade.CritChance:
                critChance += value;
                critChanceLvl += 1;

                heroInfo.CritChance = critChance;
                heroInfo.CritChanceLvl = critChanceLvl;
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

    private bool doubleDamage;
    private bool doubleDamageReward;

    private IEnumerator DoubleDamage()
    {
        doubleDamage = true;
        yield return new WaitForSeconds(5);
        doubleDamage = false;
    }

    private IEnumerator DoubleDamageReward()
    {
        doubleDamageReward = true;
        yield return new WaitForSeconds(60);
        doubleDamageReward = false;
    }

    public void StartDoubleDamage()
    {
        StartCoroutine(DoubleDamage());
    }

    public void StartDoubleDamageReward()
    {
        StartCoroutine(DoubleDamageReward());
    }

    public int GetDamage()
    {
        int value = doubleDamage ? 2 : 1;
        int valueReward = doubleDamageReward ? 2 : 1;
        Debug.Log(damage * value * valueReward);
        return damage * value * valueReward;
    }
}
