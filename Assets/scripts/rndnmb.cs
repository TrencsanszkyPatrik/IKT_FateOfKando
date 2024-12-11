using UnityEngine;
public class GiveFlash : MonoBehaviour, IInteractable
{
    public QuestManager questManager;
    public GameObject FlashLight;
    public Interact interactScript;  
    public AudioSource hang;
    

    public void Start()
    {
        questManager = FindFirstObjectByType<QuestManager>();
        interactScript = FindFirstObjectByType<Interact>(); 
    }

    public void Interact()
    {
        if (questManager.currentQuestIndex == 2) // Ne felejtsem átírni majd ha tényleg hasznalni kell, mert megint egy orat fogok vele szopni, köszi elore
        {
            interactScript.Have_FlashLight = true; 
        }
      
    }

    public void DefaultInteract()
    {
    }
}
