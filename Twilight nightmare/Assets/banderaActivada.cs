using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class banderaActivada : MonoBehaviour
{
    [SerializeField] private int cantidadEnemigos;

    [SerializeField] private int enemigosEliminados;

    private Animator animator;


    private void Start()
    {
        animator = GetComponent<Animator>();
        cantidadEnemigos = GameObject.FindGameObjectWithTag("Enemy").layer;
    }

    private void ActivarBandera()
    {
        animator.SetTrigger("Activar");
    }

    public void EnemigoEliminado()
    {
        enemigosEliminados += 1;

        if (enemigosEliminados == cantidadEnemigos)
        {
            ActivarBandera();
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && enemigosEliminados == cantidadEnemigos)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }

}
