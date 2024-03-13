using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using YG;

public class FullscreenCounter : MonoBehaviour
{
    [SerializeField] private Text text;
    [SerializeField] private Image background;
    [SerializeField] private List<GameObject> uiToHide;

    private IEnumerator Counter()
    {
        int counter = 3;

        text.gameObject.SetActive(true);
        background.enabled = true;
        uiToHide.ForEach(ui => ui.SetActive(false));

        while (counter > 0)
        {
            if (YandexGame.EnvironmentData.language == "en")
            {
				text.text = "Before advertising appears: " + counter.ToString();
			}
            else
            {
				text.text = "До показа рекламы: " + counter.ToString();
			}
            yield return new WaitForSeconds(1);
            counter -= 1;
        }
		YandexGame.FullscreenShow();

		text.gameObject.SetActive(false);
		background.enabled = false;
		uiToHide.ForEach(ui => ui.SetActive(true));
	}

    public void StartCounter()
    {
        StartCoroutine(Counter());
    }
}
