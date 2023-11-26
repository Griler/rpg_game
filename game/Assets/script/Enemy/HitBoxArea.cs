using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using UnityEngine;
using Debug = UnityEngine.Debug;

public class HitBoxArea : MonoBehaviour
{
    public List<Collider2D> targets = new List<Collider2D>();
    private Collider2D _collider2D;

    private Vector3 beforeChangeScale;
    // Start is called before the first frame update
    void Start()
    {
        _collider2D = GetComponent<Collider2D>();
    }

    // Update is called once per frame
    void Update()
    {
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        { 
            if (other.transform.position.x > this.transform.parent.position.x)
            {   
                beforeChangeScale = this.transform.parent.localScale;
                this.transform.parent.localScale = new Vector3(-1f, 1, 1);

            }
            else if (other.transform.position.x < this.transform.parent.position.x)
            {
                beforeChangeScale = this.transform.parent.localScale;
                this.transform.parent.localScale = new Vector3( 1f, 1, 1);

            }

            if (!targets.Any()) 
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