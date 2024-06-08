using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float speed = 5f;
    [SerializeField] private Collider attackCollider;
    private void Update()
    {
        Move();
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Attack();
        }
    }

    private void Move()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;

        transform.position += move * Time.deltaTime * speed;
    }

    private void Attack()
    {
        attackCollider.enabled = true;
        Invoke(nameof(ResetAttack), 0.5f);
    }
    
    private void ResetAttack()
    {
        attackCollider.enabled = false;
    }
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            other.GetComponent<Enemy>().TakeDamage(1);
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Coin"))
        {
            CoinManager.Instance.AddCoin();
            Destroy(other.gameObject);
        }
    }
}
