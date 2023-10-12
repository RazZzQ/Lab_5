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
            // Calcula la direcci�n hacia el jugador
            Vector3 direccion = jugador.position - transform.position;
            direccion.Normalize();

            // Calcula el �ngulo de rotaci�n
            float anguloRotacion = Mathf.Atan2(direccion.y, direccion.x) * Mathf.Rad2Deg;

            // Aplica la rotaci�n del obst�culo
            transform.rotation = Quaternion.Euler(0, 0, anguloRotacion);

            // Movimiento del obst�culo hacia el jugador
            transform.position += direccion * velocidadTranslacion * Time.deltaTime;
        }
    }
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("Colisi�n con el jugador");
            Destroy(gameObject);
        }
    }
}
