using UnityEngine;
using UnityEngine.UI;
using System.Collections;


public class Nav_Mesh_Obstacle : MonoBehaviour {
	
	public float speed;
	public int count;
	
	public float yPosition;
	
	private Rigidbody rb;
	
	
	public float rotationSpeed = 100;
	public int jumpHeight = 5;
	
	const int MAX_JUMP = 0;
	int jumpCount = 0;
	
	void Start ()
	{
		rb = GetComponent<Rigidbody> ();
		
	}
	
	void OnCollisionStay()
	{
		jumpCount = 0;
	}
	
	void FixedUpdate ()
	{
		float moveHorizontal = Input.GetAxis ("Horizontal");
		float moveVertical = Input.GetAxis ("Vertical");
		
		
		Vector3 movement = new Vector3 (moveHorizontal, 0.0f, moveVertical);
		
		rb.AddForce (movement * 15);
		
		if (Input.GetKeyDown(KeyCode.L) && jumpCount == MAX_JUMP) 
		{
			jumpCount++;
			
			rb.velocity = new Vector3(rb.velocity.x,rb.velocity.y + jumpHeight,rb.velocity.z);
		}
		
		yPosition = transform.position.y;
		
	}
	


}