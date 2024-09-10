using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ExcuteText : MonoBehaviour
{
	[SerializeField]TextMeshProUGUI txt;
	private void Awake()
	{
		txt = GetComponent<TextMeshProUGUI>();
	}

	// Update is called once per frame
	void Update()
    {
		txt.text = "KilledOrc:" + DatasManger.Instance.KilledOrc;
    }
}
