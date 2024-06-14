using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SetFontFilteringToPoint : MonoBehaviour
{
	private void Start()
	{
		GetComponent<Text>().font.material.mainTexture.filterMode = FilterMode.Point;
	}
}
