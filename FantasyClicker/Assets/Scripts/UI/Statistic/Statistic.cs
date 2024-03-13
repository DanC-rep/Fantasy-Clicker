using System.Collections.Generic;
using UnityEngine;

public class Statistic : MonoBehaviour
{
	public static Statistic instance;

	public List<EnemyStat> enemyStats;
	public List<SimpleStat> simpleStats;

	[SerializeField] private List<GameObject> firstPage;
	[SerializeField] private List<GameObject> secondPage;

	private int pageNum = 1;

	private void Awake()
	{
		if (instance != null)
		{
			return;
		}
		instance = this;
	}

	public void NextPage()
	{
		if (pageNum == 1)
		{
			secondPage.ForEach(page => page.SetActive(true));
			firstPage.ForEach(page => page.SetActive(false));
			pageNum += 1;
		}

		EventManager.SendUiClicked();
	}

	public void PrevPage()
	{
		if (pageNum == 2)
		{
			firstPage.ForEach(page => page.SetActive(true));
			secondPage.ForEach(page => page.SetActive(false));
			pageNum -= 1;
		}

		EventManager.SendUiClicked();
	}

	public void UpdateEnemyStatistic(IEnemyInfo enemyInfo)
	{
		enemyStats.ForEach(delegate(EnemyStat stat)
		{
			if (enemyInfo.Id == stat.Enemy.Id)
			{
				stat.AddValue();
				return;
			}
		});
	}

	public void UpdateSimpleStat(SimpleStatEn name, int value)
	{
		simpleStats.ForEach(stat =>
		{
			if (name == stat.Name)
			{
				stat.AddValue(value);
				return;
			}
		});
	}

	public void SetSimpleStat(SimpleStatEn name, int value)
	{
		simpleStats.ForEach(stat =>
		{
			if (name == stat.Name)
			{
				stat.SetValue(value);
				return;
			}
		});
	}
}
