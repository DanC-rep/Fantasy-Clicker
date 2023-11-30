using UnityEngine;

public class VFXManager : MonoBehaviour
{
    [SerializeField] private GameObject smokeEffect;
    [SerializeField] private Transform smokeEffectPoint;

    private void Awake()
    {
        EventManager.OnEnemyDestroyed.AddListener(InstantiateSmoke);
    }

    private void InstantiateSmoke()
    {
        Instantiate(smokeEffect, smokeEffectPoint.position, smokeEffect.transform.rotation, transform);
    }
}
