using System.Collections.Generic;
using UnityEngine;

namespace Defender
{
    public class BulletPoolManager : MonoBehaviour, IPoolManager
    {
        [SerializeField] private GameObject bulletPrefab = null;
        
        private Queue<IBullet> _bulletPool = new Queue<IBullet>();

        private void Awake()
        {
            GetAllBulletsFromChildren();
        }

        private void GetAllBulletsFromChildren()
        {
            _bulletPool.Clear();

            var bullets = transform.GetComponentsInChildren<IBullet>();

            foreach (var bullet in bullets)
            {
                _bulletPool.Enqueue(bullet);
            }
        }

        public void Fire(ShootingInfo shootingInfo)
        {
            IBullet bullet = FindAvailableBullet();

            bullet.Use(this);
            bullet.Spawn(shootingInfo.Position);
            bullet.Fire(shootingInfo.Direction);
        }

        public void Return(IBullet bullet)
        {
            if (!bullet.Equals(null))
                _bulletPool.Enqueue(bullet);
        }

        private IBullet FindAvailableBullet()
        {
            return _bulletPool.Count > 0 ? _bulletPool.Dequeue() : CreateBullet();
        }

        private IBullet CreateBullet()
        {
            return Instantiate(bulletPrefab, transform).GetComponent<IBullet>();
        }
    }
}
