using UnityEngine;
//actualizando
public class PlayerMovement : MonoBehaviour
{
    public float speed = 5f;
    private Rigidbody2D rb;
    private Vector2 movement;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        movement.x = Input.GetAxis("Horizontal");
        movement.y = Input.GetAxis("Vertical");
    }

//En lugar de asignar directamente velocity, usamos AddForce() para un movimiento más fluido y realista.
    void FixedUpdate()
    {
        rb.AddForce(movement * speed);
    }
}
