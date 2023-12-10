using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LocationsShop : MonoBehaviour
{
    [SerializeField] private LocationData[] locations;

    [SerializeField] private Image locationImage;
    [SerializeField] private Text[] bonuses;

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
    }

}
