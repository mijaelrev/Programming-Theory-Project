
using UnityEngine;

namespace Code.PlayerManager
{
    public class CameraController : MonoBehaviour
    {
        [SerializeField] private Camera _camera;
        [SerializeField] private GameObject _player;
        [SerializeField] private float _sensibilityX = 100.0f;
        [SerializeField] private float _distance = 10f;
        [SerializeField] private float _moveViewUpPosition = 0.7f;

        //TODO: Remover(seguro de remover la borrar el todo de mas abajo)
        private float hitDistance;
        private RaycastHit hit;
        private Vector3 _cameraPosition = Vector3.zero;
        private Vector3 _cameraOclussion;
        private Vector3 _rayDirection;

        private float _mouseX = 0.0f;
        private float _mouseY = 0.0f;

        private const float ANGLE_Y_MIN = -85f, ANGLE_Y_MAX = 85f;
        private const float MIN_DISTANCE = 0.5f, MAX_DISTANCE = 10f;

        private Transform _myTransform;

        //private bool _mustCursorLock; //Cursor
        private void Start()
        {
            _myTransform = transform;
        }

        private void Update()
        {
            _rayDirection = _myTransform.position - _player.transform.position - Vector3.up * _moveViewUpPosition;
            _mouseX += Input.GetAxis("Mouse X") * _sensibilityX * Time.deltaTime;
            _mouseY += Input.GetAxis("Mouse Y") * _sensibilityX * Time.deltaTime;
            _distance -= Input.GetAxisRaw("Mouse ScrollWheel") * 3f;

            _distance = Mathf.Clamp(_distance, MIN_DISTANCE, MAX_DISTANCE);
            _mouseY = Mathf.Clamp(_mouseY, ANGLE_Y_MIN, ANGLE_Y_MAX);

            //CursorChangeState();
        }



        private void FixedUpdate()
        {
            var ray = new Ray(_player.transform.position + Vector3.up * _moveViewUpPosition, _rayDirection);
            Debug.DrawRay(_player.transform.position + Vector3.up * _moveViewUpPosition, _rayDirection, Color.blue, Time.fixedDeltaTime, true);
            if (Physics.Raycast(ray, out hit))
            {
                Debug.DrawRay(hit.point, Vector3.up * 0.1f, Color.white);

            }
            //TODO: quitar esto, innecesario
        }

        private void LateUpdate()
        {
            var direction = new Vector3(0, 0, _distance);
            var rotation = Quaternion.Euler(_mouseY, _mouseX, 0);

            _myTransform.position = _player.transform.position + rotation * direction;
            _myTransform.LookAt(_player.transform.position + Vector3.up * _moveViewUpPosition);

        }
        /*private void CursorChangeState()
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                if (!_mustCursorLock)
                {
                    Cursor.lockState = CursorLockMode.Locked;
                }
                if (_mustCursorLock)
                {
                    Cursor.lockState = CursorLockMode.None;
                }
                _mustCursorLock = !_mustCursorLock;
            }
        }*/
    }
}