using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour, BulletDestroyer
{
    public void TakeBullet(Bullet bullet)
    {
        Destroy(bullet.gameObject);
    }
}
