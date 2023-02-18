using UnityEngine;

namespace _src.Player
{
    public class MouseManagerMono : MonoBehaviour
    {
        [SerializeField]
        private LayerMask mousePlaneLayerMask;

        private UnityEngine.Camera mainCamera;

        private Ray currentRay;

        private void Start()
        {
            mainCamera = UnityEngine.Camera.main;
        }

        private void Update()
        {
            transform.position = GetMouseWorldPosition();
        }

        private void OnDrawGizmos()
        {
            Gizmos.color = Color.yellow;
            Gizmos.DrawRay(currentRay.origin, currentRay.origin + currentRay.direction * 1000);
            Gizmos.color = Color.blue;
            Gizmos.DrawRay(currentRay.direction, currentRay.GetPoint(10));
        }

        public Vector3 GetMouseWorldPosition()
        {
            Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
            Physics.Raycast(ray, out RaycastHit hit, 100, mousePlaneLayerMask);
            currentRay = ray;
            return hit.point;
        }
    }
}