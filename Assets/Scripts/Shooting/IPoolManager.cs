using Defender;

public interface IPoolManager
{
    void Fire(ShootingInfo shootingInfo);
    void Return(IBullet bullet);
}
