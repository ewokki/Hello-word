//-------------------------
using UnityEngine;
using System.Collections;
using UnityEngine.UI;
//-------------------------

[RequireComponent(typeof(AudioSource))]
public class Coin : MonoBehaviour
{
	public GameObject FireWorks;
	
	public Text SuccessText;
	//-------------------------
	public static int CoinCount = 0;
	
	
	//-------------------------
	// Use this for initialization
	 
   
        

        
	
	
	
	void Awake () 
	{
		
		SuccessText.enabled = false;
		//Object created, increment coin count
		++Coin.CoinCount;
		
	}
	//-------------------------
	void OnTriggerEnter(Collider Col)
	{
		//If player collected coin, then destroy object
		if(Col.CompareTag("Player")) {
			
			SoundPlay.PlaySound();
			Destroy(gameObject);
			Timer.CountDown = Timer.CountDown + 10;
		}
			
		else {
			Debug.Log("ROAR");
		transform.position = new Vector3(Random.Range(-120.0F, 3.0F), 1, Random.Range(-30.0F, 30.0F));
		}
	}
	
	
void Update() {

	}
	
	//-------------------------
	void OnDestroy()
	{
		--Coin.CoinCount;

        //Check remaining coins
        if (Coin.CoinCount <= 0)
        {
        	SuccessText.enabled = true;
            //Game is won. Collected all coins
            //Destroy Timer and launch fireworks
            GameObject Timer = GameObject.Find("TimerScreen");
            Destroy(Timer);
            
            Instantiate(FireWorks, transform.position, Quaternion.Euler(-90, 0, 0));

            GameObject[] FireworkSystems = GameObject.FindGameObjectsWithTag("Fireworks");

            if (FireworkSystems.Length <= 0) return;

            foreach (GameObject GO in FireworkSystems)
            {
                GO.GetComponent<ParticleSystem>().Play();
            }
        }
	}
	//-------------------------
}
//-------------------------