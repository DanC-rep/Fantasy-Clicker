using UnityEngine;

public class DamageAbility : MonoBehaviour, IAbility
{
    [SerializeField] private int damage;

    private void Awake()
    {
        MakeEffect();
    }

    public void MakeEffect()
    {
        EventManager.SendCharacterAttacked(damage);
    }

    private void DestroyObj()
    {
        Destroy(gameObject);
    }
}
