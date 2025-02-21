using UnityEngine;
using UnityEngine.SceneManagement;

public class Enter : MonoBehaviour, IInteractable
{

    // Start is called once before the first execution of Update after the MonoBehaviour is created

    public QuestManager questManager;
    public Interact interactScript;

    void Start()
    {
        questManager = FindFirstObjectByType<QuestManager>();
        interactScript = FindFirstObjectByType<Interact>();


    }

    public void Interact(){
        SceneManager.LoadScene("Jatek3", LoadSceneMode.Single);
    }

    public void DefaultInteract(){
        return;
    }

    // Update is called once per frame
    void Update()
    {

    }
}
