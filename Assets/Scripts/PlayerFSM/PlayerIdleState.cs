using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerIdleState : PlayerStateBase
{
	public override void OnEnter()
	{
		base.OnEnter();
		if (manager.currentStateType == PlayerStateType.Die)
		{
			gameObject.transform.position = new Vector3(Random.Range(-5,5),Random.Range(-5,5),0);
			manager.hp = 500;
			manager.currentStateType = PlayerStateType.Idle;
		}
		stateName = "Idle";
		ani.SetInteger("State", 0);
		ani.SetFloat("X",0);
		ani.SetFloat("Y",0);
	}

	public override void OnExcute()
	{
		
		if (isWalk())
		{
			manager.ChangeState<PlayerWalkState>();
		}
		if (Input.GetMouseButtonDown(0))
		{
			manager.ChangeState<PlayerAttackState>();
		}
	}


}
