using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyChase : MonoBehaviour
{
    private Rigidbody2D rb2D;
    // Variables públicas para ajustar la velocidad del enemigo y referenciar al jugador
    public float speed = 2.0f;
    public Transform player;

    // Radio de detección del enemigo
    public float detectionRange = 5.0f;

    // Variable privada para almacenar la distancia entre el enemigo y el jugador
    private float distanceToPlayer;

    private void Awake()
    {
    
        
        rb2D = GetComponent<Rigidbody2D>();
        
    }

    void Update()
    {
        // Calcular la distancia entre el enemigo y el jugador
        distanceToPlayer = Vector2.Distance(transform.position, player.position);

        // Si el jugador está dentro del rango de detección
        if (distanceToPlayer < detectionRange)
        {
            // Calcular la dirección hacia el jugador
            Vector2 direction = (player.position - transform.position).normalized;

            // Mover al enemigo hacia el jugador
            transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);

           
        }
    }

    // Dibujar el radio de detección en el editor para tener una referencia visual
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, detectionRange);
    }
}
