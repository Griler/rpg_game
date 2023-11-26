using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayAnimation : MonoBehaviour
{
    public string stateName;
    private Rigidbody2D _rigidbody2D;
    public Transform posA;
    public Transform posB;
    private Vector2 targetPos;
    private float speed = 2;

    public void Start()
    {
        targetPos = posA.position;
        Debug.Log(targetPos);
    }

    private void Update()
    {
        if (Vector2.Distance(transform.position, posA.position) < 0.01)
        {
            targetPos = posB.position;
        }

        if (Vector2.Distance(transform.position, posB.position) < 0.01)
        {
            targetPos = posA.position;
        }

        transform.position = Vector2.MoveTowards(transform.position,
            targetPos, speed * Time.deltaTime);
    }

    private void OnCollisionStay2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            other.transform.SetParent(this.transform);
            Debug.Log("fdsdsd");
        }
    }    private void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            other.transform.SetParent(null);
            Debug.Log("fdsdsd");
        }
    }
}