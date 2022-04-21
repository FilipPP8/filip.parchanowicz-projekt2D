using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scroller : MonoBehaviour
{
private BoxCollider2D _boxCollider;
private Rigidbody2D _rb;

private float _width;

[SerializeField] private float _speed;
   void Start()
    {
        _boxCollider = GetComponent<BoxCollider2D>();
        _rb = GetComponent<Rigidbody2D>();
        _width = _boxCollider.size.x;
        _rb.velocity = new Vector2(_speed, 0);
    }

    void Update()
    {
        if (transform.position.x < -_width)
        {
            Reposition();
        }
    }

    private void Reposition()
    {
        Vector2 vector = new Vector2(_width*2f,0);
        transform.position = (Vector2)transform.position + vector;
    }
}
