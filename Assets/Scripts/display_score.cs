using UnityEngine;
using TMPro;

public class display_score : MonoBehaviour
{
    public GameObject Scoreboard;
    private Score_Noting current_score;
    private TMP_Text content;
    private string label = "Score: ";
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        current_score = Scoreboard.GetComponent<Score_Noting>();
        content = GetComponent<TMP_Text>();
    }

    // Update is called once per frame
    void Update()
    {
        show();
    }

    void show()
    {
        string temp = current_score.getscore().ToString();
        string composite = (label + temp);
        content.text = composite;
    }
}
