using TMPro;
using UnityEngine;

interface IInteractable
{
    public void Interact();
    void DefaultInteract();
}

public class Interact : MonoBehaviour
{
    private QuestManager questManager;
    public TMP_Text text;
    public Transform InteractSource;
    public float InteractRange;

    void Start()
    {
        text.enabled = false; 
        questManager = FindFirstObjectByType<QuestManager>();
    }

    void Update()
    {
        Ray r = new Ray(InteractSource.position, InteractSource.forward);
        if (Physics.Raycast(r, out RaycastHit hitInfo, InteractRange))
        {
            if (hitInfo.collider.gameObject.TryGetComponent(out IInteractable interactObj))
            {


                if (interactObj is Sit sitScript && questManager.currentQuestIndex == 0 ||
                    interactObj is GenNum num && questManager.currentQuestIndex == 1)
                {
                    text.enabled = true;
                    if (Input.GetKeyDown(KeyCode.E))
                    {
                        interactObj.Interact();
                    }
                }
                else
                {
                    if (Input.GetKeyDown(KeyCode.E))
                    {
                        interactObj.DefaultInteract();
                    }
                }
                return;
            }
        }

        text.enabled = false;
    }
}
