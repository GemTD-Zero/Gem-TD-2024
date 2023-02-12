using Unity.AI.Navigation;
using UnityEngine;

public class NavMeshMono : MonoBehaviour
{
    [SerializeField]
    private Transform prefab;

    private Camera mainCamera;
    private NavMeshSurface surface;

    private void Start()
    {
        mainCamera = Camera.main;
        surface = GetComponent<NavMeshSurface>();
        
    }

    private void Update()
    {
        if (!Input.GetMouseButtonDown(0))
        {
            return;
        }


        Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
        if (!Physics.Raycast(ray, out RaycastHit hit))
        {
            return;
        }

        Instantiate(prefab, hit.point, Quaternion.identity);
        surface.BuildNavMesh();
    }
}