using UnityEngine;

public class Book : MonoBehaviour
{
    public string title;
    public bool isDemonic;
    public System.Action<Book> OnBookClicked; 

    private bool isSelected = false; 
    private SpriteRenderer spriteRenderer;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public void Initialize(string bookTitle, bool demonic)
    {
        title = bookTitle;
        isDemonic = demonic;
        GetComponentInChildren<TMPro.TMP_Text>().text = bookTitle;
    }

    public void OnClick()
    {
        OnBookClicked?.Invoke(this); 
    }

    public void SetSelected(bool selected)
    {
        isSelected = selected;
        if (spriteRenderer != null)
        {
            spriteRenderer.color = selected ? Color.green : Color.white; 
        }
    }
}
