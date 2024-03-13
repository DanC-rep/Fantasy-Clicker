using System.Collections;
using UnityEngine;
using YG;

public class Leaderboard : MonoBehaviour
{
	[SerializeField] private LeaderboardYG leaderboardYg;

	private bool canRecord = true;

	public void AddRecord()
	{
		if (canRecord)
		{
			canRecord = false;
			StartCoroutine(AddRecordCor());
		}
	}

	private IEnumerator AddRecordCor()
	{
		yield return new WaitForSeconds(10);
		YandexGame.NewLeaderboardScores("CoinsLeaderboard", YandexGame.savesData.TotalCoins);
		leaderboardYg.UpdateLB();
		canRecord = true;
	}
}
