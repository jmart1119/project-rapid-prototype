using System.Collections;
using System.Collections.Generic;
using UnityEngine.AI;
using UnityEngine;

public class FiniteStateManager : MonoBehaviour
{
    NavMeshAgent _controller;
    public int maxDistance;
    GameObject player;
    bool chaseState;
    bool wanderState;
    bool fleeState;
    public bool poweredUP;
    // Use this for initialization
    void Start()
    {
        _controller = GetComponent<NavMeshAgent>();
        player = GameObject.Find("ThirdPersonController");
        chaseState = false;
        wanderState = true;
        fleeState = false;
        poweredUP = false;
    }

    void changeState()
    {
        gameObject.GetComponent<WanderState>().enabled = wanderState;
        gameObject.GetComponent<Enemy>().enabled = chaseState;
        gameObject.GetComponent<RunningState>().enabled = fleeState;
    }
    // Update is called once per frame
    void Update()
    {
        if (wanderState)
        {
            if (InSight() && !(player.GetComponent<hiding>().inCloset))
            {
                wanderState = false;
                chaseState = true;
                fleeState = false;
                changeState();
                _controller.speed = 20;
                Debug.Log("SWITCH TO: chaseState");
            }
        }
        else if (chaseState)
        {
         
            if (!InSight() || player.GetComponent<hiding>().inCloset) {
                wanderState = true;
                chaseState = false;
                fleeState = false;
                changeState();
                _controller.speed = 15;
                Debug.Log("SWITCH TO: wanderState");
            }
            else if (poweredUP)
            {
                wanderState = false;
                chaseState = false;
                fleeState = true;
                changeState();
                _controller.speed = 20;
               // Debug.Log("SWITCH TO: RunAwayState");
            }
        }
        else if (fleeState)
        {
            if(!poweredUP)
            {
                if (InSight() && !(player.GetComponent<hiding>().inCloset))
                {
                    wanderState = false;
                    chaseState = true;
                    fleeState = false;
                    _controller.speed = 20;
                //    Debug.Log("SWITCH TO: chaseState");
                }
                else
                {
                    wanderState = true;
                    chaseState = false;
                    fleeState = false;
                    _controller.speed = 15;
                    //Debug.Log("SWITCH TO: wanderState");
                }
                changeState();
            }
        }        
    }

    bool InSight()
    {
        RaycastHit hit;
        Vector3 direction = player.transform.position - gameObject.transform.position;
        Debug.DrawRay(transform.position, direction, Color.red);
        if (Physics.Raycast(gameObject.transform.position, direction, out hit, maxDistance)) {
          // Debug.Log(hit.transform.tag);
            if (hit.transform.CompareTag("Player"))
            {
                //Debug.Log("Have Line of Sight!!!!!!!");
                return true;
            }
        }
        //Debug.Log("Lost line of sight");
        return false;
    } 
}
