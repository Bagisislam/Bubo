using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JoystickCharacterMove : MonoBehaviour,Hello
{
    [SerializeField] Rigidbody2D rb;
    [SerializeField] float CharacterMoveSpeed;
    [SerializeField] Transform CheckFeet;
    [SerializeField] LayerMask layerMask;
    public float JoystickMaxJump;
    public float JoysickChargejump;
    bool releaseToJumpe;
    public bool IsOnTheAir;
    public float JoyStickJumpeForce;
    public Animator _animator;
    [SerializeField] float FallMultiplir;
    float HorizontelInput;
    [SerializeField] Joystick _Joystick;
    bool IsGround;
    bool IsJumping;
    Vector2 VecGravity;
    float JumpeConter;
    float JumpTime;
    JoyStickPlayerJumpScript _joyStickPlayerJumpScript;
    // Start is called before the first frame update
    void Start()
    {
        _joyStickPlayerJumpScript = GetComponent<JoyStickPlayerJumpScript>();
        rb = GameObject.Find("Bubo").GetComponent<Rigidbody2D>();
        VecGravity = new Vector2(0, -Physics2D.gravity.y);

        _animator = GameObject.Find("Bubo").GetComponent<Animator>();
    }

    void FixedUpdate()
    {

        HorizontelInput = _Joystick.Horizontal;
        _animator.SetBool("IsRuning", false);
        if (IsGrounded() && IsJumping == false && JoysickChargejump == 0.0f)
        {
            if (_Joystick.Horizontal >= .2f)
            {

                rb.velocity = new Vector2(HorizontelInput * CharacterMoveSpeed, rb.velocity.y);
                _animator.SetBool("IsRuning", true);

            }
            else if (_Joystick.Horizontal <= -.2f)
            {
                rb.velocity = new Vector2(HorizontelInput * CharacterMoveSpeed, rb.velocity.y);
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

        if (rb.velocity.y < 0)
        {
            rb.velocity -= FallMultiplir * VecGravity * Time.deltaTime;
        }

    }

    public void JumpKeyup()
    {

        if (IsGrounded() && IsOnTheAir == false)
        {

            float xaxis = CharacterMoveSpeed + HorizontelInput;
            float yaxis = JoyStickJumpeForce;
            rb.velocity = new Vector2(xaxis, yaxis);

            releaseToJumpe = true;
            IsJumping = true;

        }
        if (releaseToJumpe && IsGrounded())
        {
            _animator.SetBool("IsReadyToJumpe", false);
            if (JoysickChargejump > 0.5f)
            {

                rb.velocity = new Vector2(HorizontelInput * CharacterMoveSpeed, JoyStickJumpeForce * JoysickChargejump);

                releaseToJumpe = false;
                JoysickChargejump = 0;

            }
            else
            {
                rb.velocity = new Vector2(HorizontelInput * CharacterMoveSpeed, JoyStickJumpeForce);

                releaseToJumpe = false;
                JoysickChargejump = 0;
            }

            IsJumping = false;
            IsOnTheAir = true;

        }
        
    }

    public void jumpBtnGetDown()
    {

        if (IsGrounded() && IsOnTheAir == false)
        {

            if (JoysickChargejump < JoystickMaxJump)
            {
                JoysickChargejump += Time.deltaTime + 0.03f;
                _animator.SetBool("IsRuning", false);
                _animator.SetBool("IsReadyToJumpe", true);
            }

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

    public bool IsGrounded()
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
        if (collision.gameObject.tag == "Ground" && _animator.GetBool("IsReadyToJumpe") == true)
        {
            IsOnTheAir = true;
        }
    }
}
