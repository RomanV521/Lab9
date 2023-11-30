using System;
using System.Reflection.Metadata;

namespace Lab8
{
    class SortingShoppingList
    {
        public delegate bool CompareDelegate(Product left, Product right);
        public delegate bool SearchDelegate(Product product, string searchValue);

        /// <summary>
        /// Сортировка листа продуктов
        /// </summary>
        /// <param name="listProducts">Лист с продуктами</param>
        /// <param name="compareDelegate">Сссылка на функцию, по которой будем сравнивать элементы</param>
        /// <exception cref="ArgumentNullException"></exception>
        public static void Sort(ShoppingList listProducts, CompareDelegate compareDelegate)
        {
            if(listProducts is not null)
            {
                for (int i = 0; i < listProducts.ProductList.Count - 1; i++) 
                { 
                    for(int j = 0; j < listProducts.ProductList.Count - 1; j++)
                    {
                        if (compareDelegate(listProducts.ProductList[j], listProducts.ProductList[j + 1]))
                        {
                            (listProducts.ProductList[j], listProducts.ProductList[j+1]) = (listProducts.ProductList[j + 1], listProducts.ProductList[j]);
                        }
                    }
                }
            }
            else { throw new ArgumentNullException(); }
        }

        /// <summary>
        /// Поиск продукта в листе
        /// </summary>
        /// <param name="listProducts">Лист с продуктами</param>
        /// <param name="searchValue">Значение фильтрации</param>
        /// <param name="searchDelegate">Сссылка на функцию, по которой будем фильтровать елементы</param>
        /// <returns>Найденые продукты</returns>
        public static List<Product> Search(ShoppingList listProducts, string searchValue, SearchDelegate searchDelegate)
        {
            List<Product> newList = new List<Product>();

            for (int i = 0;i < listProducts.ProductList.Count; i++) 
            {
                if (searchDelegate(listProducts.ProductList[i], searchValue)) 
                {
                    newList.Add(listProducts.ProductList[i]);
                }   
            }
            return newList;
        }

        /// <summary>
        /// Сравнение цены по убыванию
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public static bool DescendingByCost(Product left, Product right)
        {
            return left.Cost <= right.Cost;
        }

        /// <summary>
        /// Сравнение скидок по убыванию
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public static bool DescendingByDiscount(Product left, Product right)
        {
            return left.Discount <= right.Discount;
        }

        /// <summary>
        /// Сравнение конечной цены со скидкой по убыванию
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public static bool DescendingByFinalCost(Product left, Product right)
        {
            return left.FinalCost <= right.FinalCost;
        }


        /// <summary>
        /// Сравнение цены по возрастанию
        /// </summary>
        /// <param name="left">Первый продукт</param>
        /// <param name="right">Второй продукт</param>
        /// <returns></returns>
        public static bool BelowByCost(Product left, Product right)
        {
            return left.Cost >= right.Cost;
        }

        /// <summary>
        /// Сравнение скидок по возрастанию
        /// </summary>
        /// <param name="left">Первый продукт</param>
        /// <param name="right">Второй продукт</param>
        /// <returns></returns>
        public static bool BelowByDiscount(Product left, Product right)
        {
            return left.Discount >= right.Discount;
        }

        /// <summary>
        /// Сравнение конечной цены со скидкой по возрастанию
        /// </summary>
        /// <param name="left">Первый продукт</param>
        /// <param name="right">Второй продукт</param>
        /// <returns></returns>
        public static bool BelowByFinalCost(Product left, Product right)
        {
            return left.FinalCost >= right.FinalCost;
        }
    }
}
