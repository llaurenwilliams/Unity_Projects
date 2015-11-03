using UnityEngine;
using System.Collections;

public class move_robot : MonoBehaviour
{

    private bool selected = false;
    private NavMeshAgent agent;
    private Vector3 MoveTo;
    private Animator anim;
    private bool move = false;
    private bool walking = false;
    private bool run = false;


    void Start()
    {
        agent = gameObject.GetComponent<NavMeshAgent>();
        anim = gameObject.GetComponent<Animator>();
    }

    void Update()
    {
        if (selected && move)
        {
            agent.SetDestination(MoveTo);
            anim.SetFloat("Speed", 0.25f);
            move = false;
            walking = true;
        }

        if (!agent.pathPending)
        {
            if (agent.remainingDistance <= agent.stoppingDistance)
            {
                if (!agent.hasPath || agent.velocity.sqrMagnitude == 0f)
                {
                    anim.SetFloat("Speed", 0);
                    walking = false;
                }
            }
        }

        if (agent.remainingDistance < 1)
        {
            anim.SetBool("Run", false);
        }

        if (walking && run)
        {
            anim.SetBool("Run", true);
            run = false;
        }

        if (agent.isOnOffMeshLink && walking)
        {
            anim.SetBool("Jump", true);
        }
        else
        {
            anim.SetBool("Jump", false);
        }

    }

    /*
    void FixedUpdate()
    {
        anim.SetFloat("Speed", animSpeed);
        //anim.SetFloat("Direction", 5);
        anim.speed = animSpeed;
    }
    */

    void Select(int x)
    {
        selected = true;
        // Debug.Log("Selected");
    }

    void Deselect(int x)
    {
        selected = false;
        // Debug.Log("Deselected");
    }

    void Destination(Vector3 d)
    {
        MoveTo = d;
        move = true;
    }

    void DoubleClick(int x)
    {
        run = true;
    }

    /*
    // Old Script
	private NavMeshAgent agent;
	void Start() {
		agent = GetComponent<NavMeshAgent>();
	}
	void Update() {
		RaycastHit hit;
		if (Input.GetMouseButtonDown(0)) {
			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			if (Physics.Raycast(ray, out hit))
				agent.SetDestination(hit.point);
			
		}
	}
    */
}