using UnityEngine;
using System.Collections;

public class StartTile : MonoBehaviour {


	void OnTriggerEnter(Collider col)
	{
		if(col.tag == "block")
		{
			col.SendMessage("Die");	
		}
	}
}
