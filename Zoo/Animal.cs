using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zoo
{
    class Animal
    {
        public int Id;
        public string Name;
        public bool Scared;
        public int Price;
       
        
        public Animal(int id,string name, bool scared, int price)
        {
            this.Name = name;
            this.Id = id;
            this.Scared = scared;
            this.Price = price;
            
          
        }
        public Animal()
        {

        }
    }
}
