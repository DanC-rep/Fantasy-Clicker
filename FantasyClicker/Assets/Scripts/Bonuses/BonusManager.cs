using System.Collections;
using System.Threading.Tasks;
using UnityEngine;
using YG;

public class BonusManager : MonoBehaviour
{
    [SerializeField] private GameObject[] bonuses;

    [SerializeField] private int minTimeToSpawn;
    [SerializeField] private int maxTimeToSpawn;

    [SerializeField] private Transform spawnParent;

    [SerializeField] private float spawnXmin;
    [SerializeField] private float spawnXmax;

    [SerializeField] private float spawnY;

    private void Start()
    {
        StartCoroutine(CheckCanSpawnBonuses());
	}

    private IEnumerator CheckCanSpawnBonuses()
    {
        while (!YandexGame.SDKEnabled)
        {
            yield return new WaitForSeconds(0.2f);
        }

        if (YandexGame.savesData.TutorialShowed)
        {
            EventManager.OnBonusDestroyed.AddListener(StartSpawnNewBonus);
            StartSpawnNewBonus();
        }
        else
        {
			EventManager.OnTutorialShowed.AddListener(StartSpawnBonuses);
		}
    }

	private IEnumerator SpawnNewBonus()
    {
        int timeToWait = Random.Range(minTimeToSpawn, maxTimeToSpawn);
        yield return new WaitForSeconds(timeToWait);

        int bonusNum = Random.Range(0, bonuses.Length);
        Vector2 spawnPos = new Vector2(Random.Range(spawnXmin, spawnXmax), spawnY);

        Instantiate(bonuses[bonusNum], spawnPos, bonuses[bonusNum].transform.rotation, spawnParent);
    }

    private void StartSpawnNewBonus() => StartCoroutine(SpawnNewBonus());

    private void StartSpawnBonuses(bool showed)
    {
        if (showed)
        {
			EventManager.OnBonusDestroyed.AddListener(StartSpawnNewBonus);
			StartSpawnNewBonus();
		}
    }
}
