using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class RunningState : MonoBehaviour {
    NavMeshAgent _controller;
    Transform _target;
    // Use this for initialization
    void Start () {
        _controller = GetComponent<NavMeshAgent>();
        _target = GameObject.Find("GoodGuy").transform;
    }
	
	// Update is called once per frame
	void Update () {
        Vector3 direction = _target.position - transform.position;
        _controller.SetDestination(transform.position - (direction));
    }
}
