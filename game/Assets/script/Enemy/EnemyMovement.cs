using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    private Rigidbody2D _rigidbody2D;
    private Animator _animator;
    private bool lockVelocity;

    private float speed;

    // Start is called before the first frame update
    void Start()
    {
        speed = GetComponent<EnemyManager>().enemy_Template.speed;
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void Move(float direction = 1)
    {
        lockVelocity = _animator.GetBool("lockVelocity");
        if (lockVelocity == false)
        {
            _rigidbody2D.velocity = new Vector2(direction * speed, _rigidbody2D.velocity.y);
        }
        else
        {
            _rigidbody2D.velocity = new Vector2(0 * speed, _rigidbody2D.velocity.y);
        }
    }
}