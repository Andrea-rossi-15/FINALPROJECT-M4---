using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    [Header("Movimento")]
    public float moveSpeed = 5f;
    public float mouseSensitivity = 100f;

    [Header("Salto")]
    public float jumpForce = 7f;
    public float groundCheckDistance = 0.1f;
    public LayerMask Ground;
    public bool isGrounded;

    [Header("Salute")]
    public int maxHealth = 100;
    public int currentHealth;
    [SerializeField] int Turretdamage;

    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        currentHealth = maxHealth;
    }

    void Update()
    {

        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        transform.Rotate(Vector3.up * mouseX);

        if (isGrounded == true)
        {

        }

        GroundCheck();


        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            Debug.Log("jump");
            Jump();
        }
    }

    void FixedUpdate()
    {
        float moveX = Input.GetAxis("Horizontal");
        float moveZ = Input.GetAxis("Vertical");
        Vector3 move = new Vector3(moveX, 0f, moveZ);

        rb.MovePosition(rb.position + transform.TransformDirection(move) * moveSpeed * Time.fixedDeltaTime);
    }

    void Jump()
    {

        Vector3 velocity = rb.velocity;
        velocity.y = 0f;
        rb.velocity = velocity;

        rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
    }

    void GroundCheck()
    {
        Vector3 origin = transform.position + Vector3.up * 0.1f;
        float checkDistance = groundCheckDistance + 0.1f;

        isGrounded = Physics.Raycast(origin, Vector3.down, checkDistance, Ground);
        Debug.DrawRay(origin, Vector3.down * checkDistance, isGrounded ? Color.green : Color.red);
    }

    public void TakeDamage(int Turretdamage)
    {
        currentHealth -= Turretdamage;
        if (currentHealth <= 0)
        {
            SceneManager.LoadScene("LoosePanel");
            Destroy(gameObject);
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Bullet"))
        {
            TakeDamage(Turretdamage);
        }
    }
}
