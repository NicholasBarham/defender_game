using UnityEngine;

namespace Defender
{
    public interface IBullet
    {
        int Damage { get; }
        void Use(IPoolManager manager);
        void Spawn(Vector3 position);
        void Fire(Vector2 direction);
        void Recycle();
    }
}