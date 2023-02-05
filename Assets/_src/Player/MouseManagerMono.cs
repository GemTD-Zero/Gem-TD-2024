using UnityEngine;

namespace _src.Player
{
    public class MouseManagerMono : MonoBehaviour
    {
        [SerializeField]
        private LayerMask mousePlaneLayerMask;

        private UnityEngine.Camera mainCamera;

        private void Start()
        {
            mainCamera = UnityEngine.Camera.main;
        }

        private void Update()
        {
            transform.position = GetMouseWorldPosition();
        }

        private Vector3 GetMouseWorldPosition()
        {
            Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
            Physics.Raycast(ray, out RaycastHit hit, float.MaxValue, mousePlaneLayerMask);
            return hit.point;
        }
    }
}