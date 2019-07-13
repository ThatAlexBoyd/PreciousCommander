using UnityEngine;
using System.Collections;

public class Emittor : MonoBehaviour {

	public bool canEmit;
	public int coolDown;
	public GameObject block;
	int curBlocks;
	
	void Awake()
	{
		canEmit = false;
		StartCoroutine(DelayStart());
		
	}
	
	
	
	IEnumerator DelayStart()
	{
		yield return new WaitForSeconds(3f);
		canEmit = true;
		StartCoroutine(SpawnBlock());
	}
	
	
	IEnumerator SpawnBlock()
	{
			while(canEmit)
			{
				canEmit =  false;
				GameObject temp = Instantiate(block, transform.position, transform.rotation) as GameObject;
				curBlocks++;
				CheckMax();	
				yield return new WaitForSeconds(coolDown);
				canEmit =  true;
			}
	}
	
	void CheckMax()
	{
		if(curBlocks == GameManager.blockSpawn[GameManager.levelIndex])
		{
			StopAllCoroutines();	
		}
	}
	

}
