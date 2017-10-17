using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWeapons : MonoBehaviour {

	public GameObject laserPrefab;
	public float projectileOffset = 1f;
	public float projectileSpeed;
	public float fireRate = 0.2f;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown (KeyCode.Space)){
			InvokeRepeating ("Fire", 0.000001f, fireRate);
		}
		if(Input.GetKeyUp (KeyCode.Space)){
			CancelInvoke ("Fire");
		}
	}

	void Fire(){
		GameObject laser = Instantiate (laserPrefab, new Vector3 (transform.position.x, transform.position.y + projectileOffset, transform.position.z), 
			Quaternion.identity) as GameObject;
		laser.GetComponent <Rigidbody2D>().velocity = new Vector3 (0, projectileSpeed, 0);
	}
}
