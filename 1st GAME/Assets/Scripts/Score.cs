using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{

    public int score;
    public Text points;

    // Update is called once per frame
    void Update()
    {
        points.text = "Score: " + score.ToString();
    }
}
