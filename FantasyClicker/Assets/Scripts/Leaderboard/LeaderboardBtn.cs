using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LeaderboardBtn : MonoBehaviour
{
	[SerializeField] private GameObject leaderboard;
	[SerializeField] private Image background;
	[SerializeField] private List<GameObject> objsToHide;

	private bool isOpen;

	public void ShowLeaderboard()
	{
		if (!isOpen)
		{
			leaderboard.SetActive(true);
			background.enabled = true;
			objsToHide.ForEach(obj => obj.SetActive(false));
			isOpen = true;
			EventManager.SendUiClicked();
			return;
		}

		leaderboard.SetActive(false);
		background.enabled = false;
		objsToHide.ForEach(obj => obj.SetActive(true));
		isOpen = false;
		EventManager.SendUiClicked();
	}
}
