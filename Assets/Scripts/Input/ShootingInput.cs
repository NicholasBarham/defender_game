using UnityEngine;
using Util.GameEvents;

namespace Defender
{
    public class ShootingInput : MonoBehaviour
    {
        [SerializeField] private VoidEvent shootEvent = null;
        void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                Shoot();
            }
        }

        void Shoot()
        {
            shootEvent.Raise();
        }
    }
}
