using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class LevelSelectionScript : MonoBehaviour {

	public Button[] levels;

	void Start () {

		GameObject emptyObject = GameObject.Find ("EmptyObject(Clone)");
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
		}

		/*

		switch (currentLevel) {
			case 1:
				level1.enabled = true;
				level1.image.color = Color.red;
				level2.enabled = false;
				level2.image.color = Color.gray;
				level3.enabled = false;
				level3.image.color = Color.gray;
				level4.enabled = false;
				level4.image.color = Color.gray;
				level5.enabled = false;
				level5.image.color = Color.gray;
				level6.enabled = false;
				level6.image.color = Color.gray;
				level7.enabled = false;
				level7.image.color = Color.gray;
				level8.enabled = false;
				level8.image.color = Color.gray;
				break;
			case 2:
				level1.enabled = false;
				level1.image.color = Color.gray;
				level2.enabled = true;
				level2.image.color = Color.red;
				level3.enabled = false;
				level3.image.color = Color.gray;
				level4.enabled = false;
				level4.image.color = Color.gray;
				level5.enabled = false;
				level5.image.color = Color.gray;
				level6.enabled = false;
				level6.image.color = Color.gray;
				level7.enabled = false;
				level7.image.color = Color.gray;
				level8.enabled = false;
				level8.image.color = Color.gray;
				break;
			case 3:
				level1.enabled = false;
				level1.image.color = Color.gray;
				level2.enabled = false;
				level2.image.color = Color.gray;
				level3.enabled = true;
				level3.image.color = Color.red;
				level4.enabled = false;
				level4.image.color = Color.gray;
				level5.enabled = false;
				level5.image.color = Color.gray;
				level6.enabled = false;
				level6.image.color = Color.gray;
				level7.enabled = false;
				level7.image.color = Color.gray;
				level8.enabled = false;
				level8.image.color = Color.gray;
				break;
			case 4:
				level1.enabled = false;
				level1.image.color = Color.gray;
				level2.enabled = false;
				level2.image.color = Color.gray;
				level3.enabled = false;
				level3.image.color = Color.gray;
				level4.enabled = true;
				level4.image.color = Color.red;
				level5.enabled = false;
				level5.image.color = Color.gray;
				level6.enabled = false;
				level6.image.color = Color.gray;
				level7.enabled = false;
				level7.image.color = Color.gray;
				level8.enabled = false;
				level8.image.color = Color.gray;
				break;
			case 5:
				level1.enabled = false;
				level1.image.color = Color.gray;
				level2.enabled = false;
				level2.image.color = Color.gray;
				level3.enabled = false;
				level3.image.color = Color.gray;
				level4.enabled = false;
				level4.image.color = Color.gray;
				level5.enabled = true;
				level5.image.color = Color.red;
				level6.enabled = false;
				level6.image.color = Color.gray;
				level7.enabled = false;
				level7.image.color = Color.gray;
				level8.enabled = false;
				level8.image.color = Color.gray;
				break;
			case 6:
				level1.enabled = false;
				level1.image.color = Color.gray;
				level2.enabled = false;
				level2.image.color = Color.gray;
				level3.enabled = false;
				level3.image.color = Color.gray;
				level4.enabled = false;
				level4.image.color = Color.gray;
				level5.enabled = false;
				level5.image.color = Color.gray;
				level6.enabled = true;
				level6.image.color = Color.red;
				level7.enabled = false;
				level7.image.color = Color.gray;
				level8.enabled = false;
				level8.image.color = Color.gray;
				break;
			case 7:
				level1.enabled = false;
				level1.image.color = Color.gray;
				level2.enabled = false;
				level2.image.color = Color.gray;
				level3.enabled = false;
				level3.image.color = Color.gray;
				level4.enabled = false;
				level4.image.color = Color.gray;
				level5.enabled = false;
				level5.image.color = Color.gray;
				level6.enabled = false;
				level6.image.color = Color.gray;
				level7.enabled = true;
				level7.image.color = Color.red;
				level8.enabled = false;
				level8.image.color = Color.gray;
				break;
			case 8:
				level1.enabled = false;
				level1.image.color = Color.gray;
				level2.enabled = false;
				level2.image.color = Color.red;
				level3.enabled = false;
				level3.image.color = Color.gray;
				level4.enabled = false;
				level4.image.color = Color.gray;
				level5.enabled = false;
				level5.image.color = Color.gray;
				level6.enabled = false;
				level6.image.color = Color.gray;
				level7.enabled = false;
				level7.image.color = Color.gray;
				level8.enabled = true;
				level8.image.color = Color.red;
				break;

			default:
				break;
		}
	*/
	}

	public void LoadScene(string level)
	{
		Application.LoadLevel(level);
	}
}
