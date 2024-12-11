using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using static UnityEngine.ParticleSystem;
public class Smoke : MonoBehaviour, IInteractable
{
    public QuestManager questManager;
    public Interact interactScript;
    public ParticleSystem smoke;


    public void Start()
    {
        questManager = FindFirstObjectByType<QuestManager>();
        interactScript = FindFirstObjectByType<Interact>();
    }

    public async void Interact()
    {
        if (questManager.currentQuestIndex == 0)
        {

            smoke.Play();
            await Task.Delay(600);
            smoke.Stop();
            await Task.Delay(1000);


            questManager.CompleteQuest(0);
        }

    }


    public void DefaultInteract()
    {
    }
}
