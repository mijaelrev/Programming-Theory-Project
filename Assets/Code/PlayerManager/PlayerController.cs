using UnityEngine;

namespace Assets.Code.PlayerManager
{
    [RequireComponent(typeof(Rigidbody))]
    public class PlayerController : MonoBehaviour
    {
        [Header("Components")]
        private Rigidbody _rigidbody;
        [SerializeField] private CapsuleCollider _capsule;
        [SerializeField] private Transform _camera;

        [Header("config")]
        [SerializeField] private float _speed = 3.5f;
        [SerializeField] private float _turnSmooth, _turnSmoothTime = 0.1f;
        private float _angle;
        private Vector3 _direction;
        private Vector3 _moveDirection = Vector3.zero;

        [Header("Check Ground Config")]
        [SerializeField] private LayerMask _layersMask;
        [SerializeField] private float _groundDistance = 1f, _checkRadius = 0.32f;

        private Vector3 _center;
        private Vector3 _checkPosition;

        [Header("Jump Control")]
        [SerializeField] private float _jumpForce = 8f;
        [SerializeField] private float _lowJumpMultiplier = 4f;
        [SerializeField] private float _fallMultiplier = 2.5f;

        [Header("NO")]
        [SerializeField] private float _newSpeed;   //Nueva velocidad, cambia entre una y otra

        private Transform _myTransform;
        private static PlayerController _instance;
        public static PlayerController Instance => _instance ?? (_instance = new PlayerController());   //Instancia si es nula se crea
        private void Start()
        {
            if (_rigidbody == null) //comprobaciones
            {
                _rigidbody = GetComponent<Rigidbody>();
                Debug.Log("Get CharacterController");
            }

            _myTransform = GetComponent<Transform>();
        }

        private void Update()
        {
            var horizontal = Input.GetAxisRaw("Horizontal");
            var vertical = Input.GetAxisRaw("Vertical");
            _direction = new Vector3(horizontal, 0, vertical).normalized;
            SimplePlayerInputs();

        }
        private void FixedUpdate() => PlayerDirectionMove();

        /// <summary>
        /// Inputs aplicados al player
        /// </summary>
        private void SimplePlayerInputs()
        {
            if (CheckGround() && Input.GetButtonDown("Jump"))
            {
                _rigidbody.velocity += Vector3.up * _jumpForce;
            }
            if (_rigidbody.velocity.y < 0)
            {
                _rigidbody.velocity += Vector3.up * Physics.gravity.y * (_fallMultiplier - 1f) * Time.deltaTime;

            }
            else if (_rigidbody.velocity.y > 0 && !Input.GetButton("Jump"))
            {
                _rigidbody.velocity += Vector3.up * Physics.gravity.y * (_lowJumpMultiplier - 1f) * Time.deltaTime;
            }

            if (Input.GetKey(KeyCode.LeftShift) && _direction.magnitude >= 0.1f)
            {
                _newSpeed = _speed * 2;
            }
            else if (_direction.magnitude >= 0.2f) //Evita que el Player se tenga deslizamiento
            {
                _newSpeed = _speed;
            }
            else
            {
                _newSpeed = 0;
            }

        }

        /// <summary>
        /// Move the character where camera view
        /// </summary>
        private void PlayerDirectionMove()
        {
            var velocityY = new Vector3(0, _rigidbody.velocity.y, 0);
            if (_direction.magnitude >= 0.2f)
            {
                var targetAngle = Mathf.Atan2(_direction.x, _direction.z) * Mathf.Rad2Deg + _camera.eulerAngles.y;
                _angle = Mathf.SmoothDampAngle(_myTransform.eulerAngles.y, targetAngle, ref _turnSmooth, _turnSmoothTime);
                _myTransform.rotation = Quaternion.Euler(0, _angle, 0);
                _moveDirection = Quaternion.Euler(0, targetAngle, 0) * Vector3.forward;

            }
            _rigidbody.velocity = _moveDirection.normalized * _newSpeed + velocityY;

        }

        /// <summary>
        /// verifica si has tocado el suelo
        /// </summary>
        /// <returns>Verdadero si has tocado la Layer indicada</returns>
        public bool CheckGround()
        {
            _center = _capsule.bounds.center;
            _checkPosition = Vector3.up * _groundDistance;
            return Physics.CheckSphere(_center - _checkPosition, _checkRadius, _layersMask);
        }
        public void OnDrawGizmos()
        {
            Gizmos.color = Color.red;
            Gizmos.DrawSphere(_center - _checkPosition, _checkRadius);
        }
    }
}