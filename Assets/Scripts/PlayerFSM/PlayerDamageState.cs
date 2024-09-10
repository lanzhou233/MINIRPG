using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDamageState : PlayerStateBase
{
	public override void OnEnter()
	{
		base.OnEnter();
		stateName = "Damage";
		ani.SetTrigger("Damage");
		manager.hp -= 10;
	}

	public override void OnExcute()
	{
		base.OnExcute();
		if (!IsCanPlay())
			return;
		if (ani.GetCurrentAnimatorStateInfo(0).normalizedTime >= 0.85f)
			manager.ChangeState<PlayerIdleState>();
		if (manager.hp <= 0)
		{
			manager.ChangeState<PlayerDieState>();
		}
	}
}
