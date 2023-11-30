using UnityEngine;

public class Enemy : MonoBehaviour, IDamageable
{
    private EnemyAnimator animator;
    private EnemyStats stats;

    private bool canBeDamaged = true;
    public bool CanBeDamaged => canBeDamaged;

    private void Awake()
    {
        animator = GetComponent<EnemyAnimator>();
        stats = GetComponent<EnemyStats>();

        EventManager.OnCharacterAttacked.AddListener(TakeDamage);
    }

    public void TakeDamage(int damage)
    {
        stats.DecreaseHealth(damage);
        EventManager.SendEnemyDamaged(stats);

        if (stats.Health < 0 && canBeDamaged)
        {
            canBeDamaged = false;
            Death();
            return;
        }

        animator.PlayTakeDamageAnim();
    }

    public void Death()
    {
        animator.PlayDeathAnim();
    }

    private void DestroyObj()
    {
        EventManager.SendEnemyDestroyed();
        EventManager.SendCharacterRewarded(stats.Reward);
        Destroy(gameObject);
    }
}
  