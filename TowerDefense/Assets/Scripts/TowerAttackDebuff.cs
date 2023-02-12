/// <summary>
/// Class defining debuff tower
/// </summary>
public class TowerAttackDebuff : WeaponManager
{
    public TowerAttackDebuff()
    {
        TowersDamage = new TowerDebuffDamage();
    }
}