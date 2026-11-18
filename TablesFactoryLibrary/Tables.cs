using System;
using System.Drawing;

namespace TablesFactoryLibrary
{
    /* Абстрактна фабрика столів
     * Кожна фабрика випускає набір з трьох столів в одному стилі:
     * обідній стіл, письмовий стіл і журнальний столик
     */

    //---------------------Abstract products
    public class DiningTable
    {
        public string name;
        public string material;
        public int seats;
        public int price;
        public Color color;
        public DiningTable()
        {
            name = "Обідній стіл";
            material = "невідомо";
            seats = 4;
            price = 0;
            color = Color.Gray;
        }
        public string Info()
        {
            return name + ": " + material + ", місць " + seats + ", ціна " + price + " грн";
        }
    }
    public class Desk
    {
        public string name;
        public string material;
        public int drawers;
        public int price;
        public Color color;
        public Desk()
        {
            name = "Письмовий стіл";
            material = "невідомо";
            drawers = 0;
            price = 0;
            color = Color.Gray;
        }
        public string Info()
        {
            return name + ": " + material + ", шухляд " + drawers + ", ціна " + price + " грн";
        }
    }
    public class CoffeeTable
    {
        public string name;
        public string material;
        public string shape;
        public int price;
        public Color color;
        public CoffeeTable()
        {
            name = "Журнальний столик";
            material = "невідомо";
            shape = "квадратний";
            price = 0;
            color = Color.Gray;
        }
        public string Info()
        {
            return name + ": " + material + ", " + shape + ", ціна " + price + " грн";
        }
    }

    //---------------------Abstract factory
    public abstract class TableFactory
    {
        public DiningTable dining;
        public Desk desk;
        public CoffeeTable coffee;
        public abstract DiningTable createDiningTable();
        public abstract Desk createDesk();
        public abstract CoffeeTable createCoffeeTable();
        public abstract void MakeSet();
        public int TotalPrice()
        {
            return dining.price + desk.price + coffee.price;
        }
    }

    //---------------------Wood tables
    public class WoodDiningTable : DiningTable
    {
        public WoodDiningTable()
        {
            name = "Дубовий обідній стіл";
            material = "дуб";
            seats = 6;
            price = 12500;
            color = Color.SaddleBrown;
        }
    }
    public class WoodDesk : Desk
    {
        public WoodDesk()
        {
            name = "Письмовий стіл з бука";
            material = "бук";
            drawers = 3;
            price = 7800;
            color = Color.Peru;
        }
    }
    public class WoodCoffeeTable : CoffeeTable
    {
        public WoodCoffeeTable()
        {
            name = "Журнальний столик з горіха";
            material = "горіх";
            shape = "круглий";
            price = 4200;
            color = Color.Sienna;
        }
    }
    public class WoodTableFactory : TableFactory
    {
        public override DiningTable createDiningTable()
        {
            return new WoodDiningTable();
        }
        public override Desk createDesk()
        {
            return new WoodDesk();
        }
        public override CoffeeTable createCoffeeTable()
        {
            return new WoodCoffeeTable();
        }
        public override void MakeSet()
        {
            dining = createDiningTable();
            desk = createDesk();
            coffee = createCoffeeTable();
        }
    }

    //---------------------Glass tables
    public class GlassDiningTable : DiningTable
    {
        public GlassDiningTable()
        {
            name = "Скляний обідній стіл";
            material = "загартоване скло і метал";
            seats = 4;
            price = 9900;
            color = Color.FromArgb(150, 120, 180, 220);
        }
    }
    public class GlassDesk : Desk
    {
        public GlassDesk()
        {
            name = "Скляний письмовий стіл";
            material = "скло і метал";
            drawers = 1;
            price = 6400;
            color = Color.FromArgb(150, 120, 180, 220);
        }
    }
    public class GlassCoffeeTable : CoffeeTable
    {
        public GlassCoffeeTable()
        {
            name = "Скляний журнальний столик";
            material = "скло";
            shape = "квадратний";
            price = 3500;
            color = Color.FromArgb(150, 120, 180, 220);
        }
    }
    public class GlassTableFactory : TableFactory
    {
        public override DiningTable createDiningTable()
        {
            return new GlassDiningTable();
        }
        public override Desk createDesk()
        {
            return new GlassDesk();
        }
        public override CoffeeTable createCoffeeTable()
        {
            return new GlassCoffeeTable();
        }
        public override void MakeSet()
        {
            dining = createDiningTable();
            desk = createDesk();
            coffee = createCoffeeTable();
        }
    }
}
