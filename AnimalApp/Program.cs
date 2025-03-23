using System;

interface IAnimal
{
    void speak();
}

class Dog : IAnimal
{
    public void speak()
    {
        Console.WriteLine("woof");
    }
}

class Cat : IAnimal
{
    public void speak()
    {
        Console.WriteLine("meow");
    }
}

interface IAnimalFactory {
    IAnimal CreateAnimal(string animalType);
}

// Factory class
class AnimalFactory : IAnimalFactory {
    public IAnimal CreateAnimal(string animalType) {
        switch (animalType) {
            case "dog":
                return new Dog();
            case "cat":
                return new Cat();
            default:
                Console.WriteLine("Invalid Animal");
                return null;
        }
    }
}

class Program
{
    static void Main() {
        IAnimalFactory animalFactory = new AnimalFactory();
        IAnimal dog = animalFactory.CreateAnimal("dog");
        dog.speak();

        IAnimal cat = animalFactory.CreateAnimal("cat");
        cat.speak();
    }
}