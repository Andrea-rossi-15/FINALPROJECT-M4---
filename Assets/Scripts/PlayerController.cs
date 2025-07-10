using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f;
    private Rigidbody rb;
    public float mouseSensitivity = 100f;

    public float jumpForce = 7f;
    public float groundCheckRadius = 0.3f;
    public float groundCheckDistance = 0.1f;
    public LayerMask Ground;
    private bool isGrounded;

    public int maxHealth = 100;
    int currentHealth;

    [SerializeField] int Turretdamage;



    void Start()
    {
        rb = GetComponent<Rigidbody>();

        currentHealth = maxHealth;
    }
    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;

        transform.Rotate(Vector3.up * mouseX);


        GroundCheck();

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            Jump();
        }


    }
    void FixedUpdate()
    {
        float moveX = Input.GetAxis("Horizontal");
        float moveZ = Input.GetAxis("Vertical");
        Vector3 move = new Vector3(moveX, 0, moveZ);
        rb.MovePosition(rb.position + move * moveSpeed * Time.fixedDeltaTime);
    }
    void Jump()
    {
        rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
    }

    void GroundCheck()
    {
        Vector3 origin = transform.position + Vector3.up * 0.1f;

        isGrounded = Physics.SphereCast(origin, groundCheckRadius, Vector3.down, out RaycastHit hit, groundCheckDistance + 0.1f, Ground);

    }

    public void TakeDamage(int Turretdamage)
    {
        currentHealth -= Turretdamage;
        if (currentHealth <= 0)
        {
            Debug.Log("Il player muore");
            Destroy(gameObject);
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        TakeDamage(Turretdamage);
    }

}
