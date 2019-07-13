using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class LoadLevel : MonoBehaviour {

	public string name;
	public GameObject manager;
	public int pass;
	public GameObject banner;
	public List<Texture> stars = new List<Texture>();
	
	void Awake()
	{
		//StarSet();
	}
	
	void OnMouseDown()
	{
		manager.SendMessage("SetIndex",pass);
		Application.LoadLevel(name);	
	}
	
	void StarSet()
	{
		switch(GameManager.levelStars[pass])
		{
		case 0:
			transform.renderer.material.mainTexture = stars[0];
			break;
			
		case 1:
			transform.renderer.material.mainTexture = stars[1];
			break;
			
		case 2:
			transform.renderer.material.mainTexture = stars[2];
			break;
			
		case 3:
			transform.renderer.material.mainTexture = stars[3];
			break;
		}
	}
}
