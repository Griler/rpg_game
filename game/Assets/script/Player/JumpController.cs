using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpController : MonoBehaviour
{
    [SerializeField] private float jumpPower = 5;
    [SerializeField] private float jumpPowerScaleTwo = 2;
    [SerializeField] private LayerMask groundLayer;
    private Animator _animator;
    private Rigidbody2D _rigidbody2D;

    private int jumpCounter = 1;
    
    public float fallScaleOne = 1.5f;
    public float fallScaleTwo = 5f;
    private static readonly int IsJump = Animator.StringToHash("isJump");
    private static readonly int YVelocity = Animator.StringToHash("yVelocity");

    public float castDistane = 0.25f;
    public Vector2 boxSize = new Vector2(0.3f,0.1f);

    // Start is called before the first frame update
    void Start()
    {
        _animator = GetComponent<Animator>();
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Jump();
        Fall();
        _animator.SetFloat(YVelocity, _rigidbody2D.velocity.y);
    }

    void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && jumpCounter > 0 && isGround())
        {
            // gán true để thực hiện animation nhảy
            _animator.SetBool(IsJump, true);
            // di chuuyen gameObject
            _rigidbody2D.velocity = new Vector2(_rigidbody2D.velocity.x, jumpPower);
        }
        else if (Input.GetKeyDown(KeyCode.Space) && _rigidbody2D.velocity.y < 0 && jumpCounter == 1)
        {
            _rigidbody2D.velocity = new Vector2(_rigidbody2D.velocity.x, jumpPower * jumpPowerScaleTwo);
            jumpCounter--;
        }
    }

    void Fall()
    {
        if (_rigidbody2D.velocity.y < 0 && !isGround() || !isGround())
        {
            _rigidbody2D.velocity += Vector2.up * Physics2D.gravity.y * fallScaleOne*Time.deltaTime;
        }

        if (_rigidbody2D.velocity.y < 0 && jumpCounter == 0)
        {
            _rigidbody2D.velocity += Vector2.up * Physics2D.gravity.y * fallScaleTwo * Time.deltaTime;
        }

        if (isGround() && _rigidbody2D.velocity.y == 0)
        {
            _animator.SetBool(IsJump, false);
            jumpCounter = 1;
        }
    }

    public bool isGround()
    {
        if (Physics2D.BoxCast(transform.position, boxSize, 0, -transform.up,
                castDistane, groundLayer))
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}