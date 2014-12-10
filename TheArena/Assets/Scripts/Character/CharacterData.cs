using UnityEngine;
using System;
using System.Collections;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

[Serializable()]
public class CharacterData : ISerializable
{
	public string name;
	public int level;
	public int currentXP;

	public CharacterData(SerializationInfo info, StreamingContext ctxt)
	{
		name = (string)info.GetValue("CharacterName", typeof(string));
		level = (int)info.GetValue("CharacterLevel", typeof(int));
		currentXP = (int)info.GetValue("CharacterXP", typeof(int));
	}

	public void GetObjectData(SerializationInfo info, StreamingContext context)
	{
		info.AddValue("CharacterName", name);
		info.AddValue("CharacterLevel", level);
		info.AddValue("CharacterXP", currentXP);
	}
}
