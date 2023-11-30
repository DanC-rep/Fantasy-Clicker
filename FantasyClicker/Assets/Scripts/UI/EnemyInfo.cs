using UnityEngine;
using UnityEngine.UI;

public class EnemyInfo : MonoBehaviour
{
    [SerializeField] private Text enemyName;
    [SerializeField] private Image healthBar;

    private void Awake()
    {
        EventManager.OnEnemyInstantiated.AddListener(SetEnemyInfo);
        EventManager.OnEnemyDamaged.AddListener(UpdateEnemyHealth);
    }

    private void SetEnemyInfo(IEnemyInfo enemyInfo)
    {
        enemyName.text = enemyInfo.Name;
        UpdateEnemyHealth(enemyInfo);
    }

    private void UpdateEnemyHealth(IEnemyInfo enemyInfo)
    {

        healthBar.fillAmount = enemyInfo.Health / (float)enemyInfo.MaxHealth;
    }
}
