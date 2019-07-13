using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameManager : MonoBehaviour {
	
	public static List<int> blockSpawn = new List<int>();
	public List<int> setSpawn = new List<int>();
	
	public static List<int> levelStars = new List<int>();
	
	public static int levelIndex;
	
	
	
	void Awake()
	{
		blockSpawn = setSpawn;
	}
	
	void SetIndex(int num)
	{
		levelIndex = num;	
	}
}
