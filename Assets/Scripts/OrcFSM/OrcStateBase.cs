using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrcStateBase : MonoBehaviour
{
	protected Animator ani;
	public OrcStateManager manager;
	protected string stateName;
	protected Transform enemyTrans;
	public virtual void OnInit()
	{
		ani = GetComponent<Animator>();
		manager = GetComponent<OrcStateManager>().Instance;
		//enemyTrans = GameObject.FindWithTag("Monster").transform;
	}

	public virtual void OnEnter()
	{

	}

	public virtual void OnExcute()
	{
		
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

	protected void SetDir(Vector3 dir)
	{
		if (dir.x < 0)
			ani.SetFloat("X", -1);
		else if (dir.x > 0)
		{
			ani.SetFloat("X", 1);
		}
		if (dir.y < 0)
			ani.SetFloat("Y", -1);
		else if (dir.y > 0)
			ani.SetFloat("Y", 1);
	}
}
