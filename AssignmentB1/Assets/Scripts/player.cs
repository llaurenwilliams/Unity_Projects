using UnityEngine;
using System.Collections;

public class player : MonoBehaviour {
	
	public Animator anim;
	public Rigidbody rbody;
	public Transform unitychan;
	
	private float inputH;
	private float inputV;
	private bool run;
	
	private Vector3 curLoc;
	private Vector3 prevLoc;
	private Vector3 newpos;
	
	private NavMeshAgent agent;
	private Vector3 curpos;
	private Vector3 lastpos;
	
	private bool isWalking;
	private int counter =0;
	private bool sprinting ;
	
	void goToDestination (Vector3 v) {
		agent.SetDestination (v);
		isWalking = true;
	}
	
	void toggleSpeed() {
		Debug.Log ("entered");
		if (counter %2 == 0 ) {
			Debug.Log ("sprint");
			sprinting = true;
			//anim.SetBool ("run", true);
			Debug.Log (anim.GetBool ("run"));
			//anim.Play ("Run",-1,0f);
			++counter;
		} 
		else {
			Debug.Log ("walk");
			sprinting = false;
			//anim.SetBool("run",false);
			++counter;
		}
		//anim.SetBool ("run", !anim.GetBool ("run"));
	}
	
	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator> ();
		rbody = GetComponent<Rigidbody> ();
		unitychan = GetComponent<Transform> ();
		agent = GetComponent<NavMeshAgent> ();
		run = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (!agent.pathPending) {
			if (agent.remainingDistance <= agent.stoppingDistance) {
				if (!agent.hasPath || agent.velocity.sqrMagnitude == 0f) {
					isWalking = false;
					anim.SetBool ("isWalking", false);
				}
			}
		} 
		
		
		if (isWalking) {
			//anim.Play ("WALK00_F", -1, 0f);
			Debug.Log ("is walking");
			anim.SetBool ("isWalking", true);
			if (sprinting == true && isWalking == true) {
				anim.SetBool ("run",true);
				agent.speed = 7f;
				Debug.Log (agent.speed);
			}
			else{
				anim.SetBool ("run",false);
				agent.speed = 3.5f;
			}
			if (Input.GetKey (KeyCode.Space)) {
				anim.SetBool ("jump", true);
			} 
			else {
				anim.SetBool ("jump",false);
			}
		}
		
		
		if (agent.isOnOffMeshLink == true) {
			Debug.Log("JUMP");
			
			anim.Play ("JUMP00",-1,0f);
			
		}
		
		
		
		
		
		
		
		
	}
}


