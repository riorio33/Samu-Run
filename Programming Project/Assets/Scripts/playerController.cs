using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerController : MonoBehaviour
{
    
	public float speed;
	public float jumpForce;
	private float moveInput;
	private Rigidbody2D rb;
	
	[SerializeField]
	private bool isGrounded;
	public Transform groundCheck;
	public float checkRadius;
	public LayerMask whatIsGround;
	
	public int extraJumps;
	
	private Animator animator;
	
	
	
    
    void Start()
    {
	    rb = GetComponent<Rigidbody2D>(); 
	    animator = GetComponent<Animator>();
    }
	
	void Update()
	{
		
		isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, whatIsGround);

		
		if(isGrounded == true)
		{
			extraJumps = 1;
		}
		
		if(Input.GetKeyDown(KeyCode.Space) && extraJumps > 0)
		{
			rb.velocity = Vector2.up * jumpForce;
			extraJumps--;
		}
		
	}
	
	// Implement OnDrawGizmos if you want to draw gizmos that are also pickable and always drawn.
	protected void OnDrawGizmos()
	{
		Gizmos.DrawWireSphere(groundCheck.position, checkRadius);
	}
}
