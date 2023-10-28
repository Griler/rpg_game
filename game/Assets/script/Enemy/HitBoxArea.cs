using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using Debug = UnityEngine.Debug;

public class HitBoxArea : MonoBehaviour
{
    public List<Collider2D> targets = new List<Collider2D>();
    private Collider2D _collider2D;

    // Start is called before the first frame update
    void Start()
    {
        _collider2D = GetComponent<Collider2D>();
    }

    // Update is called once per frame
    void Update()
    {
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            targets.Add(other);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            targets.Remove(other);
        }
    }
}