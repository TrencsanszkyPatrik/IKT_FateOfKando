using UnityEngine;
public class QuestManager : MonoBehaviour
{
    public int currentQuestIndex = 0;

    public void CompleteQuest(int questIndex)
    {
        if (questIndex == currentQuestIndex)
        {
            currentQuestIndex++;
            Debug.Log($"Küldetés {questIndex} teljesítve! Következő küldetés: {currentQuestIndex}");
        }
    }

    public bool CanCompleteQuest(int questIndex)
    {
        return questIndex == currentQuestIndex;
    }
}
