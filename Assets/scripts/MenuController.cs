using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    public void StartGame()
    {
        SceneManager.LoadScene("Jatek"); 
    }

    public void OpenOptions()
    {
        Debug.Log("Options Menu"); 
    }

    public void QuitGame()
    {
        Application.Quit(); 
        Debug.Log("Game Quit");
    }
}
