using Assets.Scripts.Skill;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Pool;

public class Skill : MonoBehaviour // Acting like BulletSpawner
{
    private protected SkillData _skillData;
    private float _elapsedTime;
    private float _cooldownTime;
    private int _level = -1; // index로 사용하기 위해 level1 = 0이 되기 위한 초기화
    private string _currentSkill;
    private int _bulletCount;
    private string _description;
    private Transform _playerTransform;
    private float _totalSkillDamage;

    [SerializeField]
    private Bullet _bullet; // 인스펙터에서 bullet prefab 설정 필요 
    private ObjectPool<Bullet> _bulletPool;

    private void Start()
    {
        _bulletPool = new ObjectPool<Bullet>(CreateBullet, OnTakeBulletFromPool);
        _playerTransform = transform.root.GetChild(0).GetComponent<Transform>();
        InitiateSkill();
    }

    private void Update()
    {
        Shoot();
    }

    private void InitiateSkill()
    {
        _currentSkill = "Guardian";
        // 플레이어가 UI를 통해 선택한 스킬 정보를 받아와야 함
        // 스킬 레벨업 시스템 반영시 로직 구현 필요

        ++_level; // 플레이어에 의해 선택될 때마다 스킬 레벨 상승

        if (_skillData == null)
        {
            GetSkillData(_currentSkill);
        }
        SetCurrentLevelSkill(_level); // 레벨별로 바뀌는 데이터만 갱신
    }

    private void Shoot()
    {
        _elapsedTime += Time.deltaTime;
        _cooldownTime = _skillData.CooldownTime;
        
        if (_elapsedTime >= _cooldownTime)
        {
            _elapsedTime = 0f;
            for (int id = 0; id < _bulletCount; ++id)

            {
                Bullet bullet = GetBulletFromPool();
                SetBullet(bullet, id);
            }
        }
    }

    private void SetBullet(Bullet bullet, int id)
    {
        // 발사체에게 데이터 테이블에서 자료를 가져와 정보를 넘기는 부분
        SetPosition(bullet, id);
        SetMovingPattern(bullet);
        SetDamage(bullet);
        SetCurrentLevelBullet(bullet, _level);
    }

    private Bullet GetBulletFromPool()
    {
        Debug.Assert(_bulletPool != null);

        Bullet bullet = _bulletPool.Get();

        return bullet;
    }

    // functions for pooling 
    private Bullet CreateBullet()
    {
        Bullet bullet = Instantiate(_bullet);
        bullet.BulletPool = _bulletPool;
        bullet.Stat.Sprite = _skillData.Sprite;
        return bullet;
    }

    private void OnTakeBulletFromPool(Bullet bullet) => bullet.gameObject.SetActive(true);

    // functions for skill initialization
    private void GetSkillData(string skillName)
    {
        _skillData = Resources.Load<SkillData>($"Data/Skill/{skillName}");
    }

    private void SetCurrentLevelSkill(int level)
    {
        _description = _skillData.SkillDescriptions[level];
        _bulletCount = _skillData.Counts[level];
    }
    
    // functions for bullets
    private void SetMovingPattern(Bullet bullet)
    {
        // 비행 방법 전달 새로운 스킬 구현 시 스킬 정보에서 pattern을 받아와 switch문으로 적용 필요
        // 각각 비행 방법에 대한 컴포넌트를 가지고 있고 해당 컴포넌트를 켜는 방식으로.        
    }

    private void SetPosition(Bullet bullet, int id)
    {
        // 발사체 초기 위치 결정
        bullet.transform.SetParent(this.transform);
    }
    private void SetDamage(Bullet bullet)
    {
        // 여기에 플레이어 스테이터스 적용 시 player의 atk과 곱하기 
        bullet.Stat.CurrentBulletDamage = _skillData.DamagePerBullet[_level];
    }

    private void SetCurrentLevelBullet(Bullet bullet, int level)
    {
        bullet.Stat.BulletSpeed = _skillData.BulletSpeed[level];       
        bullet.Stat.Count = _skillData.Counts[level];
    }
}
