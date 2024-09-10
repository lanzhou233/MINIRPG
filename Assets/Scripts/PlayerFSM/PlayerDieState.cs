using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDieState : PlayerStateBase
{
	public override void OnEnter()
	{
		base.OnEnter();
		stateName = "Die";
		ani.SetInteger("State",4);
		manager.currentStateType = PlayerStateType.Die;
	}

	public override void OnExcute()
	{
		base.OnExcute();
		if (!IsCanPlay())
			return;
		if (ani.GetCurrentAnimatorStateInfo(0).normalizedTime >= 0.85f)
		{
			manager.ChangeState<PlayerIdleState>();
		}
		
	}
}
