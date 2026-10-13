using UnityEngine;

public class Score_Noting : MonoBehaviour
{

    public GameObject clickable;
    private clickable_behaviour status;
    private int score;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        status = clickable.GetComponent<clickable_behaviour>();
    }

    // Update is called once per frame
    void Update()
    {
        if (status.isclicked)
        {
            score += 1;
            Debug.Log(score);
        }
    }

    public int getscore()
    {
        return score;
    }
}
