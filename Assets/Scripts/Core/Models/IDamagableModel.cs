namespace Core.Models
{
    public interface IDamagableModel
    {
        float MaxHp { get; set; }
        float Hp { get; set; }
        float HpRecovery { get; set; }
    }
}