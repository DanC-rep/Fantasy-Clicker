using UnityEngine;

public class Character : MonoBehaviour, IAttacker
{
    private AttackController attackController;
    private CharacterStats stats;
    private CharacterAnimator animator;
    private HeroSounds sound;

    private void Awake()
    {
        attackController = new AttackController();
        stats = GetComponent<CharacterStats>();
        animator = GetComponent<CharacterAnimator>();
        sound = GetComponent<HeroSounds>();

        EventManager.SendCharacterInstantiated(stats);
    }

    public void Attack()
    {
        attackController.Attack(stats.GetDamage(), stats.CritChance, stats.CritDamage);
        animator.PlayAttackAnim();
        sound.Play();
    }
}
