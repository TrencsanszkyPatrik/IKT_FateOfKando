using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement; // Fontos, hogy beimportáld a SceneManagement-et
using System.Collections.Generic;

public class QuestManager : MonoBehaviour
{
    public int currentQuestIndex = 0;
    public TMP_Text text;

    private List<string> questtexts = new List<string>
    {
        "Szívj el egy dohányterméket mielőtt bemész.",
        "Vedd fel az elemlámpát az asztalról",
        "Küldetés 3 szövege", // Példa, hogy bővíthető legyen
    };

    void Start()
    {
        // Az összes gyökérobjektum lekérése az aktív jelenetből
        if (FindObjectsOfType<QuestManager>().Length > 1)
        {
            Destroy(gameObject); // Ha van másik QuestManager, akkor eltávolítjuk ezt az objektumot
        }
        else
        {
            DontDestroyOnLoad(gameObject); // Megakadályozza, hogy elpusztuljon váltáskor
        }

        // Az első küldetés szövege megjelenítése
        UpdateQuestText();
    }

    void UpdateQuestText()
    {
        if (questtexts.Count > 0 && currentQuestIndex < questtexts.Count)
        {
            text.text = questtexts[currentQuestIndex];
        }
    }

    // A küldetés teljesítése
    public void CompleteQuest(int questIndex)
    {
        if (questIndex == currentQuestIndex)
        {
            currentQuestIndex++; // Következő küldetés
            Debug.Log($"Küldetés {questIndex} teljesítve! Következő küldetés: {currentQuestIndex}");
            UpdateQuestText();
        }
    }

    // Ellenőrzi, hogy a küldetés teljesíthető-e
    public bool CanCompleteQuest(int questIndex)
    {
        return questIndex == currentQuestIndex;
    }
}
