using System;

namespace OrderManagement
{
    class Program
    {
        static int ReadInt(string text)
        {
            while (true)
            {
                Console.Write(text);
                string input = Console.ReadLine();
                int value;

                if (int.TryParse(input, out value))
                {
                    return value;
                }

                Console.WriteLine("Ошибка: введите целое число");
            }
        }

        static void ShowMenu()
        {
            Console.WriteLine("===== Система обработки заказов =====");
            Console.WriteLine("1. Показать товары");
            Console.WriteLine("2. Создать заказ");
            Console.WriteLine("3. Подтвердить заказ");
            Console.WriteLine("4. Перевести заказ в обработку");
            Console.WriteLine("5. Отправить заказ");
            Console.WriteLine("6. Отметить заказ доставленным");
            Console.WriteLine("7. Отменить заказ");
            Console.WriteLine("8. Показать заказ по номеру");
            Console.WriteLine("9. Показать все заказы");
            Console.WriteLine("10. Статистика заказов");
            Console.WriteLine("0. Выход");
        }

        static void ChangeStatusMenu(Store store, OrderStatus status)
        {
            int orderId = ReadInt("Номер заказа: ");
            store.MoveOrder(orderId, status);
        }

        static void Main(string[] args)
        {
            Product[] products = new Product[5];

            products[0] = new Product(1, "Ноутбук", 450000, 5, ProductCategory.Electronics);
            products[1] = new Product(2, "Футболка", 7000, 40, ProductCategory.Clothing);
            products[2] = new Product(3, "Хлеб", 150, 100, ProductCategory.Food);
            products[3] = new Product(4, "Учебник C#", 12000, 15, ProductCategory.Books);
            products[4] = new Product(5, "Рюкзак", 18000, 12, ProductCategory.Other);

            Store store = new Store(products, 50);

            bool running = true;

            while (running)
            {
                ShowMenu();
                int choice = ReadInt("Выберите пункт: ");
                Console.WriteLine();

                switch (choice)
                {
                    case 1:
                        store.ShowProducts();
                        break;
                    case 2:
                        store.ShowProducts();
                        Console.Write("ФИО покупателя: ");
                        string customerName = Console.ReadLine();
                        int productId = ReadInt("Id товара: ");
                        int quantity = ReadInt("Количество: ");
                        store.CreateOrder(customerName, productId, quantity);
                        break;
                    case 3:
                        ChangeStatusMenu(store, OrderStatus.Confirmed);
                        break;
                    case 4:
                        ChangeStatusMenu(store, OrderStatus.Processing);
                        break;
                    case 5:
                        ChangeStatusMenu(store, OrderStatus.Shipped);
                        break;
                    case 6:
                        ChangeStatusMenu(store, OrderStatus.Delivered);
                        break;
                    case 7:
                        ChangeStatusMenu(store, OrderStatus.Cancelled);
                        break;
                    case 8:
                        store.ShowOrder(ReadInt("Номер заказа: "));
                        break;
                    case 9:
                        store.ShowAllOrders();
                        break;
                    case 10:
                        store.ShowStatusCounts();
                        Console.WriteLine($"Общая стоимость всех заказов: {store.GetTotalOrdersAmount()}");
                        break;
                    case 0:
                        running = false;
                        break;
                    default:
                        Console.WriteLine("Ошибка: нет такого пункта меню");
                        break;
                }

                Console.WriteLine();
            }
        }
    }
}
