using System;
using System.Collections.Generic;
using System.Text;

namespace TechShop.Products
{
    /// <summary>
    /// Class Game Derived Class of Product
    /// </summary>
    class Game : Product
    {

        public List<GameGenres> genre = new List<GameGenres>();
        public string platform { get; private set; }

        /// <summary>
        /// Adds more genres to game
        /// </summary>
        /// <param name="genre"></param>
        public void AddGenre(string genre)
        {
            this.genre.Add((GameGenres)Enum.Parse(typeof(GameGenres), genre));
        }
        /// <summary>
        /// Constructor of game
        /// </summary>
        /// <param name="name"></param>
        /// <param name="genre"></param>
        /// <param name="price"></param>
        /// <param name="manufacturer"></param>
        /// <param name="platform"></param>
        public Game(string name, string genre, int price, string manufacturer, string platform)
        {
            this.name = name;
            this.genre.Add((GameGenres)Enum.Parse(typeof(GameGenres), genre));
            this.manufacturer = manufacturer;
            this.price = price;
            this.platform = platform;
        }
        /// <summary>
        /// Info about all proparties of Game
        /// </summary>
        /// <returns>All info in str</returns>
        public override StringBuilder GetInfo()
        {
            StringBuilder str = new StringBuilder();
            str.Append("Name: " + this.name + "\n");
            str.Append("Genre: ");
            foreach(object o in genre){
                str.Append(o + " ");
            }
            str.Append("\n");
            str.Append("Platform: " + this.platform + "\n");
            str.Append("Manufacturer: " + this.manufacturer + "\n");
            str.Append("Price:" + this.price + "\n");
            return str;
        }
    }
}
