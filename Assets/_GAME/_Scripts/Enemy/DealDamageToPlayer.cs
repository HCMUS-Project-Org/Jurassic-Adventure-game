using System;
using UnityEngine;

namespace _GAME._Scripts.Enemy
{
    public class DealDamageToPlayer : MonoBehaviour
    {
        [SerializeField] private int  damage;
        [SerializeField] private bool destroyOnCollision;

        private void OnCollisionEnter2D(Collision2D col)
        {
            if (!col.collider.CompareTag("Player")) return;

            FindObjectOfType<PlayerHealth>().ChangeHealth(-damage);
            if (destroyOnCollision)
                Destroy(gameObject);
        }
    }
}