using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall : MonoBehaviour, BulletDestroyer
{
    public void TakeBullet(Bullet bullet)
    {
        Destroy(bullet.gameObject);
    }
}

