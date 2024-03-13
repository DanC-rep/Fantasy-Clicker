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
	}

	private IEnumerator UseCooldown(Button btn)
	{
		btn.interactable = false;
		yield return new WaitForSeconds(90);
		btn.interactable = true;
	}
}
