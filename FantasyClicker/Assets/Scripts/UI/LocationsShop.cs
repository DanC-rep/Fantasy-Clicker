using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LocationsShop : MonoBehaviour
{
    [SerializeField] private LocationData[] locations;

    [SerializeField] private Image locationImage;
    [SerializeField] private Text[] bonuses;

    [SerializeField] private Button chooseLocationBtn;
    [SerializeField] private Button purchaseLocationBtn;
    [SerializeField] private Text costText;

    private int pageNum;

    private void Awake()
    {
        SetLocationData();
    }

    public void NextPage()
    {
        if (pageNum < locations.Length - 1)
        {
            pageNum += 1;

            SetLocationData();
        }
    }

    public void PrevPage()
    {
        if (pageNum > 0)
        {
            pageNum -= 1;

            SetLocationData();
        }
    }

    public void ChooseLocation()
    {
        SceneManager.LoadScene(locations[pageNum].SceneName);
    }

    private void SetLocationData()
    {
        locationImage.sprite = locations[pageNum].Image;

        for (int i = 0; i < bonuses.Length; i++)
        {
            bonuses[i].text = locations[pageNum].Bonuses[i];
        }

        SetBtnToTakeLocation();
    }

    public void PurchaseLocation()
    {
        if (PlayerCoins.instance.CheckEnoughCoins(locations[pageNum].Cost))
        {
            PlayerCoins.instance.DecreaseCoins(locations[pageNum].Cost);
            locations[pageNum].Purchased = true;

            SetBtnToTakeLocation();
        }
    }

	private void SetBtnToTakeLocation()
	{
		if (locations[pageNum].Purchased)
		{
			purchaseLocationBtn.gameObject.SetActive(false);
			chooseLocationBtn.gameObject.SetActive(true);
		}
		else
		{
			chooseLocationBtn.gameObject.SetActive(false);
			purchaseLocationBtn.gameObject.SetActive(true);
			costText.text = locations[pageNum].Cost.ToString();
		}
	}
}
