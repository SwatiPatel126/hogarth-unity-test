using UnityEngine;

namespace CombatSystem
{
    // This script will move camera on right button drag and rotate camera on left button drag
    public class CameraMovement : MonoBehaviour
    {
        [SerializeField]
        private float _rotationSpeed = 5f;
        [SerializeField]
        private float _moveSpeed = 2f;
        private Vector3 _lastMousePosition;
        private Camera _cam;

        private void Start()
        {
            _cam = Camera.main;
        }

        private void Update()
        {
            RotateCamera();
            MoveCamera();
        }

        private void RotateCamera()
        {
            //Rotate using left click
            if (Input.GetMouseButton(0))
            {
                float mouseX = Input.GetAxis("Mouse X");
                transform.Rotate(0f, mouseX * _rotationSpeed, 0f, Space.World);
            }
        }

        private void MoveCamera()
        {
            //Move using right click
            if (Input.GetMouseButtonDown(1))
                _lastMousePosition = Input.mousePosition;

            if (Input.GetMouseButton(1))
            {
                Vector3 delta = Input.mousePosition - _lastMousePosition;
                Vector3 move = ((transform.right * delta.x) + (transform.forward * delta.y)) * _moveSpeed * Time.deltaTime;
                transform.position += move;

                _lastMousePosition = Input.mousePosition;
            }
        }
    }
}