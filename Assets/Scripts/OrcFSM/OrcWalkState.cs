using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrcWalkState : OrcStateBase
{
	Vector3 elderPos;
	public override void OnInit()
	{
		base.OnInit();
		elderPos = transform.position;
	}
	public override void OnEnter()
	{
		base.OnEnter();
		stateName = "Walk";
		ani.SetInteger("State", 1);
	}

	public override void OnExcute()
	{
		base.OnExcute();
		Collider2D playerCollider = Physics2D.OverlapCircle(transform.position, 5.0f, 1 << LayerMask.NameToLayer("Player"));
		if (playerCollider != null )
		{
			if (!(playerCollider.GetComponent<PlayerStateManager>().Instance.currentStateType == PlayerStateType.Die))
			{
				if (Vector3.Distance(playerCollider.transform.position, transform.position) < 1.5f)
				{
					manager.ChangeState<OrcAttackState>();
				}
				transform.position = Vector3.Lerp(transform.position, playerCollider.transform.position, Time.deltaTime);
				Vector3 dir = (playerCollider.transform.position - transform.position).normalized;
				SetDir(dir);
			}
		}
		else
		{
			transform.position = Vector3.Lerp(transform.position, elderPos, Time.deltaTime);
			SetDir((elderPos - transform.position).normalized);
			if (Vector3.Distance(transform.position, elderPos) <= 0.5f)
				manager.ChangeState<OrcIdleState>();
		}

	}
}
