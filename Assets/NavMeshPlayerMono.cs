using UnityEngine;
using UnityEngine.AI;

public class NavMeshPlayerMono : MonoBehaviour
{
    private NavMeshAgent agent;
    private Camera mainCamera;

    private void Start()
    {
        mainCamera = Camera.main;
        agent = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        if (!Input.GetMouseButtonDown(1))
        {
            return;
        }

        Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
        if (!Physics.Raycast(ray, out RaycastHit hit))
        {
            return;
        }

        //agent.Move(hit.point);
        agent.SetDestination(hit.point);
    }
}