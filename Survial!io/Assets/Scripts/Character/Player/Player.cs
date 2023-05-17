using System;
using UnityEngine;


public class Player : CharacterBase, IMovable
{
    // 프레젠터 및 매니저 역할을 할 클래스

    private Vector2 _inputVector;
    private Vector2 _directionNormalized;
    private float _speed;
    private UserInput _userInput;
    private int _level;
    private int _currentEXP;
    private int _maxEXP;

    private const int MAX_SKILL_COUNT = 6;

    public void AddExp(int exp)
    {
        _currentEXP += exp;
    }

    private void Awake()
    {
        Init();
    }

    private void Update()
    {
        Move();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Item item = collision.GetComponent<Item>();
        item?.Effect(this);        
    }

    public void Init()
    {
        // 플레이어 캐릭터 초기화
        CharacterStat player = new CharacterStat
        {
            SkillSet = new Skill[MAX_SKILL_COUNT]
        };        
        _userInput = GetComponentInParent<UserInput>();
        GameManager.Instance.Player = this;
    }
    private void SetSpeed()
    {        
        Speed = _speed; // CharacterBase에서 상속받은 필드
        // 유저 아이템 기능 추가 시 유저 아이템의 스피드 반영하여 계산.
        // 게임 중 speed가 바뀌는 경우는 유저가 게임 중 버프 스킬을 골랐을 때
    }
    override public void Move()
    {
        SetDirection(); // 여기서 정한 direction으로 movement 컴포넌트 동작
        OnMove();
    }
    private void SetDirection()
    {
        Direction = _directionNormalized; // CharacterBase 상속 필드
        _inputVector.Set(_userInput.Horizontal, _userInput.Vertical);
        _directionNormalized = _inputVector.normalized;
    }
    public void OnMove()
    {

    }
    override public void TakeDamage(float damageAmount, GameObject attacker = null)
    {
        // health에서 발생한 메시지를 ui에 전달
    }
    public void OnHeal() // 플레이어블 캐릭터에서만 있는 기능, 향후 기획에 따라 모든 캐릭터가 가능해질 수 있지 않을까?
    {
        // health에서 발생한 메시지를 ui에 전달
    }
    override public void Dead()
    {
        // helath에서 메시지를 받아서 게임 종료에 메시지를 줘야한다.
    }

}
