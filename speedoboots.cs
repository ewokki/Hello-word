using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace UnityStandardAssets.Characters.FirstPerson
{
public class speedoboots : MonoBehaviour {
	public int rspeed;
	public int wspeed;
	FirstPersonController speedo = null;
	// Use this for initialization
	void Start () {
		
	}
	
	void OnTriggerEnter(Collider Col)
	{
		//If player collected coin, then destroy object
		if(Col.CompareTag("Player")) {
			Debug.Log("köhköh");
			Destroy(gameObject);
			Timer.CountDown = Timer.CountDown + 10;
		}
			
		else {
			Debug.Log("ROAR");
		transform.position = new Vector3(Random.Range(-120.0F, 3.0F), 1, Random.Range(-30.0F, 30.0F));
		}
	}
	
		void OnDestroy()
	{
	  GameObject temp = GameObject.Find("FPSController");
		speedo = temp.GetComponent<FirstPersonController>();
		speedo.SpeedChange(rspeed, wspeed);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
}