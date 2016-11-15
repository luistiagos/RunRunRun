using UnityEngine;
using System.Collections;

public class Diamond : MonoBehaviour {

    public AudioSource pickItem;
    public Score score;

	// Update is called once per frame
	void FixedUpdate () {
        transform.Rotate(Vector3.forward, 0.45f);
	}

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            pickItem.Play();
            score.AddScore(100);
        }
        Destroy(this.gameObject);
    }
}
