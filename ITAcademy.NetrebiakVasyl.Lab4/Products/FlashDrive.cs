using System;
using System.Collections.Generic;
using System.Text;

namespace TechShop.Products
{
    /// <summary>
    /// Class FlashDrive Derived Class of Product
    /// </summary>
    class FlashDrive : Product
    {
        public int memory { get; private set; }
        public string color { get; private set; }
        public string connector { get; private set; }


        /// <summary>
        /// Constructor for FlashDrive
        /// </summary>
        /// <param name="name"></param>
        /// <param name="price"></param>
        /// <param name="manufacturer"></param>
        /// <param name="memory"></param>
        /// <param name="color"></param>
        /// <param name="connector"></param>
        public FlashDrive(string name,  int price, string manufacturer, int memory, string color,string connector )
        {
            this.name = name;
            this.manufacturer = manufacturer;
            this.price = price;
            this.memory = memory;
            this.color = color;
            this.connector = connector;
        }
        /// <summary>
        /// Info about all proparties of FlashDrive
        /// </summary>
        /// <returns>All info in str</returns>
        public override StringBuilder GetInfo()
        {
            StringBuilder str = new StringBuilder();
            str.Append("Name: " + this.name + "\n");
            str.Append("Color: " + this.color+ "\n");
            str.Append("Memory: " + this.memory+"\n");
            str.Append("Connector: " + this.connector+"\n");
            str.Append("Manufacturer: " + this.manufacturer+"\n");
            str.Append("Price:" + this.price+"\n");
            return str;
        }
    }
}
