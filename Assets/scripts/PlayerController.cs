using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    int playerHealth = 3;
    float playerSpeed = 5.5f;
    public float jumpForce = 10f;
    string texto = "Hello World";
    public Transform initialPoint;
    public SpriteRenderer spriteRenderer;
    private Rigidbody2D rBody;
    public GroundSensor sensor;

    public Animator anim;
    float horizontal;
    float vertical;
    GameManager gameManager;
    SFXManager sfxManager;

    // Start is called before the first frame update
    void Start()
    {
        transform.position = initialPoint.position;
        spriteRenderer= GetComponent<SpriteRenderer>();  
        rBody = GetComponent<Rigidbody2D>();
        sensor = GameObject.Find("GroundSensor").GetComponent<GroundSensor>();
        anim = GetComponent<Animator>();
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        sfxManager = GameObject.Find("SFXManager").GetComponent<SFXManager>();

        playerHealth = 10;
        Debug.Log(texto);
    }

    // Update is called once per frame
    void Update()
    {
        if(gameManager.isGameOver == false)
        {
                    horizontal = Input.GetAxis("Horizontal");
            vertical = Input.GetAxis("Vertical");

            transform.position += new Vector3(horizontal, vertical, 0) * playerSpeed * Time.deltaTime;

            if(horizontal < 0) 
            {
                spriteRenderer.flipX = true;
                anim.SetBool("IsRunning", true);
            }
            else if(horizontal > 0)
            {
                spriteRenderer.flipX = false;
                anim.SetBool("IsRunning", true);
            }
            else 
            {
                anim.SetBool("IsRunning", false);
            }

            if(Input.GetButtonDown("Jump") && sensor.isGrounded)
            {
                rBody.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
                anim.SetBool("IsJumping", true);
            }
        }
   
    }

    void FixedUpdate()
    {
        rBody.velocity = new Vector2(horizontal * playerSpeed, rBody.velocity.y);
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.gameObject.tag == "coin")
        {
            gameManager.AddCoin();
            sfxManager.CoinSound();
            Destroy(collider.gameObject);
        }
    }
}
