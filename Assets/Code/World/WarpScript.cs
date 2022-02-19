//using System.Collections;
//using System.Collections.Generic;
using UnityEngine;

public class WarpScript : MonoBehaviour
{	
    // Start is called before the first frame update
	/*
    void Start()
    {
		print("Warp entered");
        //check which start portal
		
		
		//teleport hero to target position
		
		//trigger to dark world
		
    }
	*/

	private void OnTriggerEnter(Collider other)
    {	
		string triggeredObject =  this.gameObject.name;
		string triggeringObject = other.name;
		print("Warp entered");
		print("Triggering Object: " + other.name);
		print("Triggered Object: " + triggeredObject);
		GameObject hero = GameObject.Find("Hero");
		
		if (triggeringObject == "Hero")
		{
			switch(triggeredObject)
			{
				case "BattleWarp":
					
					hero.transform.position = new Vector3( 120,-10,0);
					DimensionalShiftManager.triggerChangeWorld = true;
					break;
				case "TrainingWarp (1)":
					//GameObject hero = GameObject.Find("Hero");
					//StartPosition = -23,10,0
					hero.transform.position = new Vector3( -23,10,0);
					DimensionalShiftManager.triggerChangeWorld = true;
					break;
				case "portal-sprite (1)":
					//GameObject hero = GameObject.Find("Hero");
					hero.transform.position = new Vector3( -98,2,0);
					DimensionalShiftManager.triggerChangeWorld = true;
					break;
				case "portal-sprite (2)":
					//GameObject hero = GameObject.Find("Hero");
					hero.transform.position = new Vector3( 120,-10,0);
					DimensionalShiftManager.triggerChangeWorld = true;
					break;
				case "portal-sprite (3)":
					//GameObject hero = GameObject.Find("Hero");
					hero.transform.position = new Vector3( -98,2,0);
					DimensionalShiftManager.triggerChangeWorld = true;
					break;
				case "portal-sprite-battlecave":
					//GameObject hero = GameObject.Find("Hero");
					hero.transform.position = new Vector3( -23,10,0);
					//DimensionalShiftManager.triggerChangeWorld = true;
					break;
				case "portal-sprite-parcours":
					//GameObject hero = GameObject.Find("Hero");
					hero.transform.position = new Vector3( -30,18,0);
					//DimensionalShiftManager.triggerChangeWorld = true;
					break;
				case "mushroom_good_64x64-1.png":
					//GameObject hero = GameObject.Find("Hero");
					hero.transform.position = new Vector3(-23,10,0);
					DimensionalShiftManager.triggerChangeWorld = true;
					break;
				case "mushroom_good_64x64-1.png (1)":
					//GameObject hero = GameObject.Find("Hero");
					hero.transform.position = new Vector3(-23,10,0);
					DimensionalShiftManager.triggerChangeWorld = true;
					break;
			}
		}
    }
	
/*	
    // Update is called once per frame
    void Update()
    {
        
    }
	*/
}
