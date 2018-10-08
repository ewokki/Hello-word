using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundPlay : MonoBehaviour {
	
	public static AudioSource audio;


	// Use this for initialization
	void Start () {
		audio = GetComponent<AudioSource>();
	}
	public static void PlaySound() {
		audio.Play();
	}
	// Update is called once per frame
	void Update () {
		
	}
}
