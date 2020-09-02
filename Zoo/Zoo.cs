using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zoo
{
    class Zoo
    {
        static public int visitors = 0;
        public Zoo(List<Animal> animals)
        {
            addAnimal(animals, 1, "Tiger", false, 990);
            addAnimal(animals, 2, "Snake", false, 100);
            addAnimal(animals, 3, "Giraff", false, 100);
            addAnimal(animals, 4, "Zebra", false, 100);
            addAnimal(animals, 5, "Rooster", true, 100);
            addAnimal(animals, 6, "Platva", true, 99999);
            addAnimal(animals, 7, "Bull", true, 100);
            addAnimal(animals, 8, "Crocodile", true, 100);
            addAnimal(animals, 9, "Rhinoceros", false, 100);
            addAnimal(animals, 10, "Tarantula", true, 1);
        }

        public void addAnimal(List<Animal> animals, int id, string name, bool scared, int price)
        {
            animals.Add(new Animal(id, name, scared, price));
        }      
        
    }
}
