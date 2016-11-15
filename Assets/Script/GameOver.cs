using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour {

    private GUIStyle style;
    private Vector2 center;

    void Awake()
    {
        style = new GUIStyle();
        style.fontSize = 40;
    }

    void Start()
    {
        center = new Vector2(Screen.width / 2, Screen.height / 2);
    }

    void OnGUI()
    {
        float posY = center.y - 50;
        GUI.Label(new Rect(center.x - 50, posY, 100, 20), "GAME OVER", style);
        posY += 50;
        GUI.Label(new Rect(center.x - 50, posY, 100, 20), "Score:" + PlayerPrefs.GetInt("SCORE"), style);
        posY += 50;
        bool btnContinue = GUI.Button(new Rect(center.x - 50, posY, 100, 30),"Continue");
        if(btnContinue)
        {
            SceneManager.LoadScene("main");
        }
    }
}
