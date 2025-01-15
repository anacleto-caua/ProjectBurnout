using UnityEngine;

public class NewMonoBehaviourScript : MonoBehaviour
{
    public float speed = 5f; // Velocidade de movimento
    public float gravity = -9.81f; // Gravidade
    public float jumpHeight = 1.5f; // Altura do pulo
    public float constV = -2f;

    private CharacterController controller;
    private Vector3 velocity;
    private bool isGrounded;

    // Configurações para detecção de solo
    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;

    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    void Update()
    {
        // Verifica se está no chão
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = constV; // Reseta a velocidade ao tocar o chão
        }

        // Movimento no plano X e Z
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * -z + transform.forward * x;
        controller.Move(move * speed * Time.deltaTime);

        // Pulo
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * constV * gravity);
        }

        // Aplicação da gravidade
        velocity.y += gravity * Time.deltaTime;

        // Move o personagem no eixo Y
        controller.Move(velocity * Time.deltaTime);
    }
}
