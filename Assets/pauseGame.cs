using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class pauseGame : MonoBehaviour
{
    public static bool gameIsPaused;
    public GameObject overlay;
    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            gameIsPaused = !gameIsPaused;
            PauseGame();
        }
    }
  public  void PauseGame()
    {
        if (gameIsPaused)
        {
            Time.timeScale = 0f;
            overlay.SetActive(true);
        }
        else
        {
            Time.timeScale = 1;
            overlay.SetActive(false);
        }
    }
    public void restart()
    {
        Scene scene = SceneManager.GetActiveScene(); SceneManager.LoadScene(scene.name);



     
    }   
    public void toMenu()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex  - 1);
        }
}
