using UnityEngine;

public class EnemyStat : Stat
{
    [SerializeField] private EnemyStats enemy;

    public IEnemyInfo Enemy => enemy;

	private void Awake()
	{
		countText.text = enemy.KillCount.ToString();
	}

	public void AddValue()
    {
        countText.text = Enemy.AddKillCount().ToString();
    }

	public override void GetValue()
	{
		return;
	}

	public override void SaveValue()
	{
		return;
	}
}
