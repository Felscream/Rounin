///////////////////////////////////////////////////////////
//  This Script is used just for this DEMO only
//  Not meant for actual development .
////////////////////////////////////////////////////////////
using UnityEngine;
using System.Collections;

public class TriggerShield : MonoBehaviour {

	public Animator animator;

	// Use this for initialization
	void Start () {
		animator = GetComponent<Animator>();
	}

	// Update is called once per frame
	void Update () {
		
		bool fire = Input.GetButtonDown("Fire1");

		//animator.SetBool("Fire", fire);
		if (fire == true) 
		{

			animator.SetTrigger ("Close");
		}
	}

}
