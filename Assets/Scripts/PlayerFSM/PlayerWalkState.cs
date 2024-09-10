using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWalkState : PlayerStateBase
{
	Rigidbody2D rig;
	public override void OnInit()
	{
		base.OnInit();
		stateName = "Walk";
		rig = GetComponent<Rigidbody2D>();
	}

	public override void OnEnter()
	{
		base.OnEnter();
		ani.SetInteger("State", 1);
	}

	public override void OnExcute()
	{
		base.OnExcute();
		Vector3 dir;
		if (!isWalk(out dir))
		{
			manager.ChangeState<PlayerIdleState>();
		}
		else
		{
			transform.position += dir * Time.deltaTime * manager.walkSpeed;
		}
		if (Input.GetMouseButtonDown(0))
		{
			manager.ChangeState<PlayerAttackState>();
		}
	}
}
