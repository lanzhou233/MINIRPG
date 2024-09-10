using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttackState : PlayerStateBase
{
	public override void OnEnter()
	{
		base.OnEnter();
		stateName = "Attack";
		ani.SetInteger("State",2);
	}

	public override void OnExcute()
	{
		if (!IsCanPlay())
		{
			return;
		}
			
		if (ani.GetCurrentAnimatorStateInfo(0).normalizedTime >= 0.9f)
			manager.ChangeState<PlayerIdleState>();
	}
}
