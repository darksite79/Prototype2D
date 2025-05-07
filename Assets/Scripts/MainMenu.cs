using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject menuUI;
    private bool gameStarted = false;

    void Start()
    {
        // Verifica si es una recarga por New Game
        if (PlayerPrefs.GetInt("GameStarted", 0) == 1)
        {
            gameStarted = true;
            Time.timeScale = 1f;
            menuUI.SetActive(false);
            Cursor.visible = false;
        }
        else
        {
            Time.timeScale = 0f;
            menuUI.SetActive(true);
            Cursor.visible = true;
        }
    }

    public void NewGame()
    {
        PlayerPrefs.SetInt("GameStarted", 1); // Marca que ya empezó
        PlayerPrefs.Save();
        Time.timeScale = 1f;
        Cursor.visible = false;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex); // Reinicia la escena actual
    }

    public void Resume()
    {
        if (!gameStarted) return;

        menuUI.SetActive(false);
        Cursor.visible = false;
        Time.timeScale = 1f;
    }

    public void QuitGame()
    {
        Debug.Log("Saliendo del juego...");
        Application.Quit();
    }

    void Update()
    {
        if (gameStarted && Input.GetKeyDown(KeyCode.Escape))
        {
            bool isActive = menuUI.activeSelf;
            menuUI.SetActive(!isActive);
            Cursor.visible = true;
            Time.timeScale = isActive ? 1f : 0f;
        }
    }
}

