using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrcIdleState : OrcStateBase
{

	public override void OnEnter()
	{
		base.OnEnter();
		stateName = "Idle";
		ani.SetInteger("State",0);
		
	}

	public override void OnExcute()
	{
		base.OnExcute();
		Collider2D playerCollider = Physics2D.OverlapCircle(transform.position,manager.viewRadius, 1<<LayerMask.NameToLayer("Player"));
		if (playerCollider != null)
		{
			manager.ChangeState<OrcWalkState>();
		}
		if (manager.hp <= 0)
		{
			manager.ChangeState<OrcDieState>();
		}
	}
}
