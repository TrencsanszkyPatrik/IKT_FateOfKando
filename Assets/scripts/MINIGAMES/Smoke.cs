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
                SceneManager.LoadScene(miniGameSceneName, LoadSceneMode.Single);
            }
            catch (System.Exception e)
            {
                Debug.LogError($"Hiba a jelenetváltás során: {e.Message}");
            }
        }
    }

    public void DefaultInteract()
    {
    }
}