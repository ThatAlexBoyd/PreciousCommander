using UnityEngine;
using System.Collections;

public class EndTile : MonoBehaviour {


	public GameObject manager;
	
	void OnTriggerEnter(Collider col)
	{
		col.SendMessage("Die");
		manager.SendMessage("ReachedHome");
	}
}
