using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour {

    public float speed;
    public float jumpPower;
    public float angle;
    public AudioSource jumpAudioSrc;
    public AudioSource pickItemAudioSrc;
    public GamePad gamePad;

    private Rigidbody rb;
    private float posZ;
    private float posYInitial;
    public bool isGround = true;
    
    private bool hasJumped;
    private float widthRel;

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
        widthRel = (this.transform.localScale.y / (Screen.width) / 2);
    }
	
	// Update is called once per frame
    void Update()
    {
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.up);

        Vector3 viewPos = Camera.main.WorldToViewportPoint(gameObject.transform.position);
      
        if (transform.position.y < -5 || (viewPos.x + 0.2) < widthRel)
        {
            SceneManager.LoadScene("gameover");
        }
        
        if (isGround)
        {
            posZ = ((gamePad.IsRight()) ? -1f:(gamePad.IsLeft()) ? 1f:0);

            if (gamePad.IsJump())
            {
                hasJumped = true;
            }
            
        }
    }
    
    void FixedUpdate()
    {
        if (hasJumped)
        {
            rb.AddForce(transform.up * jumpPower);
            jumpAudioSrc.Play();
            hasJumped = false;
        }
       
        rb.MovePosition(new Vector3(rb.position.x + speed * Time.deltaTime,
        rb.position.y, rb.position.z + posZ * speed * Time.deltaTime));
        
    }
    
    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            posYInitial = transform.position.y;
            isGround = true;
        }
    }

    public void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            posYInitial = transform.position.y;
            isGround = true;
        }
    }

    public void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            posYInitial = transform.position.y;
            isGround = false;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Diamond")
        {
            pickItemAudioSrc.Play();
        }
    }

    public float GetSpeed()
    {
        return speed;
    }
}
