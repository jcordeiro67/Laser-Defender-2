using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.WSA;

public class EnemyWeapons : MonoBehaviour {

	public GameObject projectile;
	public float projectileSpeed = 20f;
	public float shotsPerSecond = 0.5f;
	public float projectileOffset;
	
	// Update is called once per frame
	void Update () {
		
		float probability = Time.deltaTime * shotsPerSecond;

		if(Random.value < probability){
			EnemyFire ();
		}

	}

	void EnemyFire(){

		GameObject laser = Instantiate (projectile, new Vector3 (transform.position.x, transform.position.y - projectileOffset, transform.position.z),
			Quaternion.identity) as GameObject;
		laser.GetComponent <Rigidbody2D>().velocity = new Vector2 (0, -projectileSpeed);
	}
}
