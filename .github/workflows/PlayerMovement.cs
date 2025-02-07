using UnityEngine;
using System.Collections; // Necesario para usar corrutinas

public class PlayerMovement : MonoBehaviour
{
    public float speed = 5f;       // Velocidad normal
    public float dashSpeed = 10f;  // Velocidad del dash
    private Rigidbody2D rb;        // Referencia al Rigidbody2D
    private Vector2 movement;      // Almacena la dirección del movimiento

    private bool canDash = true;   // Controla si el jugador puede hacer dash
    private float dashTime = 0.2f; // Duración del dash
    private float dashCooldown = 1f; // Tiempo de espera antes de poder usar dash de nuevo

    void Start()
    {
        rb = GetComponent<Rigidbody2D>(); // Obtiene el Rigidbody2D al iniciar el juego
    }

    void Update()
    {
        // Captura la entrada del jugador en los ejes X e Y
        movement.x = Input.GetAxis("Horizontal");
        movement.y = Input.GetAxis("Vertical");

        // Si el jugador presiona LeftShift y el dash está disponible, lo activamos
        if (Input.GetKeyDown(KeyCode.LeftShift) && canDash)
        {
            StartCoroutine(Dash()); // Inicia la corrutina de dash
        }
    }

    void FixedUpdate()
    {
        // Movimiento normal con interpolación para suavizar
        rb.velocity = Vector2.Lerp(rb.velocity, movement * speed, 0.1f);
    }

    IEnumerator Dash()
    {
        canDash = false; // Desactiva el dash para evitar que se use de nuevo de inmediato
        float originalSpeed = speed; // Guarda la velocidad original

        speed = dashSpeed; // Aumenta la velocidad al hacer dash
        yield return new WaitForSeconds(dashTime); // Espera el tiempo de duración del dash

        speed = originalSpeed; // Restaura la velocidad normal
        yield return new WaitForSeconds(dashCooldown); // Espera el tiempo de enfriamiento

        canDash = true; // Reactiva la posibilidad de hacer dash
    }
}
