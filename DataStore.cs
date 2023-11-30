using System;

namespace Lab8
{
    class DataStore
    {
        Random random = new Random();

        private string[] productName = { "Bread", "Carrots", "Milk", "Eggs", "Apples", "Rice", "Buckwheat", "Cottage cheese", "Butter", "Chicken", "Onions", "Tomatoes", "Cucumbers", "Bananas",  "Sugar", "Salt", "Pepper", "Cheese", "Potatoes", "Pasta"};
        private const int minCost = 10;
        private const int maxCost = 20;
        private const int minDiscount = 10;
        private const int maxDiscount = 99;

        /// <summary>
        /// Создание новой случайной записи класса Product
        /// </summary>
        /// <returns>Новый объект класса Product</returns>
        public Product CreateProductRecord()
        {
            return new Product(productName[random.Next(0, productName.Length)], random.Next(minCost, maxCost), random.Next(minDiscount, maxDiscount));
        }
    }
}
