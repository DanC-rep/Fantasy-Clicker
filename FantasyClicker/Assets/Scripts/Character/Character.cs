using UnityEngine;

public class Character : MonoBehaviour, IAttacker
{
    private AttackController attackController;
    private CharacterStats stats;
    private CharacterAnimator animator;

    private void Awake()
    {
        attackController = new AttackController();
        stats = GetComponent<CharacterStats>();
        animator = GetComponent<CharacterAnimator>();

        EventManager.SendCharacterInstantiated(stats);
    }

    public void Attack()
    {
        attackController.Attack(stats.Damage, stats.CritChance, stats.CritDamage);
        animator.PlayAttackAnim();
    }
}
