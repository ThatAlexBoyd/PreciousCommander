using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TileScript : MonoBehaviour 
{
	public int move = 0;
	public List<Texture> gridText = new List<Texture>();
	
	
	void Change()
	{
		switch(move)
		{
		case 0:
			renderer.material.mainTexture = gridText[0];
			break;
			
		case 1:
			renderer.material.mainTexture = gridText[1];
			break;
			
		case 2:
			renderer.material.mainTexture = gridText[2];
			break;
			
		case 3:
			renderer.material.mainTexture = gridText[3];
			break;
			
		case 4:
			renderer.material.mainTexture = gridText[4];
			break;
			
		}
	}
	
	void OnTriggerEnter(Collider col)
	{
		if(col.tag == "block")
		{
			col.SendMessage("SetTarget", gameObject.transform);
			col.SendMessage("GetDirection", move);
		}
	}
	
	void CalculateDirection(float angle)
	{
		Debug.Log(angle);
		if(angle == -180)
		{
			move = 1;
			Change();
		}
		
		if(angle == 90)
		{
			move = 2;
			Change();
		}
		
		if(angle == 0)
		{
			move = 3;
			Change();
		}
		
		if(angle == -90)
		{
			move = 4;
			Change();
		}
	}
	
	void Clear()
	{
		move = 0;
		Change();
	}
	
	
		
}
