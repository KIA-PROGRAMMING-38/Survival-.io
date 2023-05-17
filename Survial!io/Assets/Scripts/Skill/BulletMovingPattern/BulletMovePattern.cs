using UnityEngine;

public interface IBulletMovingPattern
{
    void Do(BulletStat bulletStat, Rigidbody2D rigidbody);
}

class Revolution : IBulletMovingPattern
{
    public void Do(BulletStat bulletStat, Rigidbody2D rigidbody)
    {

    }
}

class Movetraight : IBulletMovingPattern
{
    public void Do(BulletStat bulletStat, Rigidbody2D rigidbody)
    {

    }
}

class DirectPosition : IBulletMovingPattern
{
    public void Do(BulletStat bulletStat, Rigidbody2D rigidbody)
    {

    }
}


