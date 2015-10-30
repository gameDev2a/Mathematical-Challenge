using UnityEngine;
using System.Collections;

public class SoundScript : MonoBehaviour {
	public AudioClip PickupSound;
	public AudioClip calculateSound;
	public AudioClip errorSound;
	public AudioClip winSound;
	// Use this for initialization
	void Start () {
	
	}

	public void PlayErrSound(){
		GetComponent<AudioSource>().PlayOneShot (errorSound);
	}

	public void PlayCalcSound(){
		GetComponent<AudioSource>().PlayOneShot (calculateSound);
	}

	public void PlayPickupSound(){
		GetComponent<AudioSource>().PlayOneShot (PickupSound);
	}

	public void PlayWinSound(){
		GetComponent<AudioSource>().PlayOneShot (winSound);
	}
}
