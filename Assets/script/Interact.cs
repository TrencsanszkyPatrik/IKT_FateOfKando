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
    public GameObject flashlight;
    public float InteractRange;
    private bool Flashlight_off = true;
    public bool Have_FlashLight = false;

    void Start()
    {
        text.enabled = false;
        flashlight.SetActive(false);
        questManager = FindFirstObjectByType<QuestManager>();
    }

    void Update()
    {
        if (Have_FlashLight)
        {
            if (Input.GetKeyDown(KeyCode.F) && Flashlight_off)
            {
                flashlight.SetActive(true);
                Flashlight_off = false;
            }
            else if (Input.GetKeyDown(KeyCode.F) && !Flashlight_off)
            {
                flashlight.SetActive(false);
                Flashlight_off = true;
            }
        } 

        Ray r = new Ray(InteractSource.position, InteractSource.forward);
        if (Physics.Raycast(r, out RaycastHit hitInfo, InteractRange))
        {
            if (hitInfo.collider.gameObject.TryGetComponent(out IInteractable interactObj))
            {


                if (interactObj is Sit sitScript && questManager.currentQuestIndex == 0 ||
                    interactObj is GiveFlash flash && questManager.currentQuestIndex == 1)
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
