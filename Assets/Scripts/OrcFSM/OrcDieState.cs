using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrcDieState : OrcStateBase
{
	public override void OnInit()
	{
		base.OnInit();
		MessageManager.Instance.Regist<int>("OrcKilled", OrcDead);
	}

	public override void OnEnter()
	{
		stateName = "Die";
		ani.SetInteger("State",4);
		
	}

	public override void OnExcute()
	{
		if (!IsCanPlay())
			return;
		if (ani.GetCurrentAnimatorStateInfo(0).normalizedTime >= 0.85f)
		{
			Destroy(gameObject);
		}
	}

	public override void OnExit()
	{
		MessageManager.Instance.Send<int>("OrcKilled", 1);
		MessageManager.Instance.Clear();
		base.OnExit();
	}

	void OrcDead(int data)
	{
		DatasManger.Instance.KilledOrc += data;
		Debug.Log(DatasManger.Instance.KilledOrc);
	}
}
