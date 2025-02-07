using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 5f; // Velocidad del jugador
    private Rigidbody2D rb;  // Referencia al Rigidbody2D
    private Vector2 movement; // Almacena la dirección del movimiento

    void Start()
    {
        rb = GetComponent<Rigidbody2D>(); // Obtiene el Rigidbody2D al iniciar el juego
    }

    void Update()
    {
        // Captura la entrada del jugador en los ejes X e Y
        movement.x = Input.GetAxis("Horizontal");
        movement.y = Input.GetAxis("Vertical");
    }

    void FixedUpdate()
    {
        // Aplica un movimiento suave interpolando la velocidad actual con la nueva
        rb.velocity = Vector2.Lerp(rb.velocity, movement * speed, 0.1f);
    }
}

