
/// <summary>
/// Interface responsible for Towers damage and upgrading
/// </summary>
public interface ITowersDamage
{
    void Use(TowerRange towerRange, int damage);

    void Upgrade(int addition);
}
