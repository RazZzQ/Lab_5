using UnityEngine;

public class obstaculo : MonoBehaviour
{
    public float velocidadTranslacion = 5.0f;
    public float velocidadRotacion = 30.0f;
    public Transform jugador;

    void Update()
    {
        if (jugador != null)
        {
            // Calcula la dirección hacia el jugador
            Vector3 direccion = jugador.position - transform.position;
            direccion.Normalize();

            // Calcula el ángulo de rotación
            float anguloRotacion = Mathf.Atan2(direccion.y, direccion.x) * Mathf.Rad2Deg;

            // Aplica la rotación del obstáculo
            transform.rotation = Quaternion.Euler(0, 0, anguloRotacion);

            // Movimiento del obstáculo hacia el jugador
            transform.position += direccion * velocidadTranslacion * Time.deltaTime;
        }
    }
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("Colisión con el jugador");
            Destroy(gameObject);
        }
    }
}
