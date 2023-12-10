using Unity.VisualScripting.Antlr3.Runtime.Misc;
using UnityEngine.Events;

public class EventManager
{
    public static UnityEvent<int> OnCharacterAttacked = new UnityEvent<int>();
    public static UnityEvent OnEnemyDestroyed = new UnityEvent();
    public static UnityEvent<IEnemyInfo> OnEnemyInstantiated = new UnityEvent<IEnemyInfo>();
    public static UnityEvent<IEnemyInfo> OnEnemyDamaged = new UnityEvent<IEnemyInfo>();
    public static UnityEvent<int> OnCharacterRewarded = new UnityEvent<int>();
    public static UnityEvent<CharacterStats> OnCharacterInstantiated = new UnityEvent<CharacterStats>();
    public static UnityEvent<CharacterStats> OnCharacterCoinsChanged = new UnityEvent<CharacterStats>();
    public static UnityEvent OnBonusDestroyed = new UnityEvent();

    public static void SendCharacterAttacked(int damage) => OnCharacterAttacked.Invoke(damage);
    public static void SendEnemyDestroyed() => OnEnemyDestroyed.Invoke();
    public static void SendEnemyInstantiated(IEnemyInfo enemyInfo) => OnEnemyInstantiated.Invoke(enemyInfo);
    public static void SendEnemyDamaged(IEnemyInfo enemyInfo) => OnEnemyDamaged.Invoke(enemyInfo);
    public static void SendCharacterRewarded(int coins) => OnCharacterRewarded.Invoke(coins);
    public static void SendCharacterInstantiated(CharacterStats stats) => OnCharacterInstantiated.Invoke(stats);
    public static void SendCharacterCoinsChanged(CharacterStats stats) => OnCharacterCoinsChanged.Invoke(stats);
    public static void SendBonusDestroyed() => OnBonusDestroyed.Invoke();
}
