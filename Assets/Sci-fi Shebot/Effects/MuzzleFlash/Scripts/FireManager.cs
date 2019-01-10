using UnityEngine;
using System.Collections;

public class FireManager : MonoBehaviour
{
    //public gameobjects 
    public GameObject muzzleFlash;
	//public GameObject bulletShellEffect;
	public GameObject muzzleFlashLight;


	void Update () 
	{
		// switching muzzleflash off/on via button press or released (am using mouse click for this demo)
	    if (Input.GetMouseButtonDown(0)) 
		{
					
					muzzleFlash.SetActive (true);

					///bulletShellEffect.SetActive (false);
					//bulletShellEffect.SetActive (true);
					muzzleFlashLight.SetActive (true);
				
         }

		if (Input.GetMouseButtonUp (0))
		{
			muzzleFlashLight.SetActive(false);
			muzzleFlash.SetActive (false);
		}

	  }

    
   
}
