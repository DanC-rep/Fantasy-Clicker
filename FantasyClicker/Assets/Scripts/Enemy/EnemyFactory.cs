using UnityEngine;

public class EnemyFactory : MonoBehaviour
{
    public static EnemyFactory instance;

    [SerializeField] private Transform spawnPos;
    [SerializeField] private LocationData location;

	private GameObject[] enemies => location.UnlockedEnemies;

	private IEnemyInfo currentEnemy;
    public IEnemyInfo CurrentEnemy => currentEnemy;

    private void Awake()
    {
        if (instance != null)
        {
            return;
        }
        instance = this;

        InstantiateNewEnemy();
        EventManager.OnEnemyDestroyed.AddListener(InstantiateNewEnemy);
    }

    private void InstantiateNewEnemy()
    {
        int enemyNum = Random.Range(0, enemies.Length);
        currentEnemy = Instantiate(enemies[enemyNum], spawnPos.position, enemies[enemyNum].transform.rotation, transform).GetComponent<IEnemyInfo>();
        EventManager.SendEnemyInstantiated(currentEnemy);
    }
}
