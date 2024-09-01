using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CosmicCuration.Bullets
{
    public class BulletPool
    {
        private BulletView bulletView;
        private BulletScriptableObject bulletScriptableObject;
        private List<PooledBullet> pooledBullets = new List<PooledBullet>();

        public BulletPool(BulletView bulletView, BulletScriptableObject bulletScriptableObject)
        {
            this.bulletView = bulletView;
            this.bulletScriptableObject = bulletScriptableObject;
        }
        public BulletController GetBullet()
        {
            if(pooledBullets.Count> 0)
            {
                PooledBullet pooledBullet = pooledBullets.Find(item => !item.isUsed);
               if(pooledBullet != null)
                { 
                    pooledBullet.isUsed = true;
                    return pooledBullet.bullet;
                }
            }
            return CreateNewPooledBullet();
        }
        private BulletController CreateNewPooledBullet()
        {
            PooledBullet pooledBullet = new PooledBullet();
            pooledBullet.bullet = new BulletController(bulletView, bulletScriptableObject);
            pooledBullet.isUsed = true;
            return pooledBullet.bullet;
        }
        public class PooledBullet
        {
            public BulletController bullet;
            public bool isUsed;
        }

    }
}


