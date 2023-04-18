using System;
using UnityEngine;


public class Player : CharacterBase, IMovable
{
    // 프레젠터 및 매니저 역할을 할 클래스
    private Vector2 _inputVector;
    private Vector2 _directionNormalized;
    public Vector2 Direction { get => _directionNormalized; set => _directionNormalized = value; }
    public float Speed { get => CharacterStat.DEFAULT_SPEED; set => SetSpeed(); }
    private UserInput _userInput;    
    public event Action<Vector2, float> OnMove;

    private void Awake()
    {
        Init();        
    }

    private void Update()
    {
        Move();        
    }
    public void Init()
    {
        // 플레이어 캐릭터 초기화
        // 
        CharacterStat player = new CharacterStat
        {
            SkillSet = new Skill[6],
            Speed = speed
        };
        // skill[0]은 장비 컨텐츠 구현 시 해당 장비의 기본 스킬과 일치하게 해야함
        // 여기서 생성한 스탯을 각각의 기능들에 뿌려줄 것
        _userInput = GetComponentInParent<UserInput>();
    }
    private void SetSpeed()
    {
        // 유저 아이템 기능 추가 시 유저 아이템의 스피드 반영하여 계산.
        // 게임 중 speed가 바뀌는 경우는 유저가 게임 중 버프 스킬을 골랐을 때라 구현 안할 것 같음.
    }
    public override void Move()
    {
        SetDirection();               
    }
    private void SetDirection()
    {
        _inputVector.Set(_userInput.Horizontal, _userInput.Vertical);        
        _directionNormalized = _inputVector.normalized;
    }
    public override void OnTakeDamage()
    {
        // health에서 발생한 메시지를 ui에 전달
    }
    public void OnHeal() // 플레이어블 캐릭터에서만 있는 기능, 향후 기획에 따라 모든 캐릭터가 가능해질 수 있지 않을까?
    {
        // health에서 발생한 메시지를 ui에 전달
    }
    public override void Died()
    {
        // 이거는 helath에서 메시지를 받아서 게임 종료에 메시지를 줘야한다.
    }

}
