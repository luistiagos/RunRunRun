using UnityEngine;
using System.Collections;

public class Score : MonoBehaviour {

    private PlayerController pc;
    private int score;

    void Awake()
    {
       pc = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    void Start()
    {
        score = 0;
    }

    void OnGUI()
    {
      GUIStyle style = new GUIStyle();
      style.fontSize = 30;  
      GUI.TextField(new Rect(10, 10, 200, 40), "Score:" + this.score, style);
    }

    public int GetScore()
    {
        return score;
    }

    public void AddScore(int score)
    {
        this.score += score;
        PlayerPrefs.SetInt("SCORE", this.score);
    }

}
