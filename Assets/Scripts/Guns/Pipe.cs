using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pipe : MonoBehaviour, IPipe
{

    public Transform point;

    public GameObject Bullet;

    public Vector2 direction = Vector2.up;

    private void Start()
    {
        PoolManager.WarmPool(Bullet, 100);

        
    }

    public void Shoot(Gun gun)
    {
        Bullet bullet = PoolManager.SpawnObject(Bullet, point.position, point.rotation).GetComponent<Bullet>();

        bullet.damage = gun.infoWeapon.damage.GetValue(gun.infoWeapon.level);
        bullet.speed = gun.infoWeapon.speed.GetValue(gun.infoWeapon.level);
        bullet.direction = direction;
        bullet.gun = gun;

    }

}


public interface IPipe
{
    void Shoot(Gun gun);
}
