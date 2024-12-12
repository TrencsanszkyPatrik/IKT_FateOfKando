using TMPro;
using UnityEngine;

interface IInteractable
{
    void Interact();
    void DefaultInteract();
}

public class Interact : MonoBehaviour
{
    private QuestManager questManager;
    public TMP_Text text;
    public GameObject flashlight;
    private IInteractable currentInteractable;
    private bool Flashlight_off = true;
    public bool Have_FlashLight = false;
    public AudioSource hangeffekt;
    public AudioClip flashlightSound;

    void Start()
    {
        text.enabled = false;
        flashlight.SetActive(false);
        questManager = FindFirstObjectByType<QuestManager>();
    }

    public void ToggleFlashlight()
    {
        if (!Have_FlashLight) return;

        Flashlight_off = !Flashlight_off;
        flashlight.SetActive(!Flashlight_off);
        hangeffekt.PlayOneShot(flashlightSound);
    }

    public void InteractWithObject()
    {
        if (currentInteractable == null)
        {
            Debug.Log("Nincs aktu�lis interakci�s objektum.");
            return;
        }

        Debug.Log($"Interakci�s objektum: {currentInteractable}");

        if (questManager.currentQuestIndex == 0 && currentInteractable is Smoke)
        {
            currentInteractable.Interact();
        }
        else if (questManager.currentQuestIndex == 1 && currentInteractable is Sit)
        {
            currentInteractable.Interact();
        }
        else if (questManager.currentQuestIndex == 3 && currentInteractable is GiveFlash)
        {
            currentInteractable.Interact();
        }
        else if (currentInteractable is Sit_random)
        {
            currentInteractable.Interact();
        }
        else
        {
            currentInteractable.DefaultInteract();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.TryGetComponent(out IInteractable interactable))
        {
            currentInteractable = interactable;
            text.enabled = true;
            Debug.Log($"Bel�p�s interakci�s z�n�ba: {interactable}");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.TryGetComponent(out IInteractable interactable) && interactable == currentInteractable)
        {
            Debug.Log($"Kil�p�s interakci�s z�n�b�l: {interactable}");
            currentInteractable = null;
            text.enabled = false;
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            HandleInput(KeyCode.F);
        }
        else if (Input.GetKeyDown(KeyCode.E))
        {
            HandleInput(KeyCode.E);
        }
    }

    public void HandleInput(KeyCode key)
    {
        if (key == KeyCode.F)
        {
            ToggleFlashlight();
        }
        else if (key == KeyCode.E)
        {
            InteractWithObject();
        }
    }
}
