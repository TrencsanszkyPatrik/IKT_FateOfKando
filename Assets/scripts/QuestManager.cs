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
        "Ülj le",
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
        // Először keressük meg a szöveg komponenst
        if (text == null)
        {
            text = GameObject.Find("QuestText_Feladat")?.GetComponent<TMP_Text>();
        }

        // Ha megvan a szöveg komponens, frissítsük a feladat szövegét
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
            Debug.Log($"Completing quest {questIndex}. Moving to quest {currentQuestIndex + 1}");
            currentQuestIndex++;
            UpdateQuestText();
        }
        else
        {
            Debug.Log($"Quest {questIndex} cannot be completed. Current quest is {currentQuestIndex}");
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