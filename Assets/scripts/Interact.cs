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
        text.enabled = false; // A szöveg alapértelmezetten rejtve van
        questManager = FindFirstObjectByType<QuestManager>();
    }

    void Update()
    {
        Ray r = new Ray(InteractSource.position, InteractSource.forward);
        if (Physics.Raycast(r, out RaycastHit hitInfo, InteractRange))
        {
            if (hitInfo.collider.gameObject.TryGetComponent(out IInteractable interactObj))
            {
                // Küldetéstől független interakciós lehetőség
                text.enabled = true;

                // Ha a küldetés megfelel, akkor végrehajtjuk a küldetéstől függő interakciót
                if (interactObj is Sit sitScript && questManager.currentQuestIndex == 0 ||
                    interactObj is GenNum num && questManager.currentQuestIndex == 1)
                {
                    if (Input.GetKeyDown(KeyCode.E))
                    {text.enabled = true;

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

        // Ha nincs interakcióra alkalmas objektum, a szöveg rejtve marad
        text.enabled = false;
    }
}
