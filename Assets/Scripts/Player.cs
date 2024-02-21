using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float moveSpeed;
    public float limitX;
    public bool isDead;
    public GameObject explosionVfxPb;

    private Rigidbody2D m_rb;

    private void Awake()
    {
        m_rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if(isDead || !GameManager.Ins.isGamePlaying) return;

        if(GamepadController.Ins.CanMoveLeft)
        {
            if(m_rb)
            {
                m_rb.velocity = Vector2.left * moveSpeed;
            }
        }
        else if(GamepadController.Ins.CanMoveRight)
        {
            if (m_rb)
            {
                m_rb.velocity = Vector2.right * moveSpeed;
            }
        }
        else
        {
            if(m_rb)
            {
                m_rb.velocity = Vector2.zero;
            }
        }

        if(transform.position.x < -limitX)
        {
            transform.position = new Vector3(-limitX, transform.position.y, transform.position.z);
        }
        if (transform.position.x > limitX)
        {
            transform.position = new Vector3(limitX, transform.position.y, transform.position.z);
        }
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if(col.CompareTag(Const.OBSTACLE_TAG))
        {
            gameObject.SetActive(false);
            col.gameObject.SetActive(false);

            isDead = true;
                
            if(explosionVfxPb)
            {
                Instantiate(explosionVfxPb, transform.position, Quaternion.identity);
            }

            GameManager.Ins.GameOver();
        }
    }
}
