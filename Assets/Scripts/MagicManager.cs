using UnityEngine;
using System.Collections;
using System.Collections.Generic;



public class MagicManager : MonoBehaviour 
{
	public int blocksHome;
	public TextMesh textScore;
	int blocksInPlay;
	
	int starCount;
	public GameObject banner;
	public List<Texture> stars = new List<Texture>();
	
	public TextMesh textWin;
	
	
	void Awake()
	{
		blocksInPlay = GameManager.blockSpawn[GameManager.levelIndex];
		textScore.text = "Blocks Saved " + blocksHome + "/" + GameManager.blockSpawn[GameManager.levelIndex];
		blocksHome = 0;	
		starCount = 0;
		SetBanner();
	}
	
	
	void ReachedHome()
	{
		blocksHome++;
		UpdateText();
		UpdateStars();
		
	}
	
	void UpdateStars()
	{
		float percent = (float)(((float)blocksHome / (float)GameManager.blockSpawn[GameManager.levelIndex])*100);
		Debug.Log(percent);
		
		if(percent >= 0 && percent <= 32)
		{
			starCount = 0;	
		}
		
		if(percent >= 33 && percent <= 59)
		{
			starCount = 1;	
		}
		
		
		if(percent >= 60 && percent <= 79)
		{
			Debug.Log("2stars");
			starCount = 2;	
		}
		if(percent >= 80)
		{
			Debug.Log("3stars");
			starCount = 3;	
		}
		
		SetBanner();
		
	}
	
	void SetBanner()
	{
		switch(starCount)
		{
		case 0:
			banner.renderer.material.mainTexture = stars[0];
			break;
			
		case 1:
			banner.renderer.material.mainTexture = stars[1];
			break;
			
		case 2:
			banner.renderer.material.mainTexture = stars[2];
			break;
			
		case 3:
			banner.renderer.material.mainTexture = stars[3];
			break;
		}
	}
	
	void RemoveBlock()
	{
		blocksInPlay--;
		if(blocksInPlay == 0)
		{
			StartCoroutine(EndLevel());	
		}
	}
	
	void UpdateText()
	{
		textScore.text = "Blocks Saved " + blocksHome + "/" + GameManager.blockSpawn[GameManager.levelIndex];	
	}
	
	IEnumerator EndLevel()
	{
		yield return new WaitForSeconds(.5f);
		textWin.renderer.enabled = true;
		GameManager.levelStars.Add(starCount);
		yield return new WaitForSeconds(2f);
		Application.LoadLevel("LevelSelect");
		
	}
	
	
	
}
