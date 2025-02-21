using TMPro;
using UnityEngine;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine.SceneManagement;

public class QuestManager : MonoBehaviour
{
    public int currentQuestIndex = 0;
    public TMP_Text text;  // Szöveg referenciája
    private List<string> questtexts = new List<string>
    {
        "Szívj el egy dohányterméket mielőtt bemész.",
        "Menj be az iskolába",
        "Vedd fel az elemlámpát az asztalról",
        "Küldetés 3 szövege",
        "Küldetés 4 szöbege",
    };
    private static bool isQuestManagerCreated = false;

    void Start()
    {
        if (!isQuestManagerCreated)
        {
            DontDestroyOnLoad(gameObject);
            isQuestManagerCreated = true;
        }

        SceneManager.sceneLoaded += OnSceneLoaded;
        UpdateQuestText();
    }

    private void OnDestroy()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    void UpdateQuestText()
    {
        if (text == null)
        {
            text = GameObject.Find("QuestText_Feladat")?.GetComponent<TMP_Text>();
        }

        if (text != null)
        {
            if (currentQuestIndex < questtexts.Count)
            {
                text.text = questtexts[currentQuestIndex];
            }
            else
            {
                text.text = "Nincs több küldetés!";
            }
        }
        else
        {
            Debug.LogError("TMP_Text referencia nem található a jelenetben!");
        }
    }

    public void CompleteQuest(int questIndex)
    {
        if (questIndex == currentQuestIndex)
        {
            currentQuestIndex++;
            UpdateQuestText();
        }
        else
        {
        }
    }


    public void ResetQuest()
    {
        currentQuestIndex = 0;
        UpdateQuestText();
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        UpdateQuestText(); 
    }

    public bool CanCompleteQuest(int questIndex)
    {
        return questIndex == currentQuestIndex;
    }
}