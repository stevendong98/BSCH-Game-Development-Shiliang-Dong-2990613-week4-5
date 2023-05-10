using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Player : MonoBehaviour
{
    [SerializeField] NavMeshAgent agent;
    [SerializeField] Animator anim;
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;

            if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, 500))
            {
                agent.destination = hit.point;
            }
        }

        if (agent.velocity.magnitude > 0) anim.SetBool("Run",true);
        else anim.SetBool("Run", false);

    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Enemy") UIChaseGame.Instance.GameLost();

        if (other.tag == "Target") UIChaseGame.Instance.GameWon();

    }
}
