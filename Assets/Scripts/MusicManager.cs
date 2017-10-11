using UnityEngine;
using System.Collections;


public class MusicManager : MonoBehaviour {

	static MusicManager instance = null;

	void Awake(){
		
		if(instance != null){	// If a musicManager exists
			Destroy (gameObject);	// Destroy self

		}

		else {
			
			instance = this;	// Instance eguals the first instance of musicmanager
			GameObject.DontDestroyOnLoad (gameObject);	// Don't destroy this instance of musicmanager

		}
	}
}

