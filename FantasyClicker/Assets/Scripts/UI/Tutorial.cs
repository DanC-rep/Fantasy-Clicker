using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;
using YG;

public class Tutorial : MonoBehaviour
{
	public List<string> Messages { get; set; } = new List<string>();
	[SerializeField] private Text messageField;

	[SerializeField] private int[] messagesShowBorder;
	[SerializeField] private Image[] borders;

	[SerializeField] private List<GameObject> objsToHide;

	[SerializeField] private GameObject tutorialPart1;
	[SerializeField] private GameObject tutorialPart2;

	[SerializeField] private GameObject tutorial;

	private int pageNum;
	private int btnBorderNum;

	private Coroutine msgCoroutine;
	private bool coroutineIsWorking;

	public bool TutorialShowed { get; set; }

	private IEnumerator CheckPluginEnabled()
	{
		while (!YandexGame.SDKEnabled)
		{
			yield return new WaitForSeconds(0.2f);
		}

		if (!TutorialShowed)
		{
			DisableUiToHide();
			tutorial.SetActive(true);
			StartCoroutine(NextMsg());

			EventManager.SendTutorialShowed(false);
		}
	}

	public void StartCheckPluginEnable()
	{
		StartCoroutine(CheckPluginEnabled());
	}

	private IEnumerator NextMsg()
	{
		while (!Transator.instance.TutorialLinesAreSet)
		{
			yield return new WaitForSeconds(0.2f);
		}

		messageField.text = string.Empty;

		if (coroutineIsWorking)
		{
			StopCoroutine(msgCoroutine);
			coroutineIsWorking = false;

			messageField.text = Messages[pageNum - 1];
		}

		else if (CheckEndMessages())
		{
			tutorialPart2.SetActive(true);
			tutorialPart1.SetActive(false);
		}
		else
		{
			msgCoroutine = StartCoroutine(ShowLine(Messages[pageNum++]));

			CheckShowBorder();
		}
	}

	public void StartNextMsg()
	{
		StartCoroutine(NextMsg());
	}

	private IEnumerator ShowLine(string text)
	{
		messageField.text = "";
		coroutineIsWorking = true;

		foreach (char sym in text)
		{
			messageField.text += sym;
			yield return new WaitForSeconds(0.05f);
		}

		coroutineIsWorking = false;
	}
	
	private bool CheckEndMessages() => pageNum == Messages.Count;

	private void CheckShowBorder()
	{
		if (btnBorderNum == borders.Length)
		{
			borders[btnBorderNum - 1].enabled = false;
		}

		if (btnBorderNum < borders.Length && messagesShowBorder[btnBorderNum] == pageNum - 1)
		{
			if (btnBorderNum - 1 >= 0)
			{
				borders[btnBorderNum - 1].enabled = false;
			}
			borders[btnBorderNum].enabled = true;
			btnBorderNum += 1;
			return;
		}
	}

	private void DisableUiToHide() => objsToHide.ForEach(ui => ui.SetActive(false));
	private void EnableUiToHide() => objsToHide.ForEach(ui => ui.SetActive(true));

	public void CompleteTutorial()
	{
		EnableUiToHide();
		EventManager.SendTutorialShowed(true);
		tutorial.SetActive(false);
		TutorialShowed = true;
	}
}
