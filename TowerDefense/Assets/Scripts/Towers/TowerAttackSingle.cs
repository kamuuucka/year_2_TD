/// <summary>
/// Class defining single attack tower
/// </summary>
public class TowerAttackSingle : WeaponManager
{
    public TowerAttackSingle()
    {
        TowersDamage = new TowerSingleDamage();
    }
}