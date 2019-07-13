using UnityEngine;
using System.Collections;

public class Block : MonoBehaviour 
{
	public float speed;
	public bool canMove;
	public Transform target;
	public int directionNum;
	public float lifeTime;
	bool canDie;
	public bool isClear;
	
	void Start()
	{
		canDie = true;
		isClear = true;
	}

	void FixedUpdate()
	{
		
		if(canMove)
		{
			CheckPosition();
			transform.Translate(Vector3.forward * Time.deltaTime * speed);
			
		}
		
		if(canDie)
		{
			StartCoroutine(SlowDeath());
			CheckDeath();
		}
		
	}
	
	void CheckDeath()
	{
		if(renderer.material.color.a <= .1f)
		{
			Die();	
		}
	}
	
	void Die()
	{
		GameObject manager = GameObject.Find("MagicManager");
		manager.SendMessage("RemoveBlock");
		Destroy(gameObject);
	}	
	
	
	IEnumerator SlowDeath()
	{
		float alpha = transform.renderer.material.color.a;
		for(float f = 0.0f; f < 1.0f; f += Time.deltaTime*lifeTime)
		{
			Color newColor = new Color(.1f,.25f,.09f,Mathf.Lerp(alpha,0f,f));
			transform.renderer.material.color = newColor;
			yield return null;
		}
	}
	
	
	void CheckPosition()
	{
		if(target != null)
		{
			
			if(new Vector3(transform.position.x, transform.position.y,transform.position.z) == new Vector3(target.position.x, target.position.y + 1,target.position.z))
			{
				canMove = false;
				isClear  = false;
				Direction();
				if(isClear)
				{
					StartCoroutine(DelayMove());
				}
				
			}
		}
	}
	
	
	
	void CheckRay()
	{
		RaycastHit hit;
		
			if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, 1f))
			{
				switch(hit.collider.tag)
				{
				case "wall":
					if(directionNum == 0 || directionNum == 1)
					{
						if(transform.rotation.eulerAngles != new Vector3(0,270,0))
						{
							directionNum = 2;
						}
						else
						{
							directionNum = 1;
						}
					}
					else
					{
						directionNum++;	
					}
					break;
				
				default:
					isClear = true;
					break;
				}
				if(!isClear)
				{
					Direction();	
				}
		}
		
		Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward),Color.red,1f);
		
	}
	
	void SetTarget(Transform newTarget)
	{
		 target = newTarget;	
	}
	
	
	
	void GetDirection(int move)
	{
		directionNum = move;	
	}
	
	void Direction()
	{
		switch(directionNum)
		{
		case 0:
			break;
			
		case 1:
			transform.eulerAngles =  new Vector3(0,0,0);
			break;
			
		case 2:
			transform.eulerAngles =  new Vector3(0,90,0);
			break;
			
		case 3:
			transform.eulerAngles =  new Vector3(0,180,0);
			break;
			
		case 4:
			transform.eulerAngles =  new Vector3(0,270,0);
			break;
		}
		CheckRay();
		
	}
	
	IEnumerator DelayMove()
	{
		yield return new WaitForSeconds(.01f);
		canMove = true;
	}
	
	
	
	
}
