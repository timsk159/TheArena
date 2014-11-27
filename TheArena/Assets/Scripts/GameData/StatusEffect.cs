using UnityEngine;
using UnityEditor;
using System.Collections;

//When creating new status effects, just inherit from this class.
public class StatusEffect : ScriptableObject
{	
	public virtual void Apply(Character character)
	{

	}
}
