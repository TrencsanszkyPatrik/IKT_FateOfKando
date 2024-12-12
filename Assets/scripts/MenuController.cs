using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    public QuestManager questManager;

    // J�t�k ind�t�sa
    public void StartGame()
    {
        // Vissza�ll�tjuk a k�ldet�seket alaphelyzetbe
        if (questManager != null)
        {
            questManager.ResetQuest(); // Alaphelyzetbe �ll�tjuk a k�ldet�seket
        }

        // Bet�ltj�k a J�t�k jelenetet
        SceneManager.LoadScene("Jatek");
    }

    // Be�ll�t�sok megnyit�sa
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
