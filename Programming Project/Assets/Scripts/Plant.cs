using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Threading;

public class Plant : MonoBehaviour
{
	public Animator animator;
	
	public float speed = 10.0f; 
	private Rigidbody2D rb;
	[SerializeField]
	private Vector2 screenBounds;
	
	
	
	void Start()
	{
		rb = this.GetComponent<Rigidbody2D>();
		rb.velocity = new Vector2(-speed, 0);
		screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
	    
	}

	void Update()
	{
		if (transform.position.x < -13.0f || transform.position.x > 17.0f)
		{
			Destroy(this.gameObject);
		}
	}
    
	void OnTriggerEnter2D(Collider2D other) 
	{
		if (other.CompareTag("Player"))
		{
			other.GetComponent<playerCombat>().alive = false;
			Debug.Log(other.GetComponent<playerCombat>().alive);
		}
	}
	
	public void Die()
	{
		animator.SetTrigger("CactusDie");
		
		GetComponent<Collider2D>().enabled = false;
		//this.enabled = false;
	}
}
