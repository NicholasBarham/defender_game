using UnityEngine;
using Util.GameEvents;


namespace Defender.GameEvents
{
    [CreateAssetMenu(fileName = "ShootingInfoGameEvent", menuName = "Game Events/Shooting Info")]
    public class ShootingInfoEvent : BaseGameEvent<ShootingInfo> { }
}