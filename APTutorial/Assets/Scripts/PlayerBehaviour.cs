using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaviour : MonoBehaviour
{

    public Animator animator;
    public Transform attackPoint;
    public float attackRange = 0.5f;
    public LayerMask enemyLayers;

    private float horizontal;
    private float speed = 8f;
    public float jumpingPower = 16f;
    private bool doublejump;
    private bool hasMeleeAttacked = false;

    private bool isFacingRight = true;

    private bool isWallSliding;
    private float wallSlidingSpeed = 2f;

    private bool isWallJumping = false;
    private float wallJumpingDirection;
    private float wallJumpingTime = 0.2f;
    private float wallJumpingCounter = 0;
    private float wallJumpingDuration = 0.4f;
    private Vector2 wallJumpingPower = new Vector2(8f, 16f);
    public  bool check = false;
    private bool knockLeft = false;
    public float knockback;
    private float knockBackTime;

    Collider2D currentWall = null;
    Collider2D lastWall = null;


    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private Transform wallCheck;
    [SerializeField] private LayerMask wallLayer;
    private ComboCount comboGet;
    private GameObject get;
    private Healthbar health;
    private LavaRise lava;
    // Start is called before the first frame update
    void Start()
    {
        GameObject l = GameObject.FindGameObjectWithTag("Lava");
        lava = l.GetComponent<LavaRise>();
        rb = GetComponent<Rigidbody2D>();
        comboGet = GetComponent<ComboCount>();
        get = GameObject.FindGameObjectWithTag("HealthBar");
        health = get.GetComponent<Healthbar>();
    }

  
    private bool isGrounded()
    {
        return Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);
    }


    // Update is called once per frame
    void Update()
    {
        if (check)
        {
            comboGet.comboNum += 1;
            check = false;
        }
        if (knockBackTime <= 0)
        {

            horizontal = Input.GetAxisRaw("Horizontal");
            animator.SetFloat("speed", horizontal);

            if (horizontal < 0)
            {
                animator.SetBool("is running", true);

                transform.localScale = new Vector3(-2, 2, 2);
            }
            else if (horizontal > 0)
            {
                animator.SetBool("is running", true);

                transform.localScale = new Vector3(2, 2, 2);
            }
            else if (horizontal == 0)
            {
                animator.SetBool("is running", false);

            }


            WallSlide();
            WallJump();


            if (Input.GetKeyDown(KeyCode.Space) && isGrounded())
            {
                doublejump = true;
                rb.velocity = new Vector2(rb.velocity.x, jumpingPower);
            }

            if (Input.GetKeyDown(KeyCode.Space) && !isGrounded() && doublejump)
            {
                doublejump = false;
                rb.velocity = new Vector2(rb.velocity.x, jumpingPower);

            }

            if (Input.GetButtonUp("Jump") && rb.velocity.y > 0f)
            {
                rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * 0.5f);
            }

            if (isGrounded() == true)
            {
                animator.SetBool("isjumping", false);
                currentWall = null;
            }
            else if (isGrounded() == false)
            {
                animator.SetBool("isjumping", true);

            }


            if (Input.GetKeyDown(KeyCode.X) && !hasMeleeAttacked)
            {
                // Trigger the melee animation
                animator.SetBool("meleeAttack", true);
                hasMeleeAttacked = true;

                // Flip the character if it's facing left      
            }

            // Check if the animation has finished playing
            if (animator.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1f && hasMeleeAttacked)
            {

                animator.SetBool("meleeAttack", false);
                hasMeleeAttacked = false;

                // Flip the character back to its original direction
                if (isFacingRight)
                {
                    transform.localScale = new Vector3(2, 2, 2);
                }
            }
        }

    }



    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "Enemy")
        {
            if (rb.position.y > collision.contacts[0].point.y && !isGrounded())
            {
                comboGet.comboNum += 1;
                int val = PlayerPrefs.GetInt("Kills");
                PlayerPrefs.SetInt("Kills", val + 1);
                PlayerPrefs.Save();
                Destroy(collision.collider.gameObject);
            }
            else if (isGrounded())
            {
                if (rb.position.x < collision.GetContact(0).point.x)
                {
                    
                    knockLeft = true;
                    health.Damage();
                    Debug.Log("Left");

                } else if (rb.position.x > collision.GetContact(0).point.x)
                {
                    
                    knockLeft = false;
                    health.Damage();
                    Debug.Log("Right");
                }
                knockBackTime = 0.3f;
            }
        }

    }

    private bool IsWalled()
    {
        currentWall = Physics2D.OverlapCircle(wallCheck.position, 0.2f, wallLayer);
        if (currentWall != null && !isGrounded())
        {
            
            return true;
            
        }
        lastWall = null;
        return false;
    }

    private void WallSlide()
    {
        if (IsWalled() && !isGrounded())
        {
            isWallSliding = true;
            transform.localScale = new Vector3(-2, 2, 2);
            rb.velocity = new Vector2(rb.velocity.x, Mathf.Clamp(rb.velocity.y, -wallSlidingSpeed, float.MaxValue));

            animator.SetBool("wallSlide", true);
            animator.SetBool("isjumping", false);
            
         
        }
        else
        {
            animator.SetBool("wallSlide", false);
            lastWall = currentWall;

            isWallSliding = false;
        }            
    }

    private void WallJump()
    {
        
        if (wallJumpingCounter < 1 && isWallSliding && Input.GetKeyDown(KeyCode.Space))
        {
            comboGet.comboNum += 1;
            wallJumpingCounter++;
            rb.velocity = new Vector2(rb.velocity.x, 16f);
            isWallSliding = false;
        }

        if (isGrounded() || IsWalled() && currentWall!= lastWall){
            wallJumpingCounter = 0;
        }
    }

    private void StopWallJumping()
    {
        isWallJumping = false;
    }

   
    private void FixedUpdate()
    {
        if (knockBackTime <= 0)
        {
            rb.velocity = new Vector2(horizontal * speed, rb.velocity.y);
            lava.damaged = false;
        } else
        {
            lava.damaged = true;
            float yVal = knockback;
            if (knockBackTime < 0.15)
            {
                yVal = 0f;
            }
            rb.velocity = Vector2.zero;
            if (knockLeft)
            {
                rb.velocity = new Vector2(-knockback, yVal);
            }
            if (!knockLeft)
            {
                rb.velocity = new Vector2(knockback, yVal);
            }
            knockBackTime -= Time.deltaTime;
        }
        
    }
}
