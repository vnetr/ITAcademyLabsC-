using System;
using System.Collections.Generic;
using System.Text;

namespace TechShop.Products
{
    /// <summary>
    /// Class Game Derived Class of Product
    /// </summary>
    class Phone :Product
    {
        public string color { get; private set; }
        public int memory { get; private set; }
        public bool touchScreen { get; private set; }
        public int ram { get; private set; }
        /// <summary>
        /// Constructor of Phone
        /// </summary>
        /// <param name="name"></param>
        /// <param name="price"></param>
        /// <param name="manufacturer"></param>
        /// <param name="ram"></param>
        /// <param name="memory"></param>
        /// <param name="color"></param>
        /// <param name="touchscreen"></param>
        public Phone(string name, int price, string manufacturer,int ram, int memory, string color, bool touchscreen)
        {
            this.name = name;
            this.manufacturer = manufacturer;
            this.price = price;
            this.memory = memory;
            this.color = color;
            this.ram = ram;
            this.touchScreen = touchscreen;
        }
        /// <summary>
        /// Info about all proparties of Phone
        /// </summary>
        /// <returns>All info in str</returns>
        public override StringBuilder GetInfo()
        {
            StringBuilder str = new StringBuilder();
            str.Append("Name: " + this.name + "\n");
            str.Append("Color: " + this.color + "\n");
            str.Append("Memory: " + this.memory + "\n");
            str.Append("Touch screen: " + this.touchScreen + "\n");
            str.Append("RAM: " + this.ram + "\n");
            str.Append("Manufacturer: " + this.manufacturer + "\n");
            str.Append("Price:" + this.price + "\n");
            return str;
        }
    }
}
