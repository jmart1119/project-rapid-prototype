using System.Collections;
using System.Collections.Generic;
using UnityEngine.AI;
using UnityEngine;


public class WanderState : MonoBehaviour {
    NavMeshAgent _controller;
    Vector2 randomNums;
    Vector3 target;
    NavMeshPath path;
    // Use this for initialization
	void Start () {
        path = new NavMeshPath();
        _controller = GetComponent<NavMeshAgent>();
        randomNums = Random.insideUnitCircle * 25;
        target = new Vector3(transform.position.x+randomNums.x, 0, transform.position.z+randomNums.y);
        while((NavMesh.CalculatePath(transform.position, target, NavMesh.AllAreas, path)))
        {
            Debug.Log("in the loop");
            randomNums = Random.insideUnitCircle * 60;
            target = new Vector3(transform.position.x + randomNums.x, 0, transform.position.z + randomNums.y);
        }
        _controller.destination = target;
    }
	
	// Update is called once per frame
	void Update () {
       Debug.DrawLine(transform.position, _controller.destination, Color.blue);
       Debug.Log(transform.position - _controller.destination);
        if (transform.position.x - _controller.destination.x <=1 && transform.position.z - _controller.destination.z <= 0)
        {
            Debug.Log("has arrived");
            randomNums = Random.insideUnitCircle * 60;
            target = new Vector3(transform.position.x + randomNums.x, 0, transform.position.z + randomNums.y);
            while ((NavMesh.CalculatePath(transform.position, target, NavMesh.AllAreas, path)))
            {
                randomNums = Random.insideUnitCircle * 25;
                target = new Vector3(transform.position.x + randomNums.x, 0, transform.position.z + randomNums.y);
            }
            _controller.destination = target;
        }  
	}
}
