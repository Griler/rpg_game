using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpController : MonoBehaviour
{
    [SerializeField] private float jumpPower;
    [SerializeField] private LayerMask groundLayer;
    private Animator _animator;
    private Rigidbody2D _rigidbody2D;

    private int jumpCounter = 1;
    public float fallScale;
    private static readonly int IsJump = Animator.StringToHash("isJump");
    private static readonly int YVelocity = Animator.StringToHash("yVelocity");

    public float castDistane;
    public Vector2 boxSize;

    // Start is called before the first frame update
    void Start()
    {
        _animator = GetComponent<Animator>();
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
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
            Debug.Log("nhay lần 1 + "+ jumpCounter);
        }
        else if (Input.GetKeyDown(KeyCode.Space) && _rigidbody2D.velocity.y < 0 && jumpCounter == 1)
        {
            _rigidbody2D.velocity = new Vector2(_rigidbody2D.velocity.x, jumpPower * 1.2f);
            jumpCounter--;
            Debug.Log("nhay lần 2 + "+ jumpCounter);

        }
    }

    void Fall()
    {
        if (_rigidbody2D.velocity.y < 0)
        {
            _rigidbody2D.AddForce(Physics2D.gravity*_rigidbody2D.mass*fallScale);
        }
        if (isGround() && _rigidbody2D.velocity.y == 0)
        {
            Debug.Log("rơi chạm đất");
            _animator.SetBool(IsJump, false);
            jumpCounter = 1;
        }
    }

    bool isGround()
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

    /*private void OnDrawGizmos()
    {
        Gizmos.DrawCube(transform.position - transform.up * castDistane, boxSize);
    }*/
}