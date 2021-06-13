using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Threading.Tasks;
using UnityEngine.SceneManagement;

public class mobile : MonoBehaviour
{
    [SerializeField]
    private GameObject player;
    [SerializeField]
    public float movespeed;
    public float jumpForce;
    private float moveInput;

    private Animator myAnim;

    private Rigidbody2D rb;


    private bool isGrounded;
    public Transform groundCheck;
    public float checkRadius;
    public LayerMask whatIsGround;

    public int extraJumps;
    public int extraJumpsValue;
    public static bool jumpTF = false;
    public static bool mobileTF = false;
    // Start is called before the first frame update
    void Start()
    {
        extraJumps = extraJumpsValue;
        rb = GetComponent<Rigidbody2D>();
        myAnim = GetComponent<Animator>(); 
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (mobileTF == false)
        {

            isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, whatIsGround);
            moveInput = Input.GetAxis("Horizontal");
            Vector2 playerVel = new Vector2(moveInput * movespeed, rb.velocity.y);
            rb.velocity = playerVel;
            bool PlayerHasXAxisSpeed = Mathf.Abs(rb.velocity.x) > Mathf.Epsilon;
            myAnim.SetBool("Run", PlayerHasXAxisSpeed);
            rb.velocity = new Vector2(moveInput * movespeed, rb.velocity.y);
            Flip();
        }
        else if (mobileTF == true)
        {
            rb.velocity = new Vector2(0, 0);
            myAnim.SetBool("Run", false);
        }
       
    }

    void Update()
    {
        jump();
        SwitchAnimation();
    }

    void jump()
    {
        if (isGrounded == true)
        {
            extraJumps = 0;
        }

        if (Input.GetKeyDown(KeyCode.Space) && extraJumps > 0 && jumpTF == false)
        {
           myAnim.SetBool("jump", true);
           rb.velocity = Vector2.up * jumpForce;
           extraJumps--;
        }
        else if (Input.GetKeyDown(KeyCode.Space) && extraJumps == 0 && isGrounded == true && jumpTF == false)
        {
           myAnim.SetBool("jump", true);
           rb.velocity = Vector2.up * jumpForce;
        }
    }
    void SwitchAnimation()
    {
        myAnim.SetBool("Idle", false);
        if (isGrounded)
        {
            myAnim.SetBool("jump", false);
        }

    }

    void Flip()
    {
        bool playerHasXAxisSpeed = Mathf.Abs(rb.velocity.x) > Mathf.Epsilon;
        if (playerHasXAxisSpeed && mobileTF == false)
        {
            if (rb.velocity.x > 0.1f)
            {
                transform.localRotation = Quaternion.Euler(0, 0, 0);
            }
            if (rb.velocity.x < -0.1f)
            {
                transform.localRotation = Quaternion.Euler(0, 180, 0);
            }
        }
    }
}
