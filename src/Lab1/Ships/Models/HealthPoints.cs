namespace Itmo.ObjectOrientedProgramming.Lab1.Ships.Models;

public class HealthPoints
{
    private int _health;

    private HealthPoints(int health) => Health = health;

    public int Health
    {
        get => _health;
        private set
        {
            _health = value;
            if (_health < 0)
            {
                _health = 0;
            }
        }
    }

    public static implicit operator HealthPoints(int health)
    {
        return new HealthPoints(health);
    }

    public void Damage(uint damage)
    {
        Health -= (int)damage;
    }

    public HealthPoints ToHealthPoints()
    {
        return new HealthPoints(_health);
    }
}