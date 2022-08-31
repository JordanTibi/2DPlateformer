using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlateformeTag : MonoBehaviour
{
    [SerializeField] Rigidbody2D _rb;
    Vector3 _startPosition;

    private void Start()
    {
        _startPosition = transform.position;
    }

    void Rollback()
    {
        _rb.gravityScale = 0;
        _rb.velocity = Vector3.zero;
        transform.position = _startPosition;
    }
}
