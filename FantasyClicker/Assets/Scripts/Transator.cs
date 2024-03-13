using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using YG;

public class Transator : MonoBehaviour
{
	[SerializeField] private List<EnemyStats> enemies;
	[SerializeField] private Tutorial tutorial;

	[SerializeField] private LocationData forest;
	[SerializeField] private LocationData cave;
	[SerializeField] private LocationData city;

	private string[] enemyNamesRu = { "������", "������", "�������� ����", "������", "������", "������", "����", "������ � �����",
	"������ � �����", "������ � ������", "�����", "���" };

	private string[] enemyNamesEn = { "Archer", "Bandit", "Flying Eye", "Goblin", "King", "Knight", "Mushroom", "Skeleton with sword",
	"Skeleton with knife", "Skeleton with spear", "Slime", "Wizard" };

	private string[] forestBonusesRu = { "���", "���", "���" };
	private string[] caveBonusesRu = { "2x ������", "����� �����", "����� ����������" };
	private string[] cityBonusesRu = { "3x ������", "����� �����", "����� ����������" };

	private string[] forestBonusesEn = { "No", "No", "No" };
	private string[] caveBonusesEn = { "2x gold", "New heroes", "New enemies" };
	private string[] cityBonusesEn = { "3x gold", "New heroes", "New enemies" };

	private string[] tutorialLinesRu =
	{
		"����� ����������, ��������! ���� ������ - �������� ��� ����� �� �������� � ����� ��������� ������.",
		"����� ������� ���� ����, ���� ����� ��������� �����������, �������� ������ � ��������� ����� ���������!",
		"����� ������ � ������ �����.",
		"�� ���� ������� �� ������ �������� ������ �����, �������� ��� ������ � ����.",
		"����� �� ������ ����� ����� ��������� ��� ����� ������� � ������� �� ��������������.",
		"����� ����� ���������� �� ���� �������� ����� ������� - ����� ����� ���������!",
		"��� ����� �� ������ ��������� ����� �������, ���������� �� ������.",
		"����� �� ������ ���������� ����� ������ ��� ������� �������������.",
		"����� �� ������ ������������ �� ����� ����������� �� ������������� ������ � ������������ ��������.",
		"�� ��, ������ ����� �������� ����� ������� �������������, ������� ������� ���������� ���� �� ������ � ����� ���� ������� �� ������.",
		"�� ���, ������ �� ������ � ��������� �������������. ����� � ����� �����������!"
	};

	private string[] tutorialLinesEn =
	{
		"Welcome, adventurer! Your mission is to cleanse these lands from monsters and become a true hero.",
		"To achieve this goal, you need to develop abilities, upgrade heroes, and unlock new allies!",
		"Let's start with the buttons below.",
		"On this tab, you can enhance your hero, strengthening their skills and power.",
		"Here you can find new allies for your team and learn about their characteristics.",
		"New heroes appear as you uncover new locations - keep your eyes open!",
		"This section offers the opening of new locations for gold and presents the bonuses they bring.",
		"You can also view your statistics on earned gold and destroyed monsters.",
		"Oh yes, each hero has two special abilities that deal increased damage to enemies and can be purchased for gold.",
		"So now you are familiar with the main features. Good luck on your adventure!"
	};

	private bool namesAreSet;
	public bool NamesAreSet => namesAreSet;

	private bool tutorialLinesAreSet;
	public bool TutorialLinesAreSet => tutorialLinesAreSet;

	public static Transator instance;

	private void Awake()
	{
		if (instance != null)
		{
			return;
		}
		instance = this;

		GameObject[] objs = GameObject.FindGameObjectsWithTag("Translator");

		if (objs.Length > 1)
		{
			Destroy(gameObject);
		}

		DontDestroyOnLoad(gameObject);
	}

	private void OnEnable()
	{
		YandexGame.GetDataEvent += StartGetData;
	}

	private void OnDisable()
	{
		YandexGame.GetDataEvent -= StartGetData;
	}

	private IEnumerator GetData()
	{
		while (!YandexGame.SDKEnabled)
		{
			yield return new WaitForSeconds(0.2f);
		}

		SetEnemyNamesWithLanguage("ru", enemyNamesRu);
		SetEnemyNamesWithLanguage("en", enemyNamesEn);

		SetLocationBonusesWithLanguage("ru", forestBonusesRu, forest);
		SetLocationBonusesWithLanguage("ru", caveBonusesRu, cave);
		SetLocationBonusesWithLanguage("ru", cityBonusesRu, city);

		SetLocationBonusesWithLanguage("en", forestBonusesEn, forest);
		SetLocationBonusesWithLanguage("en", caveBonusesEn, cave);
		SetLocationBonusesWithLanguage("en", cityBonusesEn, city);

		namesAreSet = true;

		if (tutorial != null)
		{
			SetTutorialLinesWithLanguage("ru", tutorialLinesRu);
			SetTutorialLinesWithLanguage("en", tutorialLinesEn);

			tutorialLinesAreSet = true;
		}
	}

	private void StartGetData()
	{
		StartCoroutine(GetData());
	}

	private void SetEnemyNamesWithLanguage(string language, string[] enemyNames)
	{
		if (YandexGame.EnvironmentData.language == language)
		{
			for (int i = 0; i < enemyNames.Length; i++)
			{
				enemies.ForEach(en => en.Name = en.Id == i ? enemyNames[i] : en.Name);
			}
		}
	}

	private void SetTutorialLinesWithLanguage(string language, string[] lines)
	{
		if (YandexGame.EnvironmentData.language == language)
		{
			for (int i = 0; i < lines.Length; i++)
			{
				tutorial.Messages.Add(lines[i]);
			}
		}
	}

	private void SetLocationBonusesWithLanguage(string language, string[] bonuses, LocationData location)
	{
		if (YandexGame.EnvironmentData.language == language)
		{
			location.Bonuses = bonuses;
		}
	}
}
