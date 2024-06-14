using System.Collections;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using UnityEngine;
using YG;

public class EnemyFactory : MonoBehaviour
{
    public static EnemyFactory instance;

    [SerializeField] private Transform spawnPos;
    [SerializeField] private LocationData location;
    [SerializeField] private FullscreenCounter fullscreenCounter;

	private GameObject[] enemies => location.UnlockedEnemies;

	private IEnemyInfo currentEnemy;
    public IEnemyInfo CurrentEnemy => currentEnemy;

    private int enemyCounterAd;

    private void Awake()
    {
        if (instance != null)
        {
            return;
        }
        instance = this;
    }

	private void Start()
	{
		InstantiateNewEnemy();
		EventManager.OnEnemyDestroyed.AddListener(InstantiateNewEnemy);
	}

	private IEnumerator InstantiateNewEnemyCor()
    {
        while (!Transator.instance.NamesAreSet)
        {
            yield return new WaitForSeconds(0.2f);
        }

        if (currentEnemy != null)
        {
			Statistic.instance.UpdateEnemyStatistic(currentEnemy);
		}

        int enemyNum = Random.Range(0, enemies.Length);
        currentEnemy = Instantiate(enemies[enemyNum], spawnPos.position, enemies[enemyNum].transform.rotation, transform).GetComponent<IEnemyInfo>();
        EventManager.SendEnemyInstantiated(currentEnemy);
    }

    private void InstantiateNewEnemy()
    {
        StartCoroutine(InstantiateNewEnemyCor());

        enemyCounterAd += 1;

        if (enemyCounterAd == 65)
        {
            fullscreenCounter.StartCounter();
            enemyCounterAd = 0;
        }
    }
}
