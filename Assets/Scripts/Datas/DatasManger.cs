using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DatasManger 
{
	private DatasManger()
	{ }
	private static  DatasManger instance;
	public static DatasManger Instance
	{
		get
		{
			if (instance == null)
			{
				instance = new DatasManger();
			}
			return instance;
		}

	}
	public int KilledOrc = 0;
}
