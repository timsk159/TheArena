using UnityEngine;
using System.Collections;

public class MainMenu : MonoBehaviour
{


	#region Button Responses

	public void PlayButtonPressed()
	{
		Application.LoadLevel("TestMap");
	}

	public void ExitButtonPressed()
	{
		Application.Quit();
	}

	#endregion
}
