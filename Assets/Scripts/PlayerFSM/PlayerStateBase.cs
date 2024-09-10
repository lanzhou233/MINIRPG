using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PlayerStateType
{
	None,
	Idle,
	Die
}

public class PlayerStateBase : MonoBehaviour
{
	protected Animator ani;
	public PlayerStateManager manager;
	protected string stateName;
	protected Transform enemyTrans;
	public float atkDistance = 5;
	public virtual void OnInit()
	{
		ani = GetComponent<Animator>();
		manager = GetComponent<PlayerStateManager>().Instance;
		//enemyTrans = GameObject.FindWithTag("Monster").transform;
	}

	public virtual void OnEnter()
	{

	}

	public virtual void OnEnter(PlayerStateType nextState)
	{

	}

	public virtual void OnExcute()
	{
		if (h < 0)
		{
			ani.SetFloat("X", -1);
		}
		else if (h > 0)
		{
			ani.SetFloat("X", 1);
		}
		else
		{
			ani.SetFloat("X", 0);
		}
		if (v < 0)
			ani.SetFloat("Y", -1);
		else if (v > 0)
			ani.SetFloat("Y", 1);
		else
			ani.SetFloat("Y", 0);
	}

	public virtual void OnExit()
	{

	}

	protected bool IsCanPlay()
	{
		if (ani.GetCurrentAnimatorStateInfo(0).IsName(stateName))
			return true;
		return false;
	}

	protected bool IsCanAttack()
	{
		return Vector3.Distance(transform.position, enemyTrans.position) <= atkDistance;
	}
	protected float h;
	protected float v;
	protected bool isWalk()
	{
		h = Input.GetAxis("Horizontal");
		v = Input.GetAxis("Vertical");
		return h != 0 || v != 0;
	}

	protected bool isWalk(out Vector3 dir)
	{
		h = Input.GetAxis("Horizontal");
		v = Input.GetAxis("Vertical");
		dir = new Vector3(h, v, 0);
		return h != 0 || v != 0;
	}
}
