using UnityEngine;
public class InteractionManager : MonoBehaviour
{
    private QuestManager questManager;

    public interface IInteractable
    {

        void DefaultInteract();
    }

    void Start()
    {
        questManager = FindFirstObjectByType<QuestManager>();
    }

    public void HandleInteraction(IInteractable interactObj)
    {
        if (interactObj is Sit sitScript && questManager.currentQuestIndex == 0)
        {
            sitScript.Interact();
        }
        else if (interactObj is GenNum genNum && questManager.currentQuestIndex == 1)
        {
            genNum.Interact();
        }

        else
        {
            interactObj.DefaultInteract();
        }
    }
}