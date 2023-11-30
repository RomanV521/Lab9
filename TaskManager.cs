using Lab8;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace Lab9
{
    internal class TaskManager
    {

    }
    public static Task Generate(ShoppingList shoppingList)
    {
        Task[] tasks = new Task[4];
        Stopwatch stopwatch = new Stopwatch();
        int length = shoppingList.ProductList.Count;
        int countItems = length / 4;
        for (int i = 0; i < tasks.Length; i++)
        {
            stopwatch.Start();
            int startIndex = i * countItems;
            int endIndex = (i == 3) ? length : (i + 1) * countItems;

            tasks[i] = GenerateShoppingList(shoppingList, startIndex, endIndex);
            stopwatch.Stop();
            Console.WriteLine($"Время создания массива пользователей: {stopwatch.ElapsedMilliseconds} мс");
        }
    }

    private Task GenerateShoppingList(ShoppingList shoppingList, int startIndex, int endIndex)
    {
        
        if (shoppingList is not null)
        {
            DataStore ds = new DataStore();
            for (int i = startIndex; i < endIndex; i++)
            {
                shoppingList.AddProduct(ds.CreateProductRecord());
            }
            return Task.CompletedTask;
        }
        else 
        {
            throw new ArgumentNullException();
        }
    }

    private static void ParallelSort(List<Product> products, int countTasks)
    {
        Task[] tasks = new Task[countTasks];
        var countItems = products.Count / countTasks;
        for(int i = 0; i < tasks.Length; i++)
        {
            int startIndex = i * countItems;
            int endIndex = (i == 3) ? products.Count : (i + 1) * countItems;

            tasks[i] = Sort(products, startIndex, endIndex);
        }
    }


}
