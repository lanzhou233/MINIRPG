using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Singlest<T> : MonoBehaviour where T : Component
{
	private static T _instance = null;
	public static T Instance
	{
		get
		{
			if (_instance == null)
			{
				_instance = FindObjectOfType<T>();
				if (_instance == null)
				{
					GameObject obj = new GameObject(typeof(T).Name, new[] { typeof(T) });
					DontDestroyOnLoad(obj);
					_instance = obj.GetComponent<T>();
				}
				else
				{
					Debug.LogWarning("Instance is already exist!");
				}
			}
			return Instance;
		}
	}
}

public class Singleton<T> where T : new()
{
	private static T _instance;
	public static T Instance
	{
		get
		{
			if (_instance == null)
			{
				_instance = new T();
			}
			return _instance;
		}
	}
}
