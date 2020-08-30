using System.Collections;
using UnityEngine;
using Util.Variables;

namespace Defender
{
    public class Bullet : MonoBehaviour, IBullet
    {
        [SerializeField] private Rigidbody2D rb = null;
        [SerializeField] private FloatReference bulletSpeed = null;

        private IPoolManager _manager = null;
        
        [SerializeField] private float lifetime = 3f;
        private Coroutine _lifeCoroutine = null;

        public int Damage { get; }

        private void Awake()
        {
            if (rb.Equals(null))
                rb = GetComponent<Rigidbody2D>();
        }

        public void Use(IPoolManager manager)
        {
            if (_manager == null)
                _manager = manager;
        }

        public void Spawn(Vector3 position)
        {
            rb.velocity = Vector2.zero;
            transform.position = position;
            gameObject.SetActive(true);
            
            if (_lifeCoroutine == null)
                _lifeCoroutine = StartCoroutine(BeginLifetime());
        }

        public void Fire(Vector2 direction)
        {
            rb.velocity = direction.normalized * bulletSpeed.Value;
        }

        public void Recycle()
        {
            _manager.Return(this);
            _manager = null;
            gameObject.SetActive(false);
        }

        private void Die()
        {
            if (_lifeCoroutine != null)
            {
                StopCoroutine(_lifeCoroutine);
                _lifeCoroutine = null;
            }

            Recycle();
        }

        private void OnCollisionEnter2D(Collision2D other)
        {
            //TODO on bullet collision
        }

        private IEnumerator BeginLifetime()
        {
            float currentLife = 0f;

            while (currentLife < lifetime)
            {
                yield return null;
                currentLife += Time.deltaTime;
            }

            Die();
        }

    }
}
