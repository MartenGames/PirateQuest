using UnityEngine;
using System.Collections;

public class LoadOnClickScript : MonoBehaviour {

	public void LoadScene(string level)
	{
		Application.LoadLevel(level);
	}
}
