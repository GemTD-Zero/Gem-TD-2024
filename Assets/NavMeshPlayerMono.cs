using System.Numerics;
using UnityEngine;
using UnityEngine.AI;
using Vector3 = UnityEngine.Vector3;

public class NavMeshPlayerMono : MonoBehaviour
{
    private NavMeshAgent agent;
    private Camera mainCamera;
    private Vector3 previousPosition;

    private void Start()
    {
        mainCamera = Camera.main;
        agent = GetComponent<NavMeshAgent>();
        previousPosition = transform.position;
    }

    public void SetDestination(Vector3 destination)
    {
        agent.SetDestination(destination);
    }

    public bool IsAtDestionation()
    {
        if (agent.pathPending)
        {
            return false;
        }

        if (!(agent.remainingDistance <= agent.stoppingDistance))
        {
            return false;
        }

        return agent.hasPath || agent.velocity.sqrMagnitude == 0f;
    }

    // private void Update()
    // {
    //     float speed = ((transform.position - previousPosition) / Time.deltaTime).magnitude;
    //     Debug.Log(speed);
    //     previousPosition = transform.position;
    //     
    //     if (!Input.GetMouseButtonDown(1))
    //     {
    //         return;
    //     }
    //
    //     Debug.Log("Right Clicked");
    //
    //     Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
    //     if (!Physics.Raycast(ray, out RaycastHit hit))
    //     {
    //         Debug.Log("Can't hit!");
    //         return;
    //     }
    //
    //     //agent.Move(hit.point);
    //     agent.SetDestination(hit.point);
    // }
}