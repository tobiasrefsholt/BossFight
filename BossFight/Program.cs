// See https://aka.ms/new-console-template for more information

using BossFight;

var game = new Game(
    new GameCharacter("Hero", 100, 20, 20, 40),
    new GameCharacter("Boss", 100, 0, 30, 10)
);
game.Run();