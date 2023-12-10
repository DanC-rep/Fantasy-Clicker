using System.Threading.Tasks;
using UnityEngine;

public class BonusManager : MonoBehaviour
{
    [SerializeField] private GameObject[] bonuses;

    [SerializeField] private int minTimeToSpawn;
    [SerializeField] private int maxTimeToSpawn;

    [SerializeField] private Transform spawnParent;

    [SerializeField] private float spawnXmin;
    [SerializeField] private float spawnXmax;

    [SerializeField] private float spawnY;

    private void Awake()
    {
        EventManager.OnBonusDestroyed.AddListener(SpawnNewBonus);
        SpawnNewBonus();
    }

    private async void SpawnNewBonus()
    {
        int timeToWait = Random.Range(minTimeToSpawn, maxTimeToSpawn);
        await Task.Delay(timeToWait);

        int bonusNum = Random.Range(0, bonuses.Length);
        Vector2 spawnPos = new Vector2(Random.Range(spawnXmin, spawnXmax), spawnY);

        Instantiate(bonuses[bonusNum], spawnPos, bonuses[bonusNum].transform.rotation, spawnParent);
    }
}
