namespace BossFight;

public class Game
{
    private GameCharacter _hero;
    private GameCharacter _boss;
    private GameCharacter _activeCharacter;
    private GameCharacter _activeEnemy;

    public Game(GameCharacter hero, GameCharacter boss)
    {
        _hero = hero;
        _boss = boss;
        _activeCharacter = hero;
        _activeEnemy = boss;
    }

    public void Run()
    {
        Console.WriteLine("Press enter to start a new round");
        Console.ReadKey();
        while (!GameIsFinished())
        {
            NewRound();
            Console.ReadKey();
        }
    }

    private bool GameIsFinished()
    {
        if (!_hero.IsAlive())
        {
            Console.WriteLine("Hero is dead. Boss won!");
            return true;
        }

        if (!_boss.IsAlive())
        {
            Console.WriteLine("Boss is dead. Hero won!");
            return true;
        }

        return false;
    }

    private void NewRound()
    {
        SwitchPlayers();
        _activeCharacter.Fight(_activeEnemy);
    }

    private void SwitchPlayers()
    {
        _activeCharacter = _activeCharacter == _hero ? _boss : _hero;
        _activeEnemy = _hero == _activeCharacter ? _boss : _hero;
    }
}