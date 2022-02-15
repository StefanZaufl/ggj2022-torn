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
		print("Warp entered");
		print(other.name);
		GameObject hero = GameObject.Find("Hero");
		hero.transform.position = new Vector3( 120,-10,0);
		DimensionalShiftManager.triggerChangeWorld = true;
    }

/*	
    // Update is called once per frame
    void Update()
    {
        
    }
	*/
}
