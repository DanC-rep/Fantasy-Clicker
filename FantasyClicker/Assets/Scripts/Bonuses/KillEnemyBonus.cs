public class KillEnemyBonus : Bonus
{

    private void OnMouseDown()
    {
        Use();
    }

    protected override void Use()
    {
        EventManager.SendCharacterAttacked(EnemyFactory.instance.CurrentEnemy.MaxHealth);
        EventManager.SendBonusDestroyed();
        Destroy(gameObject);
    }
}
