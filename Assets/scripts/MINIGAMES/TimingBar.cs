using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

namespace jatek
{
    public class TimingBar : MonoBehaviour
    {
        public RectTransform cursor; // A mozgó jelző.
        public RectTransform greenZone; // A zöld célterület.
        public float speed = 100f; // Mozgási sebesség.
        private bool movingRight = true;

        public GameObject dohany;
        public Image targetImage;
        public Sprite[] sprites;
        private int spriteChangeCount = 0;
        bool IsRolled = false;

        public bool isRolled()
        {
            return IsRolled;
        }

        void Update()
        {
            if (movingRight)
            {
                cursor.localPosition += Vector3.right * speed * Time.deltaTime;
                if (cursor.localPosition.x >= 40) movingRight = false;
            }
            else
            {
                cursor.localPosition += Vector3.left * speed * Time.deltaTime;
                if (cursor.localPosition.x <= -40) movingRight = true;
            }

            if (Input.GetKeyDown(KeyCode.Space))
            {
                if (RectTransformUtility.RectangleContainsScreenPoint(greenZone, cursor.position))
                {
                    Debug.Log("Sikeres találat!");

                    if (spriteChangeCount < 3)
                    {
                        ChangeSprite();
                    }
                    else
                    {
                        ChangeSprite();
                        IsRolled = true;
                        this.gameObject.SetActive(false);
                    }


                    if (spriteChangeCount == 2)
                    {
                        dohany.gameObject.SetActive(false);
                    }

                }
                else
                {
                    Debug.Log("Nem sikerült!");
                }
            }
        }

        void ChangeSprite()
        {
            if (sprites.Length > 0)
            {
                targetImage.sprite = sprites[spriteChangeCount];
                spriteChangeCount++;
            }
        }
    }
}