using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CosmicCuration.Enemy
{

    public class EnemyPool
    {
        private EnemyView enemyView;
        private EnemyData enemyData;
        private List<PooledEnemy> pooledEnemies = new List<PooledEnemy>();
        public EnemyPool(EnemyView enemyView, EnemyData enemyData)
        {
            this.enemyView = enemyView;
            this.enemyData = enemyData;
        }
        public EnemyController GetPooledEnemy()
        {
            if (pooledEnemies.Count > 0)
            {
                PooledEnemy pooledEnemy = pooledEnemies.Find(item => !item.isUsed);
                if (pooledEnemy != null)
                {
                    pooledEnemy.isUsed = true;
                    return pooledEnemy.enemy;
                }

            }
            return CreatePooledEnemy();
        }
        public void ReturnToPool(EnemyController enemyController)
        {
            PooledEnemy pooledEnemy = pooledEnemies.Find(item => item.enemy.Equals(enemyController));
            pooledEnemy.isUsed = false;
        }

        private EnemyController CreatePooledEnemy()
        {
            PooledEnemy pooledEnemy = new PooledEnemy();
            pooledEnemy.enemy = new EnemyController(enemyView, enemyData);
            pooledEnemy.isUsed = true;
            pooledEnemies.Add(pooledEnemy);
            return pooledEnemy.enemy;
        }
        public class PooledEnemy
        {
            public EnemyController enemy;
            public bool isUsed;
        }
    }



}

