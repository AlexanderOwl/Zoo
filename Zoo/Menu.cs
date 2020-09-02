using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zoo
{
    class Menu
    {

        public Menu(List<Animal> animals)
        {

            Console.Clear();// Очищаем консоль
            Console.WriteLine("ZOO v1 [ADMIN]  Visitors in ZOO - " + Zoo.visitors);
            Console.WriteLine();
            Console.WriteLine("Sell ticket - 1");
            Console.WriteLine("Kick out a visitor - 2");
            Console.WriteLine("Close zoo - 3");
            Console.WriteLine("Exit - 4");
            string answ = Console.ReadLine();//Считываем ответ

            if (answ == "1")
            {
                if (Zoo.visitors < 5)
                {
                    if (sellTicket(animals)) //Если билет продали добавляем посетителя
                    {
                        Zoo.visitors++;
                    }//Если не продали ничего не делаем начинаем заново
                }//Если посетителей меньше 5
                else
                {
                    Console.WriteLine();
                    Console.WriteLine("Сommand not available! The zoo is full!");
                }//Если посетителей больше 5 зоопарк полн
                Console.ReadKey();
            }//Продаем билет
            else if (answ == "2")
            {
                if (Zoo.visitors > 0) //Если посетителей больше 0 
                {
                    Zoo.visitors--;// Выганяем
                }
                else //Вы ином случае постетителей нету
                {
                    Console.WriteLine("Here is no visitors!");
                    Console.ReadKey();
                }
            }// Выганяем посетителя
            else if (answ == "3")
            {
                if (Zoo.visitors > 0)
                {
                    Zoo.visitors = 0;
                }
                else
                {
                    Console.WriteLine("Here is no visitors!");
                    Console.ReadKey();
                }
            }// Выганяем всех посетителя
            else if (answ == "4")
            {
                Environment.Exit(0);
            }// Закрываем программу
            else
            {
                Console.WriteLine("Incorrect input!");
                Console.ReadKey();
            }// Обработка не коректного ввода 
        }// Конструктор Меню 

        public bool sellTicket(List<Animal> animals)
        {

            int price;
            Console.WriteLine();
            Console.WriteLine("Welcome to ZOO!");
            Console.WriteLine();

            List<Animal> uvailbleAnimals = Ticket(animals);// Создаем лист из доступных животных. Функция ticket делает проверку по возрасту и возвращает не страшных животных.    

            do
            {
                Console.WriteLine();
                List<Animal> choosenAnimals = Choose(uvailbleAnimals); // Спрашиваем каких пользователь хочет посмотреть животных. Записываем в лист.
                if (choosenAnimals.Count == 0)// На случай если пользователь отказался выбирать животных. Чтобы не предлагала программа корм выходим из метода с значением False - значит билет не прдали.
                {
                    return false;
                }
                Console.WriteLine();
                print(choosenAnimals);// Печатаем выбраных животных
                bool wantFeed = WantFeed(); //Спрашиваем про корм
                price = Price(choosenAnimals, wantFeed); //Расчитываем цену
                if (price > 0)//Если цена больше нуля. Теоретически не может быть меньше.
                {
                    Console.WriteLine();
                    Console.WriteLine("Total price: " + price + "UAH");
                    Console.WriteLine("\n - Сonfirm payment press ENTER" +
                                      "\n - Press R to rechoose" +
                                      "\n - Press any key to decline");
                    ConsoleKey key = Console.ReadKey().Key;
                    if (key == ConsoleKey.Enter) //Если Ентер то билет продали и выходим из метода
                    {
                        Console.WriteLine("Payment confirmed!");
                        Console.WriteLine("Welcome to zoo!");

                        return true;
                    }
                    else if (key == ConsoleKey.R)//Если R то начинаем цикл заново
                    {
                        Console.WriteLine("Rechoose!");

                    }
                    else { Console.WriteLine("Payment decline!"); return false; } // Если любая другая клавиша то билет не продали выходим False
                }
                else { Console.WriteLine("Price is less than or equal to zero!"); return false; }//Если цена меньше нуля. Теоретически не может быть меньше.
            } while (true);
        }//Продаем билет

        public int Price(List<Animal> choosenAnimals, bool wantFeed)
        {
            int price = 0;
            if (wantFeed == true)
            {
                price += 200;
            }

            foreach (var item in choosenAnimals)
            {
                price = price + item.Price;
            }

            return price;
        }//Считает цену
        public bool WantFeed()
        {

            do
            {
                Console.WriteLine("Feed - 200 UAH add to sum? y/n");
                string answ = Console.ReadLine();
                if (answ == "y")
                {

                    return true;

                }
                else
                {
                    return false;
                }

            } while (true);

        }//Считает цену
        public bool IsKid()
        {
            bool flag = false;
            do
            {
                Console.WriteLine("How old are you?");
                flag = int.TryParse(Console.ReadLine(), out int age);
                if (age < 8)
                {
                    return true;
                }
                else
                {
                    return false;
                }

            } while (!flag);

        }//Спрашиваем возраст проверем ребенок или нет
        public void print(List<Animal> animals)
        {
            foreach (var item in animals)
            {
                Console.WriteLine("#id " + item.Id + "\t" + item.Name + " - " + item.Price);
            }
        }//Печатаем лист животных
        public List<Animal> Ticket(List<Animal> animals)
        {
            bool isKid = IsKid();
            List<Animal> uvailableAnimals = new List<Animal>();
            foreach (Animal animal in animals)
            {
                if (isKid == false)
                {
                    Console.WriteLine("#id " + animal.Id + "\t" + animal.Name + " - " + animal.Price);
                    uvailableAnimals.Add(animal);
                }
                else if (isKid != animal.Scared)
                {
                    Console.WriteLine("#id " + animal.Id + "\t" + animal.Name + " - " + animal.Price);
                    uvailableAnimals.Add(animal);
                }
            }
            return uvailableAnimals;
        }//Создает лист с животными которых может выбрать пользователь (страшные или не страшные) зависит от возраста
        public List<Animal> Choose(List<Animal> uvailableAnimals)
        {
            List<Animal> choosenAnimals = new List<Animal>();
            bool loop;
            do
            {
                loop = false;
                Console.WriteLine("Chose animals to visit (0 to exit):");
                string inputText = Console.ReadLine(); //Воодим номера животных 
                string[] animalsText = inputText.Split(' ');//Сплитим по пробелам
                foreach (var numText in animalsText)//Для каждого разспличеного номера
                {
                    bool find = false;
                    int num;
                    bool correctParse = int.TryParse(numText, out num); //Проверяем номер ли вообще 

                    if (numText.Length == 1 && num.Equals(0)) //Если в масиве номеров один елемент и он ноль то выходим из цикла
                    {
                        loop = false;
                    }
                    else if (correctParse == true) //Проверка на номер вернула true
                    {

                        foreach (var item in uvailableAnimals)//Для каждого животного в листе доступных проверяем содержится ли номер который ввел пользователь
                        {
                            find = false;
                            if (item.Id.Equals(num) == true)//если содержиться 
                            {
                                choosenAnimals.Add(item);//добавляем этот елемент в список выбраных
                                find = true;// возвращаем что нашли
                                break;//и выходим из цикла дальше не идем
                            }

                        }
                        if (find == false)//если не нашли ни одного животного значит ввели цифру вне диапазона ОШИБКА
                        {
                            choosenAnimals.Clear();
                            Console.WriteLine("Incorrect input! Try again or input 0 to exit");
                            loop = true;
                            break;//Сразу выходим из цикла
                        }

                    }
                    else
                    {
                        choosenAnimals.Clear();
                        Console.WriteLine("Incorrect input! Try again or input 0 to exit");
                        loop = true;
                        break;
                    }
                }


            } while (loop);
            return choosenAnimals;
        }//Из листа животных (страшних или нет) предлагает пользователю выбор
    }
}
