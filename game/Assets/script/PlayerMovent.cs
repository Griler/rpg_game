using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    private Rigidbody2D _rigidbody2D;
    public float speed = 5;
    private Animator _animator;
    private static readonly int IsRun = Animator.StringToHash("isRun");

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
        Debug.Log(_rigidbody2D.velocity);
    }

    void moveCharater()
    {
        float horizontalMove = Input.GetAxisRaw("Horizontal");
        _rigidbody2D.velocity = new Vector2(speed * horizontalMove, _rigidbody2D.velocity.y);
        if (horizontalMove == -1)
        {
            this.transform.localScale = new Vector3(-1, 1, 1);
            _animator.SetFloat(IsRun, Mathf.Abs(horizontalMove));
        }
        else if (horizontalMove == 1)
        {
            this.transform.localScale = new Vector3(1, 1, 1);
            _animator.SetFloat(IsRun, Mathf.Abs(horizontalMove));
        }
        else
        {
            _animator.SetFloat(IsRun, Mathf.Abs(horizontalMove));
        }
    }

}
