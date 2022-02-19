using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MedipackScript : MonoBehaviour
{
		private void OnTriggerEnter(Collider other)
    {	
		string triggeredObjectTag =  this.gameObject.tag;
		string triggeringObject = other.name;
		print("Medipack entered");
		print("Triggering Object: " + triggeringObject);
		print("Triggered Object: " + this.gameObject);
		GameObject hero = GameObject.Find("Hero");
		float power = hero.GetComponent<DamageReceiver>().Health;
		
		if (triggeringObject == "Hero")
		{
			switch(triggeredObjectTag)
			{
				case "Medipack":
					Debug.Log("Medipack application");
					//DimensionalShiftManager.triggerChangeWorld = true;
					DimensionalShiftManager.switchWorldToDark();
					//hero.GetComponent<DamageReceiver>().Health = 100f;
					DamageReceiver.resetHealth();
					break;
				case "TrainingWarp (1)":
					//GameObject hero = GameObject.Find("Hero");
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
					hero.transform.position = new Vector3( -98,2,0);
					DimensionalShiftManager.triggerChangeWorld = true;
					break;
				case "portal-sprite (3)":
					//GameObject hero = GameObject.Find("Hero");
					hero.transform.position = new Vector3( -98,2,0);
					DimensionalShiftManager.triggerChangeWorld = true;
					break;
				case "Finish":
					//"mushroom_good_64x64-1.png":
					//GameObject hero = GameObject.Find("Hero");
					hero.transform.position = new Vector3( -98,2,0);
					DimensionalShiftManager.triggerChangeWorld = true;
					break;
			}
		}
    }

}
