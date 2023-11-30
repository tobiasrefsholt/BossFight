namespace BossFight;

public class GameCharacter
{
    public int Health { get; private set; }
    public string Name { get; }
    private int _minStrength;
    private int _maxStrength;
    private int _stamina;
    private int _currentStamina;

    public GameCharacter(string name, int health, int minStrength, int maxStrength, int stamina)
    {
        Name = name;
        Health = health;
        _minStrength = minStrength;
        _maxStrength = maxStrength;
        _stamina = stamina;
        _currentStamina = stamina;
    }

    public void Fight(GameCharacter enemy)
    {
        if (_currentStamina == 0)
        {
            Recharge();
            return;
        }

        _currentStamina -= 10;
        var currentStrength = GetStrength();
        enemy.TakeDamage(currentStrength);
        Console.WriteLine(
            $"{Name} hit {enemy.Name} with {currentStrength} damage, {enemy.Name} now has {enemy.Health}");
    }

    public void TakeDamage(int strength)
    {
        Health -= strength;
    }

    public bool IsAlive()
    {
        return Health > 0;
    }

    private int GetStrength()
    {
        if (_minStrength == _maxStrength) return _minStrength;
        var rand = new Random();
        return rand.Next(_minStrength, _maxStrength + 1);
    }

    private void Recharge()
    {
        Console.WriteLine(Name + " is recharging, no damage given this round.");
        _currentStamina = _stamina;
    }
}