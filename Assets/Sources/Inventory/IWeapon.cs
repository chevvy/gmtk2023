public interface IWeapon
{
    string ChangeAnimationTrigger { get; }
    string AttackAnimationTrigger { get; }
    string Name { get; }
    void Attack();
}
