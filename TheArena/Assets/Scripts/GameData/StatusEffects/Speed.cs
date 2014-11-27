using UnityEngine;
using UnityEditor;
using System.Collections;

public class Speed : StatusEffect
{
	[MenuItem("Assets/Create/Custom/StatusEffects/Speed")]
	public static void CreateAsset()
	{
		ScriptableObjectUtility.CreateAsset<Speed>();
	}

	public int amount;

	public override void Apply(Character character)
	{
		//character.GiveSpeed(amount);
	}
}
