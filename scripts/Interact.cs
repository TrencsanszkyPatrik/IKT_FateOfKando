using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

interface IInteractable
{
    void Interact();
    void DefaultInteract();
}

public class Interact : MonoBehaviour
{
    public QuestManager questManager;
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
        questManager = FindObjectOfType<QuestManager>();
        Scene scene = SceneManager.GetActiveScene();
        if (scene.name == "Jatek2"){
            questManager.currentQuestIndex = 1;
        }
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
            questManager.CompleteQuest(questManager.currentQuestIndex);
        }
        else if (questManager.currentQuestIndex == 1 && currentInteractable is Sit)
        {
            currentInteractable.Interact();
        }
        else if (questManager.currentQuestIndex == 2 && currentInteractable is GiveFlash)
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
            Debug.Log($"Belépés interakciós zónába: {interactable}");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.TryGetComponent(out IInteractable interactable) && interactable == currentInteractable)
        {
            Debug.Log($"Kilépés interakciós zónából: {interactable}");
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
