using UnityEngine;
using System.Collections;

public class BuffData : ScriptableObject 
{
	public enum BuffType
	{
		Buff, Debuff,
	};

	public string buffName;

	public int duration;

	public BuffType buffType;

	public StatusEffect[] statusEffects;

	public void ApplyBuff(GameObject enemy)
	{
		foreach (var effect in statusEffects)
		{

		}
	}
}
