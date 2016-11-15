using UnityEngine;
using System.Collections;

public class Controller : MonoBehaviour {

    private CharacterController controller;

    void Awake()
    {
        controller = GetComponent<CharacterController>();
    }

	// Use this for initialization
	void Start () {
	    
	}
	
	// Update is called once per frame
	void Update () {
        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");

        float widthRel = this.transform.localScale.y / (Screen.width) / 2; //relative width
        float heightRel = this.transform.localScale.x / (Screen.height) / 2; //relative height

        Vector3 viewPos = Camera.main.WorldToViewportPoint(this.transform.position);
        viewPos.x = Mathf.Clamp(viewPos.x, widthRel, 1 - widthRel);
        viewPos.y = Mathf.Clamp(viewPos.y, heightRel, 1 - heightRel);
        this.transform.position = Camera.main.ViewportToWorldPoint(viewPos);

        controller.Move(new Vector3(x,y) * Time.deltaTime);

    }
}
