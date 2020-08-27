using System.Collections.Generic;
using UnityEngine;

namespace Defender
{
    public class BulletPoolManager : MonoBehaviour
    {
        [SerializeField] private GameObject[] bulletPool = null;
        private List<IBullet> _bulletPool = new List<IBullet>();

        private void Awake()
        {
            GetAllBulletsFromPool();
        }

        private void GetAllBulletsFromPool()
        {
            _bulletPool.Clear();
            foreach (var bulletObject in bulletPool)
            {
                if (bulletObject.TryGetComponent(out IBullet bullet))
                {
                    _bulletPool.Add(bullet);
                }
            }
        }

        public void FireBullet(ShootingInfo shootingInfo)
        {
            IBullet bullet = FindAvailableBullet();

            bullet.Use();
            bullet.Spawn(shootingInfo.Position);
            bullet.Fire(shootingInfo.Direction);
        }

        private IBullet FindAvailableBullet()
        {
            for (int i = _bulletPool.Count - 1; i >= 0; i--)
            {
                if (_bulletPool[i].IsInUse == false)
                    return _bulletPool[i];
            }

            return null;
        }
    }
}
