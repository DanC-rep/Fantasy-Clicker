using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

public class AbilityButton : MonoBehaviour
{
    [SerializeField] private GameObject ability;
    [SerializeField] private Transform spawnPos;

    private Button btn;

    private void Awake()
    {
        btn = GetComponent<Button>();
    }

    public void UseAbility()
    {
        Instantiate(ability, spawnPos.position, ability.transform.rotation, spawnPos);
        UseCooldown();
    }

    private async void UseCooldown()
    {
        btn.interactable = false;
        await Task.Delay(2000);
        btn.interactable = true;
    }
}
