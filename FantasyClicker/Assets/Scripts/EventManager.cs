using UnityEngine.Events;

public class EventManager
{
    public static UnityEvent<int> OnCharacterAttacked = new UnityEvent<int>();
    public static UnityEvent OnEnemyDestroyed = new UnityEvent();
    public static UnityEvent<IEnemyInfo> OnEnemyInstantiated = new UnityEvent<IEnemyInfo>();
    public static UnityEvent<IEnemyInfo> OnEnemyDamaged = new UnityEvent<IEnemyInfo>();
    public static UnityEvent<int> OnCharacterRewarded = new UnityEvent<int>();
    public static UnityEvent<CharacterStats> OnCharacterInstantiated = new UnityEvent<CharacterStats>();
    public static UnityEvent OnCharacterCoinsChanged = new UnityEvent();
    public static UnityEvent OnBonusDestroyed = new UnityEvent();
    public static UnityEvent<bool> OnTutorialShowed = new UnityEvent<bool>();
    public static UnityEvent OnUiClicked = new UnityEvent();
    public static UnityEvent<bool> OnSoundModeChanged = new UnityEvent<bool>();

    public static UnityEvent<AbilityData> OnAbilityPurchased = new UnityEvent<AbilityData>();
    public static UnityEvent<HeroData> OnHeroPurchased = new UnityEvent<HeroData>();
    public static UnityEvent<LocationData> OnLocationPurchased = new UnityEvent<LocationData>();
    public static UnityEvent<HeroData> OnHeroStatsUpgraded = new UnityEvent<HeroData>();
    public static UnityEvent<IEnemyInfo> OnEnemyKillCountChanged = new UnityEvent<IEnemyInfo>();

    public static void SendCharacterAttacked(int damage) => OnCharacterAttacked.Invoke(damage);
    public static void SendEnemyDestroyed() => OnEnemyDestroyed.Invoke();
    public static void SendEnemyInstantiated(IEnemyInfo enemyInfo) => OnEnemyInstantiated.Invoke(enemyInfo);
    public static void SendEnemyDamaged(IEnemyInfo enemyInfo) => OnEnemyDamaged.Invoke(enemyInfo);
    public static void SendCharacterRewarded(int coins) => OnCharacterRewarded.Invoke(coins);
    public static void SendCharacterInstantiated(CharacterStats stats) => OnCharacterInstantiated.Invoke(stats);
    public static void SendCharacterCoinsChanged() => OnCharacterCoinsChanged.Invoke();
    public static void SendBonusDestroyed() => OnBonusDestroyed.Invoke();
    public static void SendTutorialShowed(bool showed) => OnTutorialShowed.Invoke(showed);
    public static void SendUiClicked() => OnUiClicked.Invoke();
    public static void SendSoundModeChanged(bool mode) => OnSoundModeChanged.Invoke(mode);

    public static void SendAbilityPurchased(AbilityData ability) => OnAbilityPurchased.Invoke(ability);
    public static void SendHeroPurchased(HeroData hero) => OnHeroPurchased.Invoke(hero);
    public static void SendLocationPurchaed(LocationData location) => OnLocationPurchased.Invoke(location);
    public static void SendHeroStatsUpgraded(HeroData hero) => OnHeroStatsUpgraded.Invoke(hero);
    public static void SendEnemyKillCountChanged(IEnemyInfo enemy) => OnEnemyKillCountChanged.Invoke(enemy);
}
