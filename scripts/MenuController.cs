using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{

    // J�t�k ind�t�sa
    public void StartGame()
    {
        
        SceneManager.LoadScene("Jatek");
    }


    public void OpenOptions()
    {
        Debug.Log("Options Menu");
    }

    // Kil�p�s a j�t�kb�l
    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("Game Quit");
    }
}
