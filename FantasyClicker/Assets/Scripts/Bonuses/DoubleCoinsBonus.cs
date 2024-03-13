public class DoubleCoinsBonus : Bonus
{
    private void OnMouseDown()
    {
        Use();
    }

    protected override void Use()
    {
        PlayerCoins.instance.StartDoubleCoins();
        EventManager.SendBonusDestroyed();
        Destroy(gameObject);
    }
}
