using UnityEngine;

namespace Controllers
{
    public class HeroMovementController : MonoBehaviour
    {
        [SerializeField] private Rigidbody2D _rb;
        [SerializeField] private float _walkSpeed;

        private float _inputHorizontal;
        private float _inputVertical;

        void Update()
        {
            Move();
            Rotate();
        }

        void Move()
        {
            _inputHorizontal = Input.GetAxisRaw("Horizontal");
            _inputVertical = Input.GetAxisRaw("Vertical");

            Vector2 movement = new Vector2(_inputHorizontal * _walkSpeed, _inputVertical * _walkSpeed);

            if (_inputHorizontal != 0 || _inputVertical != 0)
            {
                _rb.velocity = movement;
            }
            else
            {
                _rb.velocity = Vector2.zero;
            }
        }

        void Rotate()
        {
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector3 direction = (mousePosition - transform.position).normalized;

            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(transform.rotation.x, transform.rotation.y, angle);
        }
    }
}
