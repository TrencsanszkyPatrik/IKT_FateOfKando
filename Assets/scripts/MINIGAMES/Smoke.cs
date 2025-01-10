using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Smoke : MonoBehaviour, IInteractable
{
    public QuestManager questManager;
    public Interact interactScript;
    public ParticleSystem smoke;
    private bool smoke_play = false;
    private bool done;

    public string miniGameSceneName = "RollMinigame";

    public void Start()
    {
        questManager = FindFirstObjectByType<QuestManager>();
        interactScript = FindFirstObjectByType<Interact>();
    }

    public async void Interact()
    {
        if (questManager.currentQuestIndex == 0)
        {
            try
            {
                var loadOperation = SceneManager.LoadSceneAsync(miniGameSceneName, LoadSceneMode.Single);

                Cursor.visible = true;
                Cursor.lockState = CursorLockMode.None;

                while (!loadOperation.isDone)
                {
                    await Task.Yield();
                }

            }
            catch (System.Exception e)
            {
                Debug.LogError($"Hiba a jelenetváltás során: {e.Message}");
            }
        }

        questManager.CompleteQuest(0);
    }


    public void DefaultInteract()
    {
    }
}