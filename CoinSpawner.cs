using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinSpawner : MonoBehaviour {
	public GameObject Coins;
	Vector3 lastplace;
	int i;
	
	void SpawnCoins() {
		//määrittää kentän koon
		Vector3 size = GetComponent<Renderer>().bounds.size;
		Vector3 center = GetComponent< Renderer>().bounds.center;
		//määrittää mihin kolikko instantioituu
		Vector3 position = center + new Vector3(Random.Range(-size.x / 2, size.x / 2), 1, Random.Range(-size.z / 2, size.z / 2));
		//tarkastaa onko instantioudussa paikassa törmäystä muihin objekteihin
      var checkResult = Physics.OverlapSphere( position, 0.5F);
      if (checkResult.Length == 0 && Vector3.Distance(lastplace, position)> 20) {
        // all clear!
        Debug.Log("Kolikko spawnattu");
        Instantiate(Coins, position, Quaternion.identity );
        lastplace = position;
    }
      else {
      	i--;
      	Debug.Log("Kolikko ei spawnattu");
      }
		 }
    
    
	
	 
	// Use this for initialization
	void Start () {
		for (i = 0; i< 5; i++) {
			SpawnCoins();
			
		}
		
	}
	
	
	    
	// Update is called once per frame
	void Update () {
		Debug.Log(Coin.CoinCount);
	}
}
