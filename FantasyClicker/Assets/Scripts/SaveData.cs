using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UIElements;
using YG;

public class SaveData : MonoBehaviour
{
	[SerializeField] private List<AbilityData> abilityData;
	[SerializeField] private List<HeroData> heroData;
	[SerializeField] private List<LocationData> locationData;
	[SerializeField] private List<EnemyStats> enemies;
	[SerializeField] private Tutorial tutorial;

	private void Start()
	{
		StartCoroutine(CheckPluginEnabled());
	}

	private IEnumerator CheckPluginEnabled()
	{
		while (!YandexGame.SDKEnabled)
		{
			yield return new WaitForSeconds(0.2f);
		}

		GetLoad();
		EventManager.OnCharacterCoinsChanged.AddListener(SaveCoins);
		EventManager.OnTutorialShowed.AddListener(SaveTutorialStatus);
		EventManager.OnSoundModeChanged.AddListener(SaveSoundStatus);
		EventManager.OnAbilityPurchased.AddListener(SaveAbilityData);
		EventManager.OnHeroPurchased.AddListener(SaveHeroData);
		EventManager.OnLocationPurchased.AddListener(SaveLocationData);
		EventManager.OnHeroStatsUpgraded.AddListener(SaveHeroStats);
		EventManager.OnEnemyKillCountChanged.AddListener(SaveEnemyKillCount);
		EventManager.OnCharacterInstantiated.AddListener(SaveCurrentHero);
	}

	public void SaveTutorialStatus(bool showed)
	{
		YandexGame.savesData.TutorialShowed = showed;
		YandexGame.SaveProgress();
	}

	public void SaveSoundStatus(bool muted)
	{
		YandexGame.savesData.SoundMuted = muted;
		YandexGame.SaveProgress();
	}

	public void SaveAbilityData(AbilityData ability)
	{
		YandexGame.savesData.Abilities[ability.Id] = ability.Purchased;
		YandexGame.SaveProgress();
	}

	public void SaveHeroData(HeroData hero)
	{
		YandexGame.savesData.Heroes[hero.Id] = hero.Purchased;
		YandexGame.SaveProgress();
	}

	public void SaveLocationData(LocationData location)
	{
		YandexGame.savesData.Locations[location.Id] = location.Purchased;
		YandexGame.SaveProgress();
	}

	public void SaveHeroStats(HeroData hero)
	{
		YandexGame.savesData.HeroDamage[hero.Id] = hero.Damage;
		YandexGame.savesData.HeroCritChance[hero.Id] = hero.CritChance;
		YandexGame.savesData.HeroCritDamage[hero.Id] = hero.CritDamage;

		YandexGame.savesData.HeroDamageLvl[hero.Id] = hero.DamageLvl;
		YandexGame.savesData.HeroCritChanceLvl[hero.Id] = hero.CritChanceLvl;
		YandexGame.savesData.HeroCritDamageLvl[hero.Id] = hero.CritDamageLvl;

		YandexGame.SaveProgress();
	}

	public void SaveCurrentHero(CharacterStats stats)
	{
		YandexGame.savesData.CurrentHeroId = stats.HeroInfo.Id;
		YandexGame.SaveProgress();
	}

	public void SaveCoins()
	{
		YandexGame.savesData.Coins = PlayerCoins.instance.Coins;
		YandexGame.SaveProgress();
	}

	public void SaveTotalCoins(int value)
	{
		YandexGame.savesData.TotalCoins += value;
		YandexGame.SaveProgress();
	}

	public void SaveEnemyKillCount(IEnemyInfo enemy)
	{
		YandexGame.savesData.EnemyKillCount[enemy.Id] = enemy.KillCount;
		YandexGame.SaveProgress();
	}

	public void GetLoad()
	{
		CheckEmpty(YandexGame.savesData.Abilities, abilityData.AsEnumerable<IPurchaseable>());
		CheckEmpty(YandexGame.savesData.Heroes, heroData.AsEnumerable<IPurchaseable>());
		CheckEmpty(YandexGame.savesData.Locations, locationData.AsEnumerable<IPurchaseable>());

		CheckEmpty(heroData);

		CheckEmpty(YandexGame.savesData.EnemyKillCount, enemies);

		PlayerCoins.instance.SetCoins(YandexGame.savesData.Coins);

		if (tutorial != null)
		{
			tutorial.TutorialShowed = YandexGame.savesData.TutorialShowed;
			tutorial.StartCheckPluginEnable();
		}

		SoundMode.instance.SetSoundMode(YandexGame.savesData.SoundMuted);

		Statistic.instance.SetSimpleStat(SimpleStatEn.Coins, YandexGame.savesData.TotalCoins);

		HeroesManager.instance.Hero = heroData.Where(h => h.Id == YandexGame.savesData.CurrentHeroId).First().Hero;
		HeroesManager.instance.InstantiateHero();
	}

	private void CheckEmpty(List<bool> saveList, IEnumerable<IPurchaseable> list)
	{
		if (saveList.Count == 0)
		{
			foreach (var l in list)
			{
				saveList.Add(l.Purchased);
			}
			YandexGame.SaveProgress();
		}
		else
		{
			LoadData(saveList, list);
		}
	}

	private void CheckEmpty(List<int> saveList, IEnumerable<EnemyStats> list)
	{
		if (saveList.Count == 0)
		{
			foreach (var l in list)
			{
				saveList.Add(l.KillCount);
			}
			YandexGame.SaveProgress();
		}
		else
		{
			LoadData(saveList, list);
		}
	}

	private void CheckEmpty(IEnumerable<HeroData> list)
	{
		if (YandexGame.savesData.HeroDamage.Count == 0)
		{
			foreach (var l in list)
			{
				YandexGame.savesData.HeroDamage.Add(l.Damage);
				YandexGame.savesData.HeroCritChance.Add(l.CritChance);
				YandexGame.savesData.HeroCritDamage.Add(l.CritDamage);
				YandexGame.savesData.HeroDamageLvl.Add(l.DamageLvl);
				YandexGame.savesData.HeroCritChanceLvl.Add(l.CritChanceLvl);
				YandexGame.savesData.HeroCritDamageLvl.Add(l.CritDamageLvl);
			}
			YandexGame.SaveProgress();
		}
		else
		{
			LoadData(list);
		}
	}

	private void LoadData(List<bool> saveList, IEnumerable<IPurchaseable> list)
	{
		foreach (var a in list)
		{
			a.Purchased = saveList[a.Id];
		}
	}

	private void LoadData(List<int> saveList, IEnumerable<EnemyStats> list)
	{
		foreach (var l in list)
		{
			l.SetKillCount(saveList[l.Id]);
		}
	}

	private void LoadData(IEnumerable<HeroData> list)
	{
		foreach (var l in list)
		{
			l.Damage = YandexGame.savesData.HeroDamage[l.Id];
			l.CritChance = YandexGame.savesData.HeroCritChance[l.Id];
			l.CritDamage = YandexGame.savesData.HeroCritDamage[l.Id];
			l.DamageLvl = YandexGame.savesData.HeroDamageLvl[l.Id];
			l.CritChanceLvl = YandexGame.savesData.HeroCritChanceLvl[l.Id];
			l.CritDamageLvl = YandexGame.savesData.HeroCritDamageLvl[l.Id];
		}
	}
}
