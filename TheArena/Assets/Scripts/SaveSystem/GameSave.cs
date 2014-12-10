using UnityEngine;
using System;
using System.Collections;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

public class GameSave
{
	string m_saveName;
	DateTime m_timeStamp;

	public string saveName
	{
		get { return m_saveName; }
	}

	public DateTime timeStamp
	{
		get { return m_timeStamp; }
	}

	public GameSave(string name, DateTime time)
	{
		this.m_saveName = name;
		this.m_timeStamp = time;
	}
}
