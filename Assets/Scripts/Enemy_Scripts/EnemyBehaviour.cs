using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.WSA;

public class EnemyBehaviour : MonoBehaviour {

	public float health = 20f;

	private float currentHealth;

	// Use this for initialization
	void Start () {
		currentHealth = health;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter2D(Collider2D col){
		
		Projectile laser = col.gameObject.GetComponent <Projectile> ();

		if(laser){
			ApplyDamage (laser.GetDamage ());
			laser.Hit ();
		}
	}

	void ApplyDamage(float damage){
		currentHealth -= damage;

		if(currentHealth <= 0){
			Destroy (gameObject);
		}
	}
		
}
