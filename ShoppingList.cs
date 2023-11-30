using System;
using System.Text;
using System.Text.Json.Serialization;

namespace Lab8
{
    [Serializable]
    class ShoppingList
    {
        private List<Product> _productList;

        public List<Product> ProductList
        {
            get { return _productList; }
            set { _productList = value; }
        }

        public ShoppingList() { }
        /// <summary>
        /// Инициализация листа с помощью заполненого , либо пустого массива продуктов
        /// </summary>
        /// <param name="products">Перечень продуктов</param>
        public ShoppingList(params Product[] products) 
        {
            if (products is not null)
            {
                List<Product> list = new List<Product>();
                foreach (Product product in products)
                {
                    list.Add(product);
                }
                ProductList = list;
            }
            else 
            { 
                ProductList = new List<Product>(); 
            }
        }

        /// <summary>
        /// Добавление объекта Product в лист
        /// </summary>
        /// <param name="product">Новый объект класса Produc</param>
        public void AddProduct(Product product) 
        {
            if (_productList is not null)
            {
                ProductList.Add(product);
            }
            else
            {
                throw new ArgumentNullException();
            }
        }

        /// <summary>
        /// Удаление объекта Product из лист при помощи его id
        /// </summary>
        /// <param name="index">id удаляемого объекта</param>
        public void RemoveProduct(int index) 
        {
            if(index >= 0 && index < ProductList.Count)
            {
                ProductList.RemoveAt(index);
            }
            else 
            { 
                throw new ArgumentOutOfRangeException(); 
            }
        }

        /// <summary>
        /// Удаление объекта Product из лист используя сам объект
        /// </summary>
        /// <param name="product">Удаляемый объект класса Product</param>
        public void RemoveProduct(Product product)
        {
            if (product is not null)
            {
                ProductList.Remove(product);
            }
            else
            {
                throw new ArgumentNullException();
            }
        }

        /// <summary>
        /// Вывод данных
        /// </summary>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            foreach (Product product in ProductList)
            {
                sb.Append(product+"\n");
            }
            return "Shopping List:\n" + sb;
        }
    }
}
