using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MessageManager : Singleton<MessageManager>
{
   private Dictionary<string,IMessageData> dicMessage;
	public MessageManager()
	{
		InitData();
	}
	void InitData()
	{
		dicMessage = new Dictionary<string, IMessageData>();
	}

	public void Regist<T>(string key,Action<T> value)
	{
		if (dicMessage.TryGetValue(key, out var previousAction))
		{
			if (previousAction is MessageData<T> message)
			{
				message.MessageEvents += value;
			}
		}
		else
		{
			dicMessage.Add(key, new MessageData<T>(value));
		}
	}

	public void ReMove<T>(string key, Action<T> value)
	{
		if (dicMessage.TryGetValue(key, out var previousAction))
		{
			if (previousAction is MessageData<T> message)
			{
				message.MessageEvents -= value;
			}
		}
	}

	public void Send<T>(string key, T value)
	{
		Debug.Log("EnterSend");
		if (dicMessage.TryGetValue(key, out var previousAction))
		{
			Debug.Log("HasValue");
			(previousAction as MessageData<T>)?.MessageEvents.Invoke(value);
		}
		Debug.Log("HasntValue");
	}

	public void Clear()
	{
		dicMessage.Clear();
	}
}

public interface IMessageData
{ }

public class MessageData<T>: IMessageData
{
	public Action<T> MessageEvents;
	public MessageData(Action<T> action)
	{
		MessageEvents += action;
	}
}