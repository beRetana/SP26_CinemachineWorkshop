using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float speed = 5f;
    [SerializeField] private float gravity = -9.81f;
    [SerializeField] private float jumpHeight = 3f;

    private Vector3 _velocity;
    private bool _isGrounded;
    
    private CharacterController controller;

    void Start()
    {
        TryGetComponent(out controller);
    }

    void Update()
    {
        _isGrounded = controller.isGrounded;

        if (_isGrounded && _velocity.y < 0) _velocity.y = -2f;
        

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;

        controller.Move(move * speed * Time.deltaTime);

        if (Input.GetButtonDown("Jump") && _isGrounded) {
            _velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }

        _velocity.y += gravity * Time.deltaTime;

        controller.Move(_velocity * Time.deltaTime);
    }
}

