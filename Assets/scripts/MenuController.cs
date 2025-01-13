using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    public QuestManager questManager;

    // Játék indítása
    public void StartGame()
    {
        // Visszaállítjuk a küldetéseket alaphelyzetbe
        if (questManager != null)
        {
            questManager.ResetQuest(); // Alaphelyzetbe állítjuk a küldetéseket
        }

        // Betöltjük a Játék jelenetet
        SceneManager.LoadScene("Jatek");
    }

    // Beállítások megnyitása
    public void OpenOptions()
    {
        Debug.Log("Options Menu");
    }

    // Kilépés a játékból
    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("Game Quit");
    }
}
