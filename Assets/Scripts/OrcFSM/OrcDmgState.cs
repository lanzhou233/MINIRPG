using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrcDmgState : OrcStateBase
{
	Rigidbody2D rig;
	public override void OnInit()
	{
		base.OnInit();
		rig = GetComponent<Rigidbody2D>();
	}
	public override void OnEnter()
	{
		base.OnEnter();
		stateName = "Damage";
		ani.SetTrigger("Damage");
		
	}

	public override void OnExcute()
	{
		base.OnExcute();
		if (!IsCanPlay())
			return;
		if (ani.GetCurrentAnimatorStateInfo(0).normalizedTime >= 0.85f)
			manager.ChangeState<OrcIdleState>();
		if (manager.hp <= 0)
		{
			manager.ChangeState<OrcDieState>();
		}

	}
	private void OnTriggerEnter2D(Collider2D collision)
	{
		Transform player = GetComponent<OrcAtkEve>().player.transform;
		if (collision.CompareTag("Weapon"))
		{
			rig.AddForce(-(player.position - transform.position)*manager.damageForce);
		}
	}
}
