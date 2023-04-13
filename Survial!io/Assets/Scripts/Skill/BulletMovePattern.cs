namespace Assets.Scripts.Skill
{
    using UnityEngine;
    
    public interface IBulletMovingPattern
    {
        void Do(BulletStat bulletStat, Rigidbody2D rigidbody);
    }

    class Revolution : IBulletMovingPattern
    {
        public void Do(BulletStat bulletStat, Rigidbody2D rigidbody)
        {
            //for (int i = 0; i < bulletStat.Count; ++i)
            //{

            //    float angle = i * (360 / bulletStat.Count) * Mathf.Deg2Rad;
            //    // 발사체 시작 위치 = (Vector2.right * Mathf.Cos(angle) + Vector2.up * Mathf.Sin(angle)) * 50;
            //}
        }
    }

    class MoveStraight : IBulletMovingPattern
    {
        public void Do(BulletStat bulletStat, Rigidbody2D rigidbody)
        {
            //Transform bullet;
            //rigidbody.velocity = bullet.forward * bulletStat.BulletSpeed;
        }
    }

    class DirectPosition : IBulletMovingPattern
    {
        public void Do(BulletStat bulletStat, Rigidbody2D rigidbody)
        {
            
        }
    }

}
