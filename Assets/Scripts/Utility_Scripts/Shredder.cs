using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof (BoxCollider2D))]

public class Shredder : MonoBehaviour {


	void OnDrawGizmos(){
		
		Gizmos.color = Color.red;
		Gizmos.DrawWireCube (transform.position, new Vector3(transform.localScale.x, transform.localScale.y, 0f));

	}

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter2D(Collider2D col){
		Destroy (col.gameObject);
	}

}
