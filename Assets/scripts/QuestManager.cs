using TMPro;
using UnityEngine;
using System.Collections.Generic;

public class QuestManager : MonoBehaviour
{
    public int currentQuestIndex = 0;
    public TMP_Text text;  // Szöveg referenciája

    private List<string> questtexts = new List<string>
    {
        "Szívj el egy dohányterméket mielőtt bemész.",
        "Vedd fel az elemlámpát az asztalról",
        "Küldetés 3 szövege", // Példa, hogy bővíthető legyen
    };

    private static bool isQuestManagerCreated = false;

    void Start()
    {
        // Csak akkor hozzuk létre a QuestManagert, ha még nem létezett
        if (!isQuestManagerCreated)
        {
            DontDestroyOnLoad(gameObject);  // Megőrzi a QuestManagert a jelenetváltások között
            isQuestManagerCreated = true;
        }
        else
        {
            // Ha már létezik a QuestManager (visszatértünk egy másik jelenetből),
            // akkor nem szükséges újra inicializálni, nem állítjuk vissza a questet.
            return;
        }

        // Ha a TMP_Text referencia nem lett beállítva az Inspectorban, próbáljuk meg automatikusan megtalálni
        if (text == null)
        {
            text = GameObject.Find("QuestText_Feladat").GetComponent<TMP_Text>(); // Itt "QuestText" az a GameObject neve, amelyen a TMP_Text található
        }

        // Ha még mindig nincs referencia, jelezzük
        if (text == null)
        {
            Debug.LogError("TMP_Text referencia nem található a jelenetben!");
        }

        // A szöveget frissítjük a kezdeti állapotra
        UpdateQuestText();
    }

    // Küldetés szövegének frissítése
    void UpdateQuestText()
    {
        if (questtexts.Count > 0 && currentQuestIndex < questtexts.Count)
        {
            text.text = questtexts[currentQuestIndex];  // Frissítjük a szöveget a megfelelő küldetés szöveggel
        }
        else
        {
            text.text = "Nincs több küldetés!"; // Ha nincs több küldetés
        }
    }

    // A küldetés teljesítése
    public void CompleteQuest(int questIndex)
    {
        if (questIndex == currentQuestIndex)
        {
            currentQuestIndex++;  // Következő küldetés
            UpdateQuestText();  // Szöveg frissítése
        }
    }

    // Ha új játékot indítunk, akkor a küldetéseket alaphelyzetbe állítjuk
    public void ResetQuest()
    {
        currentQuestIndex = 0;  // Visszaállítjuk az alapértelmezett állapotba
        UpdateQuestText();  // Frissítjük a szöveget
    }

    // Ellenőrzi, hogy a küldetés teljesíthető-e
    public bool CanCompleteQuest(int questIndex)
    {
        return questIndex == currentQuestIndex;
    }
}
