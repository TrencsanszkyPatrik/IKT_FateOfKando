using UnityEngine;
public class GiveFlash : MonoBehaviour, IInteractable
{
    public QuestManager questManager;
    public GameObject FlashLight;
    public Interact interactScript;  

    public void Start()
    {
        questManager = FindFirstObjectByType<QuestManager>();
        interactScript = FindFirstObjectByType<Interact>(); 
    }

    public void Interact()
    {
        if (questManager.currentQuestIndex == 1)
        {
            interactScript.Have_FlashLight = true; 
        }
      
    }

    public void DefaultInteract()
    {
    }
}
