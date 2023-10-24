using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
        targets.Add(other);
    } private void OnTriggerExit2D(Collider2D other)
    {
        targets.Remove(other);
    }
}
