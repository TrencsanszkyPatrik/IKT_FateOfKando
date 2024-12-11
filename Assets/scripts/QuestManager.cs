
using TMPro;
using UnityEngine;
using System.Collections.Generic;
public class QuestManager : MonoBehaviour
{
    public int currentQuestIndex = 0;
    public TMP_Text text;

    public void Start()
    {
        text.text = "Szívj el egy dohányterméket mielőtt bemész.";
    }

    List<string> questtexts = new List<string>
    {
        
        "1",

        "2",

        "3",

        "Vedd fel az elemlámpát az asztalról",

        "Vedd fel az elemlámpát az asztalról",

        "Vedd fel az elemlámpát az asztalról"
    };

    public void CompleteQuest(int questIndex)
    {
        if (questIndex == currentQuestIndex)
        {
            currentQuestIndex++;
            Debug.Log($"Küldetés {questIndex} teljesítve! Következő küldetés: {currentQuestIndex}");
            text.text = questtexts[currentQuestIndex];
        }
    }

    public bool CanCompleteQuest(int questIndex)
    {
        return questIndex == currentQuestIndex;
    }
}
