using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpstacleController : MonoBehaviour
{
    public float speed;

    private Rigidbody2D m_rb;

    private void Awake()
    {
        m_rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (m_rb != null)
        {
            m_rb.velocity = Vector2.down * speed;
        }
    }
}
