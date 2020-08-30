using System;
using UnityEngine;

namespace Defender
{
    [Serializable]
    public struct ShootingInfo
    {
        public Vector3 Position { get; private set; }
        public Vector2 Direction { get; private set; }

        public ShootingInfo(Vector3 position, Vector2 direction)
        {
            Position = position;
            Direction = direction;
        }
    }
}