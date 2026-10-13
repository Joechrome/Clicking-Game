using System;
using UnityEngine;

public class clickable_behaviour : MonoBehaviour
{
    [SerializeField]
    private Boolean isTiming;
    private int timer;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D clicked = Physics2D.Raycast(mousePos, Vector2.zero);
            if (clicked.collider != null)
            {
                Debug.Log("clicked");
                isTiming = true;
                timer = 0;
                transform.localScale = new Vector2(0.9f, 0.9f);
            }
        }
        if (isTiming)
        {
            timer += 1;
        }
        if (timer >= 15)
        {
            timer = 0;
            isTiming = false;
            transform.localScale = new Vector2(1f, 1f);
        }
    }
}