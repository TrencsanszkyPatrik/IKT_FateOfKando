using UnityEngine;
public class GenNum : MonoBehaviour, IInteractable
{

    public QuestManager questManager;

    public void Start()
    {
        questManager = FindFirstObjectByType<QuestManager>();
    }
    public void Interact()
    {
        Debug.Log("Küldetéstől függő interakció.");
        questManager.CompleteQuest(0);  
    }

    public void DefaultInteract()
    {
    }
}
