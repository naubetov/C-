using System;
using System.Text;

namespace RRR
{
   

    public abstract class Goods : IComparable // Сыныпта екі Public бар: автор (автордың тегі) және аты (атауы).
    {

        public string Product_Name { get; set; } // Тауар аты 
        public string Age  { get; set; } // Адам жасы қолданатын
        public virtual string Display() /*Дисплей әдісі басылым туралы негізгі ақпаратты қамтитын жолды қайтарады. 
                                         * Біздің сыныптың барлық мұрагерлері ақпаратты экранға шығару әдістерін анықтауы керек болғандықтан, 
                                         * әдіс виртуалды деп анықталады, ал мұрагерлер бұл әдісті қайта анықтайды.*/
        { return $"Тауар: {Product_Name} Жасы: \"{Age}\" аралығындағы адамдарға арналған"; }
        public bool IsThisEdition(string product_name)//әдісі басылымның ізделгенін тексереді және егер басылым авторының тегі product жолымен сәйкес келсе, true қайтарады.
        { return Product_Name.Equals(product_name, StringComparison.OrdinalIgnoreCase); }
        public int CompareTo(object o)
        {
            Goods g = o as Goods;
            if (g != null)
                return this.Product_Name.CompareTo(g.Product_Name);
            else
                throw new Exception("Екі нысанды салыстыру мүмкін емес");
        }
        public override string ToString()
        { return Product_Name; }
    }
    public class Book : Goods
    {
        public int Cost { get; set; }//Бағасы
        public string Publisher { get; set; }//Басылым

        public override string Display()
        {
            return $"{base.Display()} Бағасы: {Cost}";
        }
    }
    public class Toy : Goods
    {
        public string Manufacturer { get; set; }//Өндіруші компания аты
        public string Materials { get; set; }//Қандай материалдан жасалған туралы ақпарат береді
        public int Cost { get; set; }//Бағасы

        public override string Display()
        {
            return $"{base.Display()} Өндіруші:  \"{Manufacturer}\" Жасалған материал түрі: {Materials} Бағасы: {Cost} тг";
        }
    }
    public class SportsEquipment : Goods
    {
        public string Manufacturer { get; set; }//Өндіруші компания аты
        public int Cost { get; set; }//Тауар бағасы

        public override string Display()
        {
            return $"{base.Display()} Өндіруші: {Manufacturer} Бағасы: {Cost} тг";
        }
    }
    internal class Program
    {
        static void Main()
        {
            Console.OutputEncoding = Encoding.UTF8;
            Goods[] editions = new Goods[]
            {
                new Book()
                {
                     Cost = 1000,Publisher = "Marwin",Product_Name = "Книга",Age = "0-99"
                },
                new Toy()
                {
                    Cost = 13250, Product_Name = "LEGO: Monster Jam Grave Digger TECHNIC 42118", Age = "5 - 30", Manufacturer = "LEGO",Materials = "Plastik"
                },
               
                new SportsEquipment()
                {
                    Cost = 10990, Product_Name = "Гантель Demix, 5 кг", Age = "14- 70", Manufacturer = "SportMaster"
                }
            };
            Console.WriteLine("");
            Console.WriteLine("Каталог:");
            foreach (Goods edition in editions)
            { Console.WriteLine(edition.Display()); }
            Console.WriteLine("");
            Console.WriteLine("Сіз тапқыңыз келетін тауар атын енгізіңіз:");
            string product = Console.ReadLine();
            Console.WriteLine($"Тауар бойынша іздеу нәтижелері: {product}");
            foreach (Goods edition in editions)
            {
                if (edition.IsThisEdition(product))
                { Console.WriteLine(edition.Display()); }
            }
        }
    }
}
