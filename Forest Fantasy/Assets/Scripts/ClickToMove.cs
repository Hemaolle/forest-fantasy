using UnityEngine;
using System.Collections;
using System.Collections.Generic;
  
public class ClickToMove : MonoBehaviour {
    
    public float shootDistance = 10f;
    public float shootRate = .5f;
//        public PlayerShooting shootingScript;
    
    private Animator anim;
    private NavMeshAgent navMeshAgent;
    private Transform targetedEnemy;
    private Ray shootRay;
    private RaycastHit shootHit;
    private bool walking;
    private bool enemyClicked;
    private float nextFire;

    private List<GameObject> stopRequesters;
    
    // Use this for initialization
    void Awake () 
    {
        anim = GetComponent<Animator> ();
        navMeshAgent = GetComponent<NavMeshAgent> ();
        stopRequesters = new List<GameObject>();
    }
    
    // Update is called once per frame
    void Update () 
    {
        Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
        RaycastHit hit;
        if (Input.GetButtonDown ("Fire1")) 
        {
            Debug.Log("input registered");
            if (Physics.Raycast(ray, out hit, 100))
            {
//                    if (hit.collider.CompareTag("Enemy"))
//                    {
//                        targetedEnemy = hit.transform;
//                        enemyClicked = true;
//                    }
//                    
//                    else
//                    {
                    walking = true;
                    enemyClicked = false;
                    navMeshAgent.destination = hit.point;
                    navMeshAgent.Resume();
//                    }
            }
        }
        
        if (enemyClicked) {
            MoveAndShoot();
        }
        
        if (navMeshAgent.remainingDistance <= navMeshAgent.stoppingDistance) {
            if (!navMeshAgent.hasPath || Mathf.Abs (navMeshAgent.velocity.sqrMagnitude) < float.Epsilon)
                walking = false;
        } else {
            walking = true;
        }
        
        anim.SetBool ("IsWalking", walking);
    }
    
    private void MoveAndShoot()
    {
        if (targetedEnemy == null)
            return;
        navMeshAgent.destination = targetedEnemy.position;
        if (navMeshAgent.remainingDistance >= shootDistance) {
            
            navMeshAgent.Resume();
            walking = true;
        }
        
        if (navMeshAgent.remainingDistance <= shootDistance) {
            
            transform.LookAt(targetedEnemy);
            Vector3 dirToShoot = targetedEnemy.transform.position - transform.position;
            if (Time.time > nextFire)
            {
                nextFire = Time.time + shootRate;
//                    shootingScript.Shoot(dirToShoot);
            }
            navMeshAgent.Stop();
            walking = false;
        }
    }
    
	public bool IsWalking() {
		return walking;
	}

    public void StopMoving(GameObject requester) {
        stopRequesters.Add(requester);
        navMeshAgent.Stop();
        anim.SetBool("IsWalking", false);
        walking = false;
        enabled = false;
    }

    public void ContinueMoving(GameObject requester) {
        stopRequesters.Remove(requester);
        if(stopRequesters.Count == 0) {
            enabled = true;
        }
    }
}