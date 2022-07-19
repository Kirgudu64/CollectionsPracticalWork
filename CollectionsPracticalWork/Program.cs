//
// Коллекции
// Практическая работа
//
// Цель:
// Работа с различными типами коллекций
// Практические навыки сериализации и десериализации отбъектов
//

using System.Xml.Linq;

/// <summary>
/// Вывод заголовка модуля в консоль
/// </summary>
/// <param name="Text">Текст заголовка</param>
/// 
static void Heading(string Text)
{
    Console.Clear();
    Console.WriteLine($"\n\t{Text}");
}

/// <summary>
/// Заполнение листа случайными числами
/// </summary>
/// <param name="Number">Лист</param>
/// <param name="Start">Начало диапазона случайных чисел</param>
/// <param name="End">Конец диапазона случайных чисел</param>
static void Addendum(List<int> Number, int Start, int End)
{
    Random random = new Random();
    for (int i = 0; i < 100; i++)
    {
        Number.Add(random.Next(Start, End));
    }
}

/// <summary>
/// Вывод листа в консоль
/// </summary>
/// <param name="Number">Лист</param>
static void PrintToConsile(List<int> Number)
{
    Console.WriteLine();
    foreach (int element in Number)
    {
        Console.Write($"{element} : ");
    }
}

/// <summary>
/// Удаляем все числа, которые больше 25, но меньше 50
/// </summary>
/// <param name="Number">Лист</param>
static void DeleteNum(ref List<int> Number)
{
    for (int i = 0; i < Number.Count; i ++)
    {
        if (Number[i] >= 25 && Number[i] <= 50)
        {
            Number.RemoveAt(i);
        }
    }
}

/// <summary>
/// Заполняем телефонную книгу
/// </summary>
/// <param name="pairs">Телефонная книга</param>
static void AddPhoneBook(Dictionary<string, string> pairs)
{
    while (true)
    {
        Console.Write("\n Номер телефона: ");
        string phone = Console.ReadLine();
        if (phone == "") { break; }
        Console.Write(" Фамилия Имя Отчество: ");
        string name = Console.ReadLine();
        pairs.Add(phone, name);
    }
}

/// <summary>
/// Ищем владельца по номеру телефона
/// </summary>
/// <param name="pairs">Телефонная книга</param>
/// <param name="phoneKey">Номер телефона для поиска</param>
static void ToFind(Dictionary<string, string> pairs, string phoneKey)
{
    if (pairs.ContainsKey(phoneKey))
    {
        Console.WriteLine($"Владелец телефона: {pairs[phoneKey]}");
    }
    else
    {
        Console.WriteLine($"В телефонной книге нет номера телефона: {phoneKey}");
    }
}


byte exit = 0;

while(exit != 1)
{
    Console.Clear();
    Console.WriteLine($"\n\tМЕНЮ:\n\t=====\n\n\t1 - Работа с листом\n\t2 - Телефонная книга" +
        $"\n\t3 - Проверка повторов\n\t4 - Записная книжка\n\t0 - Выход");
    Console.Write($"\n\tВыберите пункт МЕНЮ: ");
        
    var numMenu = Console.ReadLine();

        switch (numMenu)
        {
            case "0":         // Выход из программы
                {
                    exit = 1;
                    break;
                }
            case "1":         // Работа с листом
                {
                Heading("Работа с листом");
                List<int> list = new List<int>();
                Addendum(list, 0, 99);
                PrintToConsile(list);
                Console.WriteLine("\n\n === Удаляем все числа, которые больше 25, но меньше 50 ===");
                DeleteNum(ref list);
                PrintToConsile(list);
                Console.ReadKey();                
                break;
                }
            case "2":         // Телефонная книга
                {
                Heading("Телефонная книга");
                Dictionary<string, string> phoneBook = new Dictionary<string, string>();
                Console.WriteLine("\n === Заполняем телефонную книгу ===\n");               
                AddPhoneBook(phoneBook);
                Console.WriteLine("\n === Ищем владельца по номеру телефона ===\n");                
                bool key = true;
                while (key)
                {
                    Console.Write("Введите номер телефона: ");
                    string phone = Console.ReadLine(); ToFind(phoneBook, phone);
                    Console.Write("\nПродолжить поиск (д/н): ");
                    var pr = Console.ReadLine();
                    if (pr == "н") key = false;
                }                                
                break;
                }
            case "3":         // Проверка повторов
                {
                Heading("Проверка повторов");
                HashSet<int> ints = new HashSet<int>();
                bool key = true;
                while (key)
                {
                    Console.Write("Введите число: ");
                    int num = Convert.ToInt32(Console.ReadLine());
                    if (ints.Contains(num))
                    {
                        Console.WriteLine($"Число {num} вводилось ранее");
                    }
                    else
                    {
                        ints.Add(num);
                        Console.WriteLine($"Число {num} успешно сохранено");
                    }                    
                    Console.Write("\nПродолжить (д/н): ");
                    var pr = Console.ReadLine();
                    if (pr == "н") key = false;                    
                }
                Console.Write("Показать введенную последовательность (д/н): ");
                var keyPrint = Console.ReadLine();
                if (keyPrint == "д")
                {
                    foreach (int i in ints) { Console.Write($"{i} : "); }
                }
                Console.ReadKey();
                break;
                }
            case "4":         // Записная книжка
                {
                Heading("Записная книжка");
                                
                string path = "notebook.xml";
                                
                XDocument xdoc = new XDocument();
                XElement noteBook = new XElement("NoteBook");
                
                int counter = 0;
                bool key = true;
                while (key)
                {
                    XElement person = new XElement("Person");
                    XElement address = new XElement("Address");
                    XElement phones = new XElement("Phoness");
                                      
                    Console.Write("Фамилия Имя Отчество: ");
                    XAttribute nameAttr = new XAttribute("name", Console.ReadLine());                    
                    Console.WriteLine("Адрес:");
                    Console.Write("\tУлица: ");                    
                    XElement streetElem = new XElement("Street", Console.ReadLine());
                    Console.Write("\tДом: ");
                    XElement houseNumberElem = new XElement("HouseNumber", Console.ReadLine());
                    Console.Write("\tКвартира: ");
                    XElement flatNumberElem = new XElement("FlatNumber", Console.ReadLine());
                    Console.WriteLine("Телефон:");
                    Console.Write("\tМобильный: ");
                    XElement mobilePhoneElem = new XElement("MobilePhone", Console.ReadLine());
                    Console.Write("\tДомашний: ");
                    XElement flatPhoneElem = new XElement("FlatPhone", Console.ReadLine());

                    address.Add(streetElem, houseNumberElem, flatNumberElem);
                    phones.Add(mobilePhoneElem, flatPhoneElem);
                    person.Add(nameAttr, address, phones);
                    
                    noteBook.Add(person);
                                        
                    counter++;

                    Console.Write("\nПродолжить (д/н): ");
                    var pr = Console.ReadLine();
                    if (pr == "н") key = false;
                    Console.Clear();
                }
                xdoc.Add(noteBook);
                xdoc.Save(path);
                Console.WriteLine($"Всего записей {counter}. Данные записаны в файл {path}");

                Console.ReadKey();
                break;
                }
            default:
                {
                    Console.WriteLine("Вы ошиблись при выборе пункта МЕНЮ.");
                    break;
                }
        }    
}