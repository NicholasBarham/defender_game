using UnityEngine;

namespace Defender
{
    public interface IBullet
    {
        bool IsInUse { get; }
        int Damage { get; }
        void Use();
        void Spawn(Vector3 position);
        void Fire(Vector2 direction);
    }
}