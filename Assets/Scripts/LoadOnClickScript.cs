using UnityEngine;
using System.Collections;

public class LoadOnClickScript : MonoBehaviour {

	public void LoadScene(int level)
	{
		Application.LoadLevel(level);
	}
}
