using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using YG;

public class EnemyInfo : MonoBehaviour
{
    [SerializeField] private Text enemyName;
    [SerializeField] private Image healthBar;

    private IEnemyInfo tempEnemyInfo;

    private void Awake()
    {
        EventManager.OnEnemyInstantiated.AddListener(StartSetEnemyInfo);
        EventManager.OnEnemyDamaged.AddListener(UpdateEnemyHealth);
    }
	private void OnEnable()
	{
        if (tempEnemyInfo != null)
        {
			StartSetEnemyInfo(tempEnemyInfo);
            tempEnemyInfo = null;
		}
	}

	private IEnumerator SetEnemyInfo(IEnemyInfo enemyInfo)
    {
        while (!Transator.instance.NamesAreSet)
        {
            yield return new WaitForSeconds(0.2f);
        }

        enemyName.text = enemyInfo.Name;
        UpdateEnemyHealth(enemyInfo);
    }

    private void StartSetEnemyInfo(IEnemyInfo enemyInfo)
    {
        if (gameObject.activeSelf)
        {
			StartCoroutine(SetEnemyInfo(enemyInfo));
		}
        else
        {
            tempEnemyInfo = enemyInfo;
        }
    }

    private void UpdateEnemyHealth(IEnemyInfo enemyInfo)
    {
        healthBar.fillAmount = enemyInfo.Health / (float)enemyInfo.MaxHealth;
    }
}
