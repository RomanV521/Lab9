using Lab9;
using System.Diagnostics;
using System.Linq;

namespace Lab8
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int numberOfRecords = 10;
            string firstSearchValue = "Ap";
            string secondSearchValue = "b";

            Product product1 = new Product("Bread", 30.1, 5);
            Product product2 = new Product("Apples", 15, 0);
            Product product3 = new Product("Milk", 20.15, 15);

            ShoppingList shoppingList = new ShoppingList(product1);

            //Добавление в лист
            shoppingList.AddProduct(product2);
            shoppingList.AddProduct(product3);
            Console.WriteLine(shoppingList);

            //Удаление элемента из листа при помощи двух способов
            shoppingList.RemoveProduct(product1);
            Console.WriteLine(shoppingList);
            shoppingList.RemoveProduct(1);
            Console.WriteLine(shoppingList);

            //Создание случайных продуктов и добавление их в лист
            DataStore ds = new DataStore();
            shoppingList.AddProduct(ds.CreateProductRecord());
            shoppingList.AddProduct(ds.CreateProductRecord());
            Console.WriteLine(shoppingList);

            //Создаем N-ое количество записей случайным образом
            for (int i = 0; i < numberOfRecords; i++)
            {
                shoppingList.AddProduct(ds.CreateProductRecord());
            }

            
            string fileNameBin = "ShopingList.bin";
            string fileNameJson = "ShopingList.json";

            //Сериализация
            FileManager.SavingToBinary(shoppingList, fileNameBin);
            FileManager.SerializationToJSON(shoppingList, fileNameJson);

            //Console.WriteLine(FileManager.LoadingFromBinary(fileNameBin));

            //Десериализация
            ShoppingList productsBin = (ShoppingList)FileManager.LoadingFromBinary(fileNameBin);
            ShoppingList productsJson = (ShoppingList)FileManager.DeserializationFromJSON(fileNameJson, shoppingList);

            
            Console.WriteLine($"File: {fileNameBin} \n {productsBin}");
            Console.WriteLine($"File: {fileNameJson} \n {productsJson}");


            //Сортировка
            SortingShoppingList.Sort(shoppingList, SortingShoppingList.BelowByFinalCost);
            Console.WriteLine($"Sorting the final price in ascending order: \n{shoppingList}");

            SortingShoppingList.Sort(shoppingList, SortingShoppingList.DescendingByCost);
            Console.WriteLine($"Sorting price in descending order: \n{shoppingList}");


            //Фильтрация с помощью лямбды-выражения
            List<Product> shoppingList1 = SortingShoppingList.Search(shoppingList, firstSearchValue, (Product product, string searchValue) => product.ProductName.Contains(searchValue, StringComparison.OrdinalIgnoreCase));

            Console.WriteLine($"Search {firstSearchValue}:");
            foreach (Product product in shoppingList1)
            {
                Console.WriteLine(product);
            }


            //Фильтрация с помощью анонимного метода
            SortingShoppingList.SearchDelegate searchDelegateByName = delegate (Product product, string searchValue)
            {
                return product.ProductName.Contains(searchValue, StringComparison.OrdinalIgnoreCase);
            };

            List<Product> shoppingList2 = SortingShoppingList.Search(shoppingList, secondSearchValue, searchDelegateByName);

            Console.WriteLine($"\nSearch {secondSearchValue}:");
            foreach (Product product in shoppingList2)
            {
                Console.WriteLine(product);
            }

            // Lab 10
            
            TaskManager taskManager = new TaskManager();         
            ShoppingList productList = new ShoppingList();

        }
    }
}