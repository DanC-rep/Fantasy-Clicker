
using UnityEngine;

public class AttackController
{
    public void Attack(int damage, int critChance, int critDamage)
    {
        int finalDamage = CalculateDamage(damage, critChance, critDamage);
        EventManager.SendCharacterAttacked(finalDamage);
    }

    private int CalculateDamage(int damage, int critChance, int critDamage)
    {
        int chance = Random.Range(0, 101);
        bool critHappened = critChance >= chance;
        var critAdded = critHappened ? critChance : 0;

        return damage + critAdded;
    }
}
