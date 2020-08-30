using Defender.GameEvents;
using UnityEngine;

namespace Defender
{
    public class PlayerShoot : MonoBehaviour
    {
        [SerializeField] private Transform bulletSpawn = null;

        [SerializeField] private ShootingInfoEvent shootEvent = null;
        
        public void Shoot()
        {
            shootEvent.Raise(new ShootingInfo(bulletSpawn.transform.position, transform.up));
        }
    }
}
