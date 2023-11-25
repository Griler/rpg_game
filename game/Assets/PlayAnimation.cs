using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class FlyGround:MonoBehaviour
{
    public Animator _animator  ;
    public virtual void Awake( ){}
}
public class PlayAnimation : FlyGround
{
    public string stateName;
    private Rigidbody2D _rigidbody2D;
    public override void Awake()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
        _animator.Play(stateName);
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("chạm");
            other.gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(other.rigidbody.velocity.x,
                this._rigidbody2D.velocity.y);
        }
    }
}
