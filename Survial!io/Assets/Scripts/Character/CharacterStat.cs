public class CharacterStat
{
    public int MaxHP { get; set; }
    public int CurrentHP { get; set; }
    public int Atk { get; set; }
    public float Speed { get; set; }

    public const float DEFAULT_SPEED = 3f;
    public int Def { get; set; }
    public Skill[] SkillSet { get; set; }
}
