using UnityEngine;

public class EnemyFactory : MonoBehaviour
{
    [SerializeField] private GameObject[] enemies;
    [SerializeField] private Transform spawnPos;

    private void Awake()
    {
        InstantiateNewEnemy();
        EventManager.OnEnemyDestroyed.AddListener(InstantiateNewEnemy);
    }

    private void InstantiateNewEnemy()
    {
        int enemyNum = Random.Range(0, enemies.Length);
        GameObject enemy = Instantiate(enemies[enemyNum], spawnPos.position, enemies[enemyNum].transform.rotation, transform);
        EventManager.SendEnemyInstantiated(enemy.GetComponent<IEnemyInfo>());
    }
}
