/// <summary>
/// Class defining area tower
/// </summary>
public class TowerAttackArea : WeaponManager
{
    public TowerAttackArea()
    {
        TowersDamage = new TowerAreaDamage();
    }
}