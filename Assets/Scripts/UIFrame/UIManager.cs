using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIModleData
{
	public string prefabName;
	public Type type;
	public bool isHideOtherModule;

	public GameObject myPrefabObj;
	public PanelBase uiClass;

	public UIModleData(string prefabName, Type type, bool isHideOtherModule)
	{
		this.prefabName = prefabName;
		this.type = type;
		this.isHideOtherModule = isHideOtherModule;
	}
}

public enum PanelType
{
Bagging
}

public class UIManager : MonoBehaviour
{
	Dictionary<Type, UIModleData> showPanel = new Dictionary<Type, UIModleData>();
	public static UIManager instance;
	private Transform CanvasTrans;
	UIModleData[] uIModleDatas;

	private void Awake()
	{
		instance = this;
		OnInit();
		CanvasTrans = GameObject.FindGameObjectWithTag("Canvans").transform;
	}


	void OnInit()
	{
		uIModleDatas = new UIModleData[]
			{
				new UIModleData("BaggingPanel",typeof(BaggingPanel),true),

			};
	}

	void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

	public void ShowUIModule(Type type, params object[] objs)
	{
		UIModleData data;

		if (showPanel.TryGetValue(type, out data))
		{
			if (data.isHideOtherModule)
			{
				HideAllOtherModule();
			}
		}
	}

	void InstiatePanel(UIModleData data, params object[] objs)
	{
		GameObject uiObj = Instantiate(Resources.Load<GameObject>("Prefabs/" + data.prefabName));
		transform.SetParent(CanvasTrans);
		uiObj.GetComponent<RectTransform>().offsetMax = Vector2.zero;
		uiObj.GetComponent<RectTransform>().offsetMin = Vector2.zero;
		data.uiClass.OnEnter(objs);
		showPanel.Add(data.type,data);
	}


	public void HideUIModle(Type type)
	{
		if (showPanel[type] == null)
		{
			UIModleData data = showPanel[type];
			data.myPrefabObj.SetActive(true);
			data.uiClass.OnHide();
		}
		
	}

	void HideAllOtherModule()
	{
		foreach (UIModleData item in showPanel.Values)
		{
			HideUIModle(item.type);
		}
	}
}
