using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro; 

public class GameManager : MonoBehaviour
{ 
    public static GameManager Instance;
    private int score = 0;
    public TMP_Text scoreText;
    private bool isGameOver = false;

    public GameObject gameOverPanel;
    public GameObject WinScreen;


    private void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(gameObject);
    }

    public void AddScore(int value)
    {
        score += value;
        Debug.Log("Score: " + score); // Opcional: actualizar UI aquí.
        scoreText.SetText(score.ToString());
    }

    public void PlayerDeath()
{
    // Reiniciar escena:
    score = 0;
    Debug.Log("Score: " + score);
    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    
    // O restar una vida:
    // lives--;
    // if (lives <= 0) GameOver();
}

public void GameOver() {
        //Debug.Log("Perdiste");
        isGameOver = true; // Detiene la lógica del juego
        Time.timeScale = 0f;         // Detiene el tiempo del juego
        Cursor.visible = true;
        gameOverPanel.SetActive(true);
                }

public void RestartGame() {
        Time.timeScale = 1f;         // Detiene el tiempo del juego
        Cursor.visible = false;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

public void WinGame()
{
    //Debug.Log("Ganaste");
    isGameOver = true; // Detiene la lógica del juego
    Time.timeScale = 0f;         // Detiene el tiempo del juego
    WinScreen.SetActive(true);
    Cursor.visible = true;
} 

}
