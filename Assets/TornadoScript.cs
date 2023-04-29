using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class TornadoScript : MonoBehaviour
{
    private NavMeshAgent agent;
    private Transform player;
    public float timer;
    
    // Start is called before the first frame update
    void Start()
    {
        timer = 10;
        player = GameObject.FindGameObjectWithTag("player").transform;
        agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        agent.destination = player.position;
        timer -= Time.deltaTime;
        if (timer < 0)
        {
            Destroy(gameObject);
        }
    }
}
