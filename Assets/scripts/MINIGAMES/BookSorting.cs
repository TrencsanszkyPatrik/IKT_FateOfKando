using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;  
using System.Collections.Generic;

public class BookSorting : MonoBehaviour, IPointerClickHandler  
{
    public TMP_Text scoreText;
    public TMP_Text timerText;
    public TMP_Text winText;
    public AudioSource screamSound;
    public float gameTime = 30f;

    public GameObject normalBookPrefab;
    public GameObject demonBookPrefab;

    private float currentTime;
    private int mistakes = 0;
    private const int MAX_MISTAKES = 5;
    private List<Book> books = new List<Book>();
    private bool isGameActive = true;

    private Book selectedBook = null;

    void Start()
    {
        currentTime = gameTime;
        InitializeBooks();
    }

    void Update()
    {
        if (!isGameActive) return;

        currentTime -= Time.deltaTime;
        timerText.text = $"Idő: {Mathf.Ceil(currentTime)}";

        if (currentTime <= 0 || mistakes >= MAX_MISTAKES)
        {
            GameOver(false);
        }
    }

    void InitializeBooks()
    {
        string[] bookTitles = new string[] 
        {
            "Anatómia", "Démoni kör", "Fizika", "Kémia", "Programozás", "Ne olvass!", 
            "Házifeladat", "Tankönyv", "Miért ne?", "Szabályok", "Túlélő kalauz", 
            "Szünetek", "Verseny", "Alvás", "Szünet"
        };

        List<string> shuffledTitles = new List<string>(bookTitles);
        List<string> selectedBooks = new List<string>();

        for (int i = 0; i < 5; i++)
        {
            int randomIndex = Random.Range(0, shuffledTitles.Count);
            selectedBooks.Add(shuffledTitles[randomIndex]);
            shuffledTitles.RemoveAt(randomIndex);
        }

        int demonCount = 0;

        for (int i = 0; i < selectedBooks.Count; i++)
        {
            bool isDemonic = false;

            if (demonCount < 2 && Random.Range(0, 2) == 0)
            {
                isDemonic = true;
                demonCount++;
            }

            GameObject bookObj = Instantiate(isDemonic ? demonBookPrefab : normalBookPrefab, transform);
            Book book = bookObj.GetComponent<Book>();
            book.Initialize(selectedBooks[i], isDemonic);
            book.OnBookClicked += HandleBookClick;
            books.Add(book);

            RectTransform rect = bookObj.GetComponent<RectTransform>();
            rect.anchoredPosition = new Vector2(i * 300f - (selectedBooks.Count - 1) * 150f, 0);
        }
    }

    void HandleBookClick(Book clickedBook)
    {
        if (!isGameActive) return;
        if (clickedBook.isDemonic)
        {
            mistakes++;
            scoreText.text = $"Hibák: {mistakes}/{MAX_MISTAKES}";
        }
        if (selectedBook == null)
        {
            selectedBook = clickedBook;
            return;
        }

        if (selectedBook != clickedBook)
        {
            SwapBooks(selectedBook, clickedBook);

            bool isCorrectOrder = CheckBookOrder();

            if (isCorrectOrder)
            {
                GameOver(true);
            }
        }

        selectedBook = null;
    }

    void SwapBooks(Book book1, Book book2)
    {
        RectTransform rect1 = book1.GetComponent<RectTransform>();
        RectTransform rect2 = book2.GetComponent<RectTransform>();

        Vector2 tempPosition = rect1.anchoredPosition;
        rect1.anchoredPosition = rect2.anchoredPosition;
        rect2.anchoredPosition = tempPosition;

        int index1 = books.IndexOf(book1);
        int index2 = books.IndexOf(book2);

        books[index1] = book2;
        books[index2] = book1;
    }

    bool CheckBookOrder()
    {
        for (int i = 1; i < books.Count; i++)
        {
            if (string.Compare(books[i - 1].title, books[i].title) > 0)
            {
                return false;
            }
        }
        return true;
    }

    void GameOver(bool won)
    {
        isGameActive = false;
        if (won)
        {
            winText.text = "Siker!";
        }
        else
        {
            winText.text = "Vesztettél!";
        }
    }

    // A kattintásra ujrainditás v tovább
    public void OnPointerClick(PointerEventData eventData)
    {
        if (!isGameActive)
        {
            if (currentTime <= 0 || mistakes >= MAX_MISTAKES)
            {
                RestartGame();
            }
            else
            {
                NextScene();
            }
        }
    }

    void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    void NextScene()
    {
        SceneManager.LoadScene("Jatek2");
    }
}
