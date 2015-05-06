using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class LevelSelectionScript : MonoBehaviour {

	//public Button[] levels;

	void Start () {

		/*GameObject emptyObject = GameObject.Find ("EmptyObject(Clone)");
		int currentLevel = emptyObject.GetComponent<StoringVarScript> ().currentLevel;

		for (int i = 0; i < levels.Length; i++) {
			if((i + 1) == currentLevel) {
				levels[i].image.color = Color.red;
				levels[i].enabled = true;
			}
			else {
				levels[i].image.color = Color.gray;
				levels[i].enabled = false;	
			}
		}*/
	}

	public void LoadScene(string level)
	{
		Application.LoadLevel(level);
	}
}
