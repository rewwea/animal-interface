using System;
interface IMovable
{
    void Move(int x, int y);
}

interface IRenamable
{
    void Rename(string newName);
}

interface ISoundable
{
    void MakeSound();
}
class Animal : IMovable, IRenamable, ISoundable
{
    public string Name { get; private set; }
    public int X { get; private set; }
    public int Y { get; private set; }

    public Animal(string name, int x, int y)
    {
        Name = name;
        X = x;
        Y = y;
    }

    public void Move(int x, int y)
    {
        X = x;
        Y = y;
        Console.WriteLine($"{Name} переместился в точку ({X}, {Y})");
    }

    public void Rename(string newName)
    {
        Console.WriteLine($"Кличка изменена с {Name} на {newName}");
        Name = newName;
    }

    public void MakeSound()
    {
        Console.WriteLine($"{Name} издает звук: Мяу!");
    }
}

class Program
{
    static void Main(string[] args)
    {
        Animal cat = new Animal("Барсик", 0, 0);

        cat.Move(5, 10);

        cat.Rename("Мурзик");
        
        cat.MakeSound();
    }
}