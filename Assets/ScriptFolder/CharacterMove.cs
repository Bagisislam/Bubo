using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterMove : MonoBehaviour
{
    [SerializeField] Rigidbody2D rb;
    [SerializeField] float CharacterMoveSpeed;
    [SerializeField] Transform CheckFeet;
    [SerializeField] LayerMask layerMask;
    public float MaxJump;
    public float Chargejump;
    bool releaseToJumpe;
    bool IsOnTheAir;
    public float JumpeForce;
    [SerializeField] Animator _animator;
    [SerializeField] float FallMultiplir;
    float HorizontelInput;
    bool IsGround;
    bool IsJumping;
    Vector2 VecGravity;
    float JumpeConter;
    float JumpTime;

    // Start is called before the first frame update
    void Start()
    {
        VecGravity = new Vector2(0, -Physics2D.gravity.y);
        rb = GetComponent<Rigidbody2D>();
        _animator = GameObject.Find("Bubo").GetComponent<Animator>();
    }

    void FixedUpdate()
    {

        HorizontelInput = Input.GetAxisRaw("Horizontal");
        _animator.SetBool("IsRuning", false);
        _animator.SetBool("IsReadyToJumpe", false);
        _animator.SetBool("IsJumpe", false);
        if (IsGrounded() && IsJumping == false)
        {
            if (!Input.GetKey(KeyCode.Space))
            {
                if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D))
                {
                    rb.velocity = new Vector2(HorizontelInput * CharacterMoveSpeed, rb.velocity.y);

                }

            }

        }
        if (Chargejump == 0.0f && IsGrounded() && IsOnTheAir == false)
        {
            if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.A) && IsOnTheAir == false && Chargejump == 0.0f)
            {
                _animator.SetBool("IsRuning", true);
            }

        }


        if (HorizontelInput < 0 || HorizontelInput > 0)
        {

            if (HorizontelInput < 0)
            {
                FlipMethod(180);
            }
            if (HorizontelInput > 0)
            {
                FlipMethod(0);
            }
        }

    }
    // Update is called once per frame
    void Update()
    {

        if (IsGrounded() && IsOnTheAir == false)
        {

            if (Chargejump < MaxJump && Input.GetKey(KeyCode.Space))
            {
                Chargejump += Time.deltaTime + 0.018f;
                _animator.SetBool("IsRuning", false);
                _animator.SetBool("IsReadyToJumpe", true);
            }

        }

        if (IsGrounded() && Input.GetKeyUp(KeyCode.Space) && IsOnTheAir == false)
        {

            float xaxis = CharacterMoveSpeed + HorizontelInput;
            float yaxis = JumpeForce;
            rb.velocity = new Vector2(xaxis, yaxis);

            releaseToJumpe = true;
            IsJumping = true;

        }

        if (releaseToJumpe && IsGrounded())
        {
            _animator.SetBool("IsReadyToJumpe", false);
            if (Chargejump > 0.5f)
            {

                rb.velocity = new Vector2(HorizontelInput * CharacterMoveSpeed, JumpeForce * Chargejump);

                releaseToJumpe = false;
                Chargejump = 0;

            }
            else
            {
                rb.velocity = new Vector2(HorizontelInput * CharacterMoveSpeed, JumpeForce);

                releaseToJumpe = false;
                Chargejump = 0;
            }

            IsJumping = false;
            IsOnTheAir = true;

        }
        if (!IsGrounded())
        {
            _animator.SetBool("IsJumpe", true);


        }

        if (rb.velocity.y < 0)
        {
            rb.velocity -= FallMultiplir * VecGravity * Time.deltaTime;
        }
    }
    private void LateUpdate()
    {
        _animator.SetBool("IsJumpe", false);
        if (_animator.GetBool("IsReadyToJumpe") == false && _animator.GetBool("IsRuning") == false && IsOnTheAir == true && !IsGrounded())
        {
            _animator.SetBool("IsJumpe", true);
        }
    }
    void FlipMethod(float y)
    {
        gameObject.transform.eulerAngles = new Vector3(0, y, 0);
    }

    bool IsGrounded()
    {
        return IsGround = Physics2D.OverlapCapsule(CheckFeet.position, new Vector2(0.6139656f, 0.1150617f), CapsuleDirection2D.Horizontal, 0, layerMask);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground" || collision.gameObject.tag == "Platform")
        {
            _animator.SetBool("IsJumpe", false);
            IsOnTheAir = false;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground"  && _animator.GetBool("IsReadyToJumpe") == true)
        {
            IsOnTheAir = true;

        }
    }
}
