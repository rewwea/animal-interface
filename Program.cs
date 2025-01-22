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

class Animal : IMovable, IRenamable, ISoundable, IComparable, ICloneable
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

    public int CompareTo(object obj)
    {
        if (obj == null) return 1;

        Animal other = obj as Animal;
        if (other == null) throw new ArgumentException("Object is not an Animal");

        return string.Compare(this.Name, other.Name, StringComparison.Ordinal);
    }

    public object Clone()
    {
        return new Animal(this.Name, this.X, this.Y);
    }

    public override string ToString()
    {
        return $"Animal: {Name}, Location: ({X}, {Y})";
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

        Animal dog = new Animal("Шарик", 10, 20);
        Console.WriteLine(cat.CompareTo(dog));

        Animal clonedCat = (Animal)cat.Clone();
        Console.WriteLine($"Клон: {clonedCat}");
    }
}