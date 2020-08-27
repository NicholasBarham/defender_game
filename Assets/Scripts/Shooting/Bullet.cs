using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Util.Variables;

namespace Defender
{
    public class Bullet : MonoBehaviour, IBullet
    {
        [SerializeField] private Rigidbody2D rb = null;
        [SerializeField] private FloatReference bulletSpeed = null;
        public bool IsInUse { get; private set; }
        public int Damage { get; }

        private void Awake()
        {
            if (rb.Equals(null))
                rb = GetComponent<Rigidbody2D>();
        }

        public void Use() => IsInUse = true;
        
        public void Spawn(Vector3 position)
        {
            rb.velocity = Vector2.zero;
            transform.position = position;
            gameObject.SetActive(true);
        }

        public void Fire(Vector2 direction)
        {
            rb.velocity = direction.normalized * bulletSpeed.Value;
        }

        private void OnCollisionEnter2D(Collision2D other)
        {
            //TODO on bullet collision
        }

    }
}
