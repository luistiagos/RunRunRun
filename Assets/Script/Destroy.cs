using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Destroy : MonoBehaviour {

    private float widthRel;

    // Use this for initialization
    void Awake() {
        widthRel = (this.transform.localScale.y / (Screen.width) / 2);
    }
	
	// Update is called once per frame
	void Update () {

        Vector3 viewPos = Camera.main.WorldToViewportPoint(this.transform.position);

        if(((viewPos.x + 0.3) < widthRel) || transform.position.y < -5)
        {
            if (this.gameObject.tag == "Player")
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
            else
            {
                Destroy(this.gameObject);
            }
            
        }
    }
}
