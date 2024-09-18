using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombateEnemigo : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            GameObject.FindGameObjectWithTag("Bandera").GetComponent<banderaActivada>().EnemigoEliminado();
            Destroy(gameObject);
        }
    }
}
