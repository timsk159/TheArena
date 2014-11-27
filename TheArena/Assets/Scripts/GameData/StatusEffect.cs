using UnityEngine;
using UnityEditor;
using System.Collections;

//When creating new status effects, just inherit from this class.
public class StatusEffect : ScriptableObject
{
	/* Make sure to add one of these when inheriting:
	[MenuItem("Assets/Create/Custom/StatusEffects/EffectName")]
	public static void CreateAsset()
	{
		ScriptableObjectUtility.CreateAsset<ClassName>();
	}
	 */

	public virtual void Apply(Character character)
	{

	}
}
