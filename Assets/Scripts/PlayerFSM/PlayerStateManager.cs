using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


public class PlayerStateManager : MonoBehaviour
{
	Dictionary<Type, PlayerStateBase> states = new Dictionary<Type, PlayerStateBase>();
	PlayerStateBase currentState;
	public float walkSpeed = 10;
	public PlayerStateType currentStateType;
	public float hp;
	private PlayerStateManager instance;
	public PlayerStateManager Instance
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
		AddState<PlayerIdleState>();
		AddState<PlayerWalkState>();
		AddState<PlayerAttackState>();
		AddState<PlayerDamageState>();
		AddState<PlayerDieState>();
	}

	void AddState<T>() where T : PlayerStateBase
	{
		PlayerStateBase state = gameObject.AddComponent<T>();
		state.OnInit();
		if (!states.ContainsKey(typeof(T)))
		{
			states.Add(typeof(T), state);
		}
	}

	public void ChangeState<T>() where T : PlayerStateBase
	{

		if (currentState != null)
		{
			currentState.OnExit();
		}
		currentState = states[typeof(T)];
		currentState.OnEnter();
	}

	public void ChangeState<T>(PlayerStateType nextState) where T : PlayerStateBase
	{

		if (currentState != null)
		{
			currentState.OnExit();
		}
		currentState = states[typeof(T)];
		currentState.OnEnter(nextState);
	}

	void Start()
	{
		ChangeState<PlayerIdleState>();
	}

	// Update is called once per frame
	void Update()
	{
		if (currentState != null)
			currentState.OnExcute();
		
	}

	public PlayerStateBase ToTypeByState(PlayerStateType stateType)
	{
		foreach (PlayerStateBase state in states.Values)
		{
			if (state.manager.currentStateType == stateType)
				return state;
		}
		Debug.LogError("Not Found This Value From ToTypeByState,Can U Add this Key?");
		return null;
	}

	

}

