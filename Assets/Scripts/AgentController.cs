using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

public class AgentController : MonoBehaviour
{
    NavMeshAgent agent;
    public Transform destination;
    bool isSearching;


    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        destination = GameObject.FindWithTag("Player").transform;
        isSearching=true;
    }

    void Update()
    {
        if(destination != null)
        agent.SetDestination(destination.position);
        if(CheckDistance() && isSearching)
        {
            Debug.Log("Te Cace");
            isSearching=false;
        }

        if(GameManager.Instance.cachedRing)
        {
            agent.speed = 3.5f;
        }

        else
        {
            agent.speed = 7f;

        }

    }

    bool CheckDistance()
    {
        float distanceToPlayer= Vector3.Distance(transform.position, destination.position);
        if(distanceToPlayer <= 1)
        {
            return true;
        }
        else{
            return false;
        }
    }

     
}
