using UnityEngine;
using System.Collections;

public class ReloadLevel : MonoBehaviour {

	void OnMouseDown()
	{
		Application.LoadLevel(Application.loadedLevel);
	}
}
