using UnityEngine;
using UnityEditor;
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

	public Sprite sprite;

	public void ApplyBuff(Character character)
	{
		foreach (var effect in statusEffects)
		{
			effect.Apply(character);
		}
	}

	[MenuItem("Assets/Create/Custom/Buff")]
	public static void CreateAsset()
	{
		ScriptableObjectUtility.CreateAsset<BuffData>();
	}
}
