using UnityEngine;

public class RotacionTierra : MonoBehaviour
{
    public float velocidadRotacion = 1.0f; 

    void Update()
    {
        // Rotar la Tierra lentamente
        transform.Rotate(Vector3.up * velocidadRotacion * Time.deltaTime);
    }
}
