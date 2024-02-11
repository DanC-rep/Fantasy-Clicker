public class DoubleCoinsBonus : Bonus
{
    private void OnMouseDown()
    {
        Use();
    }

    protected override void Use()
    {
        PlayerCoins.instance.DoubleCoins();
        EventManager.SendBonusDestroyed();
        Destroy(gameObject);
    }
}
