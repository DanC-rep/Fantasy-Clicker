using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using YG;

public class RewardAd : MonoBehaviour
{
	[SerializeField] private Button coinsBtn;
	[SerializeField] private Button damageBtn;

	[SerializeField] private UpgradeStats damageStat;
	[SerializeField] private UpgradeStats critDamageStat;
	[SerializeField] private UpgradeStats critChanceStat;

	private void OnEnable() => YandexGame.RewardVideoEvent += Rewarded;

	private void OnDisable() => YandexGame.RewardVideoEvent -= Rewarded;

	private void Rewarded(int id)
	{
		if (id == 1)
		{
			PlayerCoins.instance.StartDoubleCoinsReward();
			StartCoroutine(UseCooldown(coinsBtn));
		}
		else if (id == 2)
		{
			HeroesManager.instance.CurrentHero.StartDoubleDamageReward();
			StartCoroutine(UseCooldown(damageBtn));
		}
		else if (id == 3)
		{
			damageStat.UpgradeStat(true);

			if (!damageStat.CheckNotReachMaxLvl())
			{
				damageStat.RewardBtn.interactable = false;
				return;
			}

			StartCoroutine(UseCooldownStatBtn(damageStat.RewardBtn, damageStat));
		}
		else if (id == 4)
		{
			critChanceStat.UpgradeStat(true);

			if (!critChanceStat.CheckNotReachMaxLvl())
			{
				critChanceStat.RewardBtn.interactable = false;
				return;
			}

			StartCoroutine(UseCooldownStatBtn(critChanceStat.RewardBtn, critChanceStat));
		}
		else if (id == 5)
		{
			critDamageStat.UpgradeStat(true);

			if (!critDamageStat.CheckNotReachMaxLvl())
			{
				critDamageStat.RewardBtn.interactable = false;
				return;
			}

			StartCoroutine(UseCooldownStatBtn(critDamageStat.RewardBtn, critDamageStat));
		} 
	}

	private IEnumerator UseCooldown(Button btn, int cooldown = 90)
	{
		btn.interactable = false;
		yield return new WaitForSeconds(cooldown);
		btn.interactable = true;
	}

	private IEnumerator UseCooldownStatBtn(Button btn, UpgradeStats stat, int cooldown = 150)
	{
		btn.interactable = false;
		btn.GetComponent<RewardStatBtn>().CanInteract = false;
		yield return new WaitForSeconds(cooldown);

		if (stat.CheckNotReachMaxLvl())
		{
			btn.interactable = true;
		}
		btn.GetComponent<RewardStatBtn>().CanInteract = true;
	}
}
