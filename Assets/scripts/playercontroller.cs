using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class playercontroller : MonoBehaviour
{
    public float velocidad = 5.0f;
    public float rotacionSpeed = 35.0f;
    private float tiempoDeJuego = 0.0f;
    private int puntuacion = 0;
    public int colisionesRestantes = 3;
    public Text puntuacionText;
    private Rigidbody rb;
    public Text colisionesRestantesText;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        colisionesRestantes = 3;
    }

    void Update()
    {
        // Input para movimiento
        float movimientoHorizontal = Input.GetAxis("Horizontal");
        float movimientoVertical = Input.GetAxis("Vertical");

        // Calcula la dirección de movimiento y la rotación
        Vector3 movimiento = new Vector3(movimientoHorizontal, movimientoVertical, 0);
        Vector3 rotacion = new Vector3(0, 0, -movimientoHorizontal * rotacionSpeed);

        // Aplica el movimiento y rotación
        rb.velocity = movimiento * velocidad;
        rb.angularVelocity = rotacion * Mathf.Deg2Rad;
        // Actualiza el tiempo de juego y la puntuación
        tiempoDeJuego += Time.deltaTime;
        puntuacion = (int)tiempoDeJuego;
        puntuacionText.text = "Puntuación: " + puntuacion.ToString();
        // Actualiza las colisiones restantes del jugador
        colisionesRestantesText.text = "Colisiones Restantes: " + colisionesRestantes.ToString();
    }
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Obstaculo"))
        {
            colisionesRestantes--;

            if (colisionesRestantes <= 0)
            {
                Destroy(gameObject);
                Debug.Log("Juego terminado");
            }
        }
    }
}
