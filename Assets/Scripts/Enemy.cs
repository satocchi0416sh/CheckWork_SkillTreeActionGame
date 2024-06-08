using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private float _health = 10f;
    [SerializeField] private GameObject coinPrefab;
    
    public void TakeDamage(int damage)
    {
        _health -= damage;
        if (_health <= 0)
        {
            Die();
        }
    }
    
    private void Die()
    {
        int coinCount = Random.Range(1, 6);
        for (int i = 0; i < coinCount; i++)
        {
            GameObject coin = Instantiate(coinPrefab, transform.position + Vector3.up * 2, Quaternion.Euler(90, 0, 0));
            Vector3 randomDirection = new Vector3(Random.Range(-1f, 1f), 0, Random.Range(-1f, 1f));
            coin.GetComponent<Rigidbody>().AddForce(randomDirection, ForceMode.Impulse);
        }

        Destroy(gameObject);
    }
}
