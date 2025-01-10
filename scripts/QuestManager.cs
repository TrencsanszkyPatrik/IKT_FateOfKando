using TMPro;
using UnityEngine;
using System.Collections.Generic;

public class QuestManager : MonoBehaviour
{
    public int currentQuestIndex = 0;
    public TMP_Text text; 

    private List<string> questtexts = new List<string>
    {
        "Szívj el egy dohányterméket mielőtt bemész.",
        "Vedd fel az elemlámpát az asztalról",
        "Küldetés 3 szövege", 
    };

    private static bool isQuestManagerCreated = false;

    void Start()
    {



        if (text == null)
        {
            text = GameObject.Find("QuestText_Feladat").GetComponent<TMP_Text>(); 
        }

        if (text == null)
        {
            Debug.LogError("TMP_Text referencia nem található a jelenetben!");
        }

        UpdateQuestText();
    }

    void UpdateQuestText()
    {
        if (questtexts.Count > 0 && currentQuestIndex < questtexts.Count)
        {
            text.text = questtexts[currentQuestIndex];  
        }
        else
        {
            text.text = "Nincs több küldetés!"; 
        }
    }

    // A küldetés teljesítése
    public void CompleteQuest(int questIndex)
    {
        if (questIndex == currentQuestIndex)
        {
            currentQuestIndex++;  
            UpdateQuestText();  
        }
    }

    public void ResetQuest()
    {
        currentQuestIndex = 0;  
        UpdateQuestText();  
    }

    public bool CanCompleteQuest(int questIndex)
    {
        return questIndex == currentQuestIndex;
    }
}
