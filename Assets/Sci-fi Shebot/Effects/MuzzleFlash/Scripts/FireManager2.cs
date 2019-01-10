using UnityEngine;
using System.Collections;

public class FireManager2 : MonoBehaviour
{
	//public gameobjects 
    public GameObject muzzleFlash;
	public GameObject muzzleFlashLight;

	void Update () 
	{
		//Debug.Log(" Rifle FireinG!!!!!!!!");
		// switching muzzleflash off/on via button press or released (am using mouse click for this demo)
		if (Input.GetButtonDown("Fire1") == true) 
		{

			muzzleFlash.SetActive (true);
			muzzleFlashLight.SetActive (true);
			//Debug.Log(" Rifle FireinG!!!!!!!!");

         }

		if (Input.GetButtonUp("Fire1") == true) 
		{
			muzzleFlash.SetActive (false);
			muzzleFlashLight.SetActive (false);
		}

	}
	public void fire(){

		muzzleFlash.SetActive (true);
			muzzleFlashLight.SetActive (true);
	}
	public void EndFire(){
		muzzleFlash.SetActive (false);
			muzzleFlashLight.SetActive (false);

	}

    
}