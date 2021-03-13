using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Threading;

[RequireComponent(typeof(Image))]
public class Player : MonoBehaviour
{
    public float        moveSpeed  = 10;
    public float        jumpHeight = 10;

    public Transform    groundCheck;//określa liczbę gracza od
    public float        groundCheckRadius;//jeśli będzie większa od tego
    public LayerMask    whatIsGround;//okreslonej warstwy
    public static bool  grounded;//to będzie fałszem???
    public bool         doubleJump;
    public bool         reallyJump;

    public Sprite       jumpingBunny;
    public Sprite       walkingRightBunny;
    public Sprite       standingRightBunny;
    public Sprite       standingBunny;
    public Sprite       readyToJumpBunny;

    private bool isRight = false;


    // Start is called before the first frame update
    void Start()
    {
        //anim = GetComponent<Animator>();
    }

    private void FixedUpdate()
    {
        grounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, whatIsGround);//nasza pozycja, maksymalna odległość, pozycja popdłoża

    }

    // Update is called once per frame
    void Update()
    {

        ///stanie
   
            if (grounded && !reallyJump)
            {
                doubleJump = false;
                if (isRight)
                {
                    this.gameObject.GetComponent<SpriteRenderer>().sprite = standingRightBunny;
                    //this.gameObject.transform.position.y = GetComponent<Rigidbody2D>().velocity.y;
                }
                else
                {
                    this.gameObject.GetComponent<SpriteRenderer>().sprite = standingBunny;
                }
            }
            else if (grounded && reallyJump)
            {
                Thread.Sleep(80);
                reallyJump = false;
            }

 
          
            ///skok
            if (Input.GetKeyDown(KeyCode.UpArrow) && grounded && !doubleJump)
            {
                this.jump();
            }

            if (Input.GetKeyDown(KeyCode.UpArrow) && !grounded && !doubleJump)
            {
                this.jump();
                doubleJump = true;
            }

            ///chodzenie
            if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                GetComponent<Rigidbody2D>().velocity = new Vector2(-moveSpeed, GetComponent<Rigidbody2D>().velocity.y);
                this.gameObject.GetComponent<SpriteRenderer>().sprite = walkingRightBunny;
                isRight = true;

            }
        

        ///chodzenie

        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(moveSpeed, GetComponent<Rigidbody2D>().velocity.y);
            this.gameObject.GetComponent<SpriteRenderer>().sprite = walkingRightBunny;
            isRight = true;

        }

       /* */

    }

    void jump()
    {
        reallyJump = true;
        isRight = false;

        this.gameObject.GetComponent<SpriteRenderer>().sprite = jumpingBunny;
        GetComponent<Rigidbody2D>().velocity = new Vector2(0, jumpHeight);
        
    }
}
