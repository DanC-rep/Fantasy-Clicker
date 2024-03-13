using System.Collections.Generic;

namespace YG
{
    [System.Serializable]
    public class SavesYG
    {
        // "Технические сохранения" для работы плагина (Не удалять)
        public int idSave;
        public bool isFirstSession = true;
        public string language = "ru";
        public bool promptDone;

        // Тестовые сохранения для демо сцены
        // Можно удалить этот код, но тогда удалите и демо (папка Example)
        public int money = 1;                       // Можно задать полям значения по умолчанию
        public string newPlayerName = "Hello!";
        public bool[] openLevels = new bool[3];

        //public Dictionary<string, bool> Abilities = new Dictionary<string, bool>();
        //public Dictionary<string, bool> Heroes = new Dictionary<string, bool>();
        //public Dictionary<string, bool> Locations = new Dictionary<string, bool>();

        //public Dictionary<string, List<int>> HeroStats = new Dictionary<string, List<int>>();

        //public Dictionary<int, int> EnemyKillCount = new Dictionary<int, int>();

        public List<bool> Abilities = new List<bool>();
        public List<bool> Heroes = new List<bool>();
        public List<bool> Locations = new List<bool>();

        public List<int> HeroDamage = new List<int>();
        public List<int> HeroCritChance = new List<int>();
        public List<int> HeroCritDamage = new List<int>();

		public List<int> HeroDamageLvl = new List<int>();
		public List<int> HeroCritChanceLvl = new List<int>();
		public List<int> HeroCritDamageLvl = new List<int>();

		public List<int> EnemyKillCount = new List<int>();

        public int Coins = 0;
        public int TotalCoins = 0;

        public bool TutorialShowed = false;

        public bool SoundMuted = false;

        public int CurrentHeroId = 0;

        // Вы можете выполнить какие то действия при загрузке сохранений
        public SavesYG()
        {
            // Допустим, задать значения по умолчанию для отдельных элементов массива

            openLevels[1] = true;

            // Длина массива в проекте должна быть задана один раз!
            // Если после публикации игры изменить длину массива, то после обновления игры у пользователей сохранения могут поломаться
            // Если всё же необходимо увеличить длину массива, сдвиньте данное поле массива в самую нижнюю строку кода
        }
    }
}
