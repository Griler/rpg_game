using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DashPlayer : MonoBehaviour
{
    public float dashDistance = 5f; // Khoảng cách di chuyển khi dash
    public float dashTime = 0.5f; // Thời gian di chuyển trong dash
    private bool isDashing = false;
    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift) && !isDashing)
        {
            Dash();
        }
    }

    void Dash()
    {
        isDashing = true;
        Vector2 dashDirection = new Vector2(transform.forward.x, transform.forward.y).normalized;
        Vector2 dashEndPosition = rb.position + dashDirection * dashDistance;
        StartCoroutine(PerformDash(dashEndPosition));
    }

    System.Collections.IEnumerator PerformDash(Vector2 endPosition)
    {
        float startTime = Time.time;
        float elapsedTime = 0f;

        while (elapsedTime < dashTime)
        {
            rb.MovePosition(Vector2.Lerp(rb.position, endPosition, elapsedTime / dashTime));
            elapsedTime = Time.time - startTime;
            yield return null;
        }

        isDashing = false;
    }
}