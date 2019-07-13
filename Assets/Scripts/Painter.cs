using UnityEngine;
using System.Collections;

public class Painter : MonoBehaviour {
	
    public RaycastHit hit;
    private Ray ray;
	
	public Vector3 tapStart;
	public Vector3 tapEnd;
	
	public float hold;
	public float angle;
	float deadZone;
	
	bool wasHold;
	public bool isTouching = false;
	
	GameObject tempTile;
	
	


    void Update () 
	{
      
        if(isTouching)
		{
			hold += 1 * Time.deltaTime;
			CheckHold();
			
		}
		
		
		
		if(Input.GetButtonDown("Fire1"))
		{
			ray = camera.ScreenPointToRay(new Vector3(Input.mousePosition.x, Input.mousePosition.y,0));
			
			if (Physics.Raycast(ray, out hit, 100.0f))
	        {
	            if(hit.collider.tag == "tile")
				{
					tempTile = hit.collider.gameObject;
					tapStart = hit.transform.position;
					isTouching = true;
					wasHold = false;
					
				}
	        }
		}
		
		
		if(Input.GetButtonUp("Fire1"))
		{
			ray = camera.ScreenPointToRay(new Vector3(Input.mousePosition.x, Input.mousePosition.y,0));
			
			if (Physics.Raycast(ray, out hit, 100.0f))
	        {
				if(hit.collider.tag == "tile")
				{
					tapEnd = hit.transform.position;
					
					isTouching = false;
					CheckAngle();
					hold = 0;
				}
				
	        }
		}

    }
	
	void CheckAngle()
	{
		if(!wasHold)
		{
			angle = Mathf.Atan2(tapStart.x - tapEnd.x,tapStart.z - tapEnd.z) * 180/Mathf.PI;
			angle = angle * -1;
			tempTile.SendMessage("CalculateDirection", angle);
		}
	}
	
	void CheckHold()
	{
		if(hold >= 1.5f)
		{
			wasHold = true;
			tempTile.SendMessage("Clear");
		}
	}
}

