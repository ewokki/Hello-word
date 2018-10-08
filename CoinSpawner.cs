using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinSpawner : MonoBehaviour {
	public GameObject Coins;
	public GameObject House;
	public GameObject Cube_s;
	public GameObject Cube_m;
	Vector3 lastplace;
	int i;
	
	void SpawnObjects() {
		Vector3 size = GetComponent<Renderer>().bounds.size;
		Vector3 center = GetComponent< Renderer>().bounds.center;
		Vector3 position = center + new Vector3(Random.Range(-size.x / 2 +12, size.x / 2 -12), 4.1f, Random.Range(-size.z / 2 +12, size.z / 2 -12));
      var checkResult = Physics.OverlapSphere(position, 3F);
      if (Physics.CheckSphere(position, 4F))
        {
            print("there is object!!!");
        }
      else {
      if (checkResult.Length == 0 && Vector3.Distance(lastplace, position)> 13)  {
        // all clear!
        int rdm = Random.Range(1,10);
        Debug.Log("rakennus spawnattu");
        if (rdm < 3) {
        Instantiate(House, position, Quaternion.Euler(270, 0, 0));
        }
        else if(rdm > 3 && rdm < 6) {
        Instantiate(Cube_m, position, Quaternion.identity );		
        }
        else {
        Instantiate(Cube_s, position, Quaternion.identity );	
        }
        lastplace = position;
    }
      else {
      	Debug.Log("objektia ei spawnattu");
      }
		
	}
	}
	void SpawnCoins() {
		Vector3 size = GetComponent<Renderer>().bounds.size;
		Vector3 center = GetComponent< Renderer>().bounds.center;
		Vector3 position = center + new Vector3(Random.Range(-size.x / 2, size.x / 2), 1, Random.Range(-size.z / 2, size.z / 2));
      var checkResult = Physics.OverlapSphere( position, 0.7F);
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
		for (i =0; i< 20; i++)
			SpawnObjects();
		for (i = 0; i< 5; i++) {
			SpawnCoins();
			Debug.Log(Coin.CoinCount);
		}
		
	}
	
	
	    
	// Update is called once per frame
	void Update () {
	}
}
