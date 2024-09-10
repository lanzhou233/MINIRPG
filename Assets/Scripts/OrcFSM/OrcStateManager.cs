using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrcStateManager : MonoBehaviour
{
	Dictionary<Type, OrcStateBase> states = new Dictionary<Type, OrcStateBase>();
	public OrcStateBase currentState;
	public float damageForce = 5;
	public float viewRadius = 5.0f;
	public float hp;
	private OrcStateManager instance;
	public OrcStateManager Instance
	{
		get
		{
			if (instance == null)
			{
				instance = this;
			}
			return instance;
		}

	}
	private void Awake()
	{

		AddState<OrcIdleState>();
		AddState<OrcWalkState>();
		AddState<OrcAttackState>();
		AddState<OrcDmgState>();
		AddState<OrcDieState>();
	}

	void AddState<T>() where T : OrcStateBase
	{
		OrcStateBase state = gameObject.AddComponent<T>();
		state.OnInit();
		if (!states.ContainsKey(typeof(T)))
		{
			states.Add(typeof(T), state);

		}
	}

	public void ChangeState<T>() where T : OrcStateBase
	{

		if (currentState != null)
		{
			currentState.OnExit();
		}
		currentState = states[typeof(T)];
		currentState.OnEnter();
	}


	void Start()
	{
		ChangeState<OrcIdleState>();
	}

	// Update is called once per frame
	void Update()
	{
		if (currentState != null)
			currentState.OnExcute();

	}

	private void OnDisable()
	{
		if (currentState != null)
			currentState.OnExit();
	}



}
