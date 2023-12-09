using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float m_moveSpeed = 7f;
    [SerializeField] private float m_turnSmoothTime = 0.1f;

    private CharacterController m_controller;
    private float m_turnSmoothVelocity;
    private float m_epsilon = 0.1f;

    private void Awake()
    {
        m_controller = GetComponent<CharacterController>();
    }

    private void Update()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        Vector3 direction = new Vector3(horizontal, 0f, vertical).normalized;

        if (direction.magnitude >= m_epsilon)
        {
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref m_turnSmoothVelocity, m_turnSmoothTime);
            transform.rotation = Quaternion.Euler(0f, angle, 0f);

            m_controller.Move(direction * m_moveSpeed * Time.deltaTime);
        }
    }
}
