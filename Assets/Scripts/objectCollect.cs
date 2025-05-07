using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class objectCollect : MonoBehaviour
{
 public int scoreValue = 1; // Puntos que otorga al recolectar.

    /*private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            
            // Añadir lógica de recolección (ej: aumentar puntuación).
            GameManager.Instance.AddScore(scoreValue);
            Destroy(gameObject); // Opcional: destruir el objeto al recolectar.
        }
    }*/

private void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.CompareTag("Player"))
            return;

        string tag = gameObject.tag;

        if (tag == "Collectable")
        {
            GameManager.Instance.AddScore(scoreValue);
            Destroy(gameObject);
        }
        else if (tag == "Obstacle")
        {
            GameManager.Instance.GameOver();
            
            // Puedes también hacer efectos como desactivar jugador, mostrar UI, etc.
        }
        else if (tag == "Flag")
        {
            GameManager.Instance.WinGame();
            Destroy(gameObject);
            // Lógica de victoria, como transiciones, sonidos, etc.
        }
    }

}
