using UnityEngine;

public class SimpleStat : Stat
{
    [SerializeField] new SimpleStatEn name;

    private int value = 0;

    public SimpleStatEn Name => name;

	private void Awake()
	{
        countText.text = value.ToString();
	}

	public void AddValue(int val)
    {
        value += val;
        countText.text = value.ToString();
	}

    public void SetValue(int val)
    {
        value = val;
        countText.text = value.ToString();
    }

    public override void GetValue()
    {
        return;
    }

    public override void SaveValue()
    {
        return;
    }
}
