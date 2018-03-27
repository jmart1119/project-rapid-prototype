using UnityEngine;
using UnityEngine.AI;
using System.Collections;

public class Enemy : MonoBehaviour {
  //  enum STATE(WANDER, CHASE, FLEE);
    NavMeshAgent _controller;
    Transform _target;
    //STATE _currentState;
	void Start ()
	{
        _controller = GetComponent<NavMeshAgent>();
        _target = GameObject.Find("ThirdPersonController").transform;

      //  _currentState = STATE.WANDER;
    }
	
	void Update()
	{
        _controller.SetDestination(_target.position);
		
	}
}
