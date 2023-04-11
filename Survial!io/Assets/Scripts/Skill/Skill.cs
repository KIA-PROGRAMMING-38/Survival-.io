using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class Skill : MonoBehaviour
{
    private int _count = 1;
    private int _level;
    private float _cooldownTime = 0.5f;
    private float _elapsedTime;
    private string _currentSkill;
    private float _damagePerBullet;
    float _totalSkillDamage;

    [SerializeField]
    private Bullet _bullet;

    private ObjectPool<Bullet> _bulletPool;


    private void Start()
    {
        _bulletPool = new ObjectPool<Bullet>(CreateBullet, OnTakeBulletFromPool);
        SetSkill();
    }
    private void Update()
    {
        Shoot();
    }
    private void SetSkill()
    {
        _currentSkill = "currentSkillName"; // 플레이어가 UI를 통해 선택한 스킬 정보를 받아와야 함        
    }
    private void Shoot()
    {
        _elapsedTime += Time.deltaTime;
        
        if (_elapsedTime >= _cooldownTime)
        {
            _elapsedTime = 0f;
            for (int i = 0; i < _count; i++)
            {
                Bullet bullet = GetBulletFromPool();
                SetBullet(bullet);
            }
        }
    }
    private void SetBullet(Bullet bullet)
    {
        // 발사체에게 데이터 테이블에서 자료를 가져와 정보를 넘기는 부분
        SetPosition(bullet);
        SetDamage(bullet);
    }
    private void SetDamage(Bullet bullet)
    {
        _damagePerBullet = 1; 
    }
    private void SetPosition(Bullet bullet)
    {
        // root 오브젝트인 player에서 child 오브젝트인 body의 이동에 따라 position 결정
        Transform playerTransform = transform.root.GetChild(0);
        bullet.transform.position = playerTransform.position;
        bullet.transform.rotation = playerTransform.rotation;
    }
    private Bullet GetBulletFromPool()
    {
        Debug.Assert(_bulletPool != null);

        Bullet bullet = _bulletPool.Get();

        return bullet;

    }
    private Bullet CreateBullet()
    {
        Bullet bullet = Instantiate(_bullet);
        bullet.Pool = _bulletPool;

        return bullet;
    }
    private void OnTakeBulletFromPool(Bullet bullet) => bullet.gameObject.SetActive(true);
}
