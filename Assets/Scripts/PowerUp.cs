using System.Collections;
using System.Collections.Generic;
using UnityEngine.AI;
using UnityEngine;

public class PowerUp : MonoBehaviour {
    Material m_Material;
    Color normColor;//will get the original color of the goodGuy, not being hardcoded to white so the color of the player can be changed
    //from the inspector without having to adjust the hardcoded line in the program.
    Color boostColor = Color.cyan;//declaring this here will make it easier to change later if more code is added
    NavMeshAgent _goodGuyController;
    GameObject EnemyStateManager;

    bool isActive = false;//flag to keep the player from powering up when they are already boosting
	// Use this for initialization
	void Start () {
        EnemyStateManager = GameObject.Find("BadGuy");
        _goodGuyController = GameObject.Find("GoodGuy").GetComponent<NavMeshAgent>();
        m_Material = gameObject.GetComponent<Renderer>().material;
        normColor = m_Material.color;
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Space) && !isActive) 
        {
            EnemyStateManager.GetComponent<FiniteStateManager>().poweredUP = true;
            isActive = true;
            _goodGuyController.speed = _goodGuyController.speed * 2;//giving the good guy a speed boost
            m_Material.color = boostColor; //changing goodguy color to show that he's being powered up
            //Undo the effects of the powerup after 5 second
            Invoke("PowerDown", 5);
        }
	}

    void PowerDown()
    {
        EnemyStateManager.GetComponent<FiniteStateManager>().poweredUP = false;
        m_Material.color = normColor;//returning good guy to original color
        _goodGuyController.speed = _goodGuyController.speed / 2;//slowing goodGuy down to normal speed
        Invoke("coolDownOver", 5);//finish cooling down 5 seconds later for a total of 10 seconds
    }

    void coolDownOver()
    {
        isActive = false;//powerup can now be used again
    }
}
