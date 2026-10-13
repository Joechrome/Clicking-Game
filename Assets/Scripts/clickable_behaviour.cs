using System;
using UnityEngine;

public class clickable_behaviour : MonoBehaviour
{
    [SerializeField]
    private Boolean isTiming;
    private int timer;
    public Boolean IsClicking = false;

    public Boolean isclicked;
    private SoundEffect _clickSound;

    void Start()
    {
        _clickSound = GetComponent<SoundEffect>();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D clicked = Physics2D.Raycast(mousePos, Vector2.zero);
            if (clicked.collider != null)
            {
                isclicked = true;

                Debug.Log("clicked");
                isTiming = true;
                timer = 0;
                IsClicking = true;
                transform.localScale = new Vector2(0.9f, 0.9f);

                if (_clickSound != null)
                {
                    _clickSound.Play();
                }
            }
        }
        else{

            isclicked = false;

        }

        if (isTiming)
        {
            timer += 1;
        }
        if (timer >= 15)
        {
            timer = 0;
            isTiming = false;

            IsClicking = false;
            transform.localScale = new Vector2(1f, 1f);
        }
    }
}
