using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    private Rigidbody2D _rigidbody2D;
    public float speed = 2.5f;
    private Animator _animator;

    // Start is called before the first frame update
    void Start()
    {
        _rigidbody2D = this.GetComponent<Rigidbody2D>();
        _animator = this.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        moveCharater();
    }

    void moveCharater()
    {
        float horizontalMove = Input.GetAxisRaw("Horizontal");
        _rigidbody2D.velocity = new Vector2(speed * horizontalMove, _rigidbody2D.velocity.y);
        if (horizontalMove == -1)
        {
            this.transform.localScale = new Vector3(-1, 1, 1);
            _animator.SetBool("isRun", true);
        }
        else if (horizontalMove == 1)
        {
            this.transform.localScale = new Vector3(1, 1, 1);
            _animator.SetBool("isRun", true);
        }
        else
        {
            _animator.SetBool("isRun", false);
        }
    }

}
