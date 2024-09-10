using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrcAttackState : OrcStateBase
{
	public override void OnEnter()
	{
		base.OnEnter();
		stateName = "Attack";
		ani.SetInteger("State",2);
	}
	public override void OnExcute()
	{
		base.OnExcute();
		if (!IsCanPlay())
		{
			return;
		}

		if (ani.GetCurrentAnimatorStateInfo(0).normalizedTime >= 0.95f)
			manager.ChangeState<OrcIdleState>();
	}
}
