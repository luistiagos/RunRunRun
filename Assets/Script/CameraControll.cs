using UnityEngine;
using System.Collections;

public class CameraControll : MonoBehaviour {

    private float velocity;

    void Awake()
    {
        velocity = GameObject.Find("Player").GetComponent<PlayerController>().GetSpeed();
    }

    // Use this for initialization
    void Start () {

    }
	
	// Update is called once per frame
	void FixedUpdate () {

        transform.position += Vector3.right * velocity * Time.deltaTime;

    }
}
