using System;
using Cinemachine;
using UnityEngine;

namespace _src.Player.Camera
{
    public class CameraMovementManagerMono : MonoBehaviour
    {
        private const float MaxZoom = 12f;
        private const float MinZoom = 4f;

        [SerializeField]
        private CameraMovementData data;
        
        private CinemachineTransposer transposer;

        private void Start()
        {
            transposer = data.camera.GetCinemachineComponent<CinemachineTransposer>();
            
            transposer.m_FollowOffset = data.followOffset;
        }

        private void Update()
        {
            Move();
            Zoom();
        }

        private void Zoom()
        {
            float zoom = Input.mouseScrollDelta.y;
            if (zoom == 0)
            {
                return;
            }

            data.followOffset.y -= zoom * data.zoomAmount;
            data.followOffset.y = Mathf.Clamp(data.followOffset.y, MinZoom, MaxZoom);
            transposer.m_FollowOffset = Vector3.Lerp(transposer.m_FollowOffset, data.followOffset, Time.deltaTime * data.zoomSpeed);
        }

        private void Move()
        {
            Vector3 direction = GetPressedKeyDirection();
            Vector3 moveVector = transform.forward * direction.z + transform.right * direction.x;
            transform.position += moveVector * (data.moveSpeed * Time.deltaTime);
        }

        private static Vector3 GetPressedKeyDirection()
        {
            Vector3 direction = Vector3.zero;

            if (Input.GetKey(KeyCode.W))
            {
                direction.z += 1;
            }

            if (Input.GetKey(KeyCode.S))
            {
                direction.z -= 1;
            }

            if (Input.GetKey(KeyCode.A))
            {
                direction.x -= 1;
            }

            if (Input.GetKey(KeyCode.D))
            {
                direction.x += 1;
            }

            return direction;
        }

        [Serializable]
        public class CameraMovementData
        {
            public float moveSpeed = 10f;
            public Vector3 followOffset = new(0, 10f, -5);
            public float rotationSpeed = 100f;
            public float zoomAmount = 1f;
            public float zoomSpeed = 5f;
            public CinemachineVirtualCamera camera;
        }
    }
}