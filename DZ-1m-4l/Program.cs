//Цель:

//Сделать сравнение по скорости работы List, ArrayList и LinkedList.
//Описание/Пошаговая инструкция выполнения домашнего задания:

//    Создать коллекции List, ArrayList и LinkedList.
//    С помощью цикла for добавить в каждую 1 000 000 элементов (1,2,3,...).
//    С помощью Stopwatch.Start() и Stopwatch.Stop() замерить длительность заполнения каждой коллекции и вывести значения на экран.
//    Найти 496753-ий элемент, замерить длительность этого поиска и вывести на экран.
//    Вывести на экран каждый элемент коллекции, который без остатка делится на 777. Вывести длительность этой операции для каждой коллекции.


using System.Collections;
using System.Diagnostics;


//Создание трёх коллекций.
List<int> LInt = new List<int>();

ArrayList LArray = new ArrayList();

LinkedList<int> LinkedLInt = new LinkedList<int>();

//Метод вывода затраченного времени
static void PrintTime(Stopwatch stopWatch)
{
    TimeSpan ts = stopWatch.Elapsed;
    string elapsedTime = String.Format("{0:00}:{1:00}:{2:00}.{3:00}", ts.Hours, ts.Minutes, ts.Seconds, ts.Milliseconds / 10);
    Console.WriteLine("RunTime Hours/Minutes/Seconds/Milliseconds " + elapsedTime);
}

//Методы заполняющие коллекции и замеряющие время заполнения.
static void ListVoid<T>(List<int> list, int x)
{
    Stopwatch stopWatch = new Stopwatch();
    stopWatch.Start();
    for (int i = 0; i < x; i++)
    {
        list.Add(i+1);
    }
    stopWatch.Stop();
    PrintTime(stopWatch);

}

static void LAVoid<T>(ArrayList list, int x)
{
    Stopwatch stopWatch = new Stopwatch();
    stopWatch.Start();
    for (int i = 0; i < 1000000; i++)
    {
        list.Add(i + 1);
    }
    stopWatch.Stop();
    PrintTime(stopWatch);
}


static void LLVoid<T>(LinkedList<int> list, int x)
{
    Stopwatch stopWatch = new Stopwatch();
    stopWatch.Start();
    for (int i = 0; i < 1000000; i++)
    {
        list.AddLast(i + 1);
    }
    stopWatch.Stop();
    
    PrintTime(stopWatch);
}

//Метод поиска и затраченного на это времени
static void SearchVoidList<T>(List<int> list)
{
    Stopwatch stopWatch = new Stopwatch();
    stopWatch.Start();
    Thread.Sleep(10); //Слишком быстро выполняет
    Console.WriteLine(list[496753]);
    stopWatch.Stop();
    PrintTime(stopWatch);
}

static void SearchVoidArrayList(ArrayList list)
{
    Stopwatch stopWatch = new Stopwatch();
    stopWatch.Start();
    Thread.Sleep(10); //Слишком быстро выполняет
    Console.WriteLine(list[496753]);
    stopWatch.Stop();
    PrintTime(stopWatch);
}

static void SearchVoidLinkedList(LinkedList<int> list)
{
    Stopwatch stopWatch = new Stopwatch();
    stopWatch.Start();
    Thread.Sleep(10); //Слишком быстро выполняет
    var currentNode = list.First;
    while (currentNode != null)
    {
        if (currentNode.Value == 496754)
        {
            Console.WriteLine("496754"); 
        }
        currentNode  = currentNode .Next;
    }
    stopWatch.Stop();
    PrintTime(stopWatch);
}
Console.WriteLine();
Console.WriteLine();
Console.WriteLine();


// Методы вывода элементов которые без остатка делятся на 777

static void DivideList<T>(List<int> list, double x)
{
    Console.Write("[");
    Stopwatch stopWatch = new Stopwatch();
    stopWatch.Start();
    for (int i = 0; i < list.Count; i++)
    {
       double y =(int)list[i];

        if (y % x == 0.0)
        {
            Console.Write($"{list[i]}, ");
        }
    }
    stopWatch.Stop();
    Console.WriteLine();
    PrintTime(stopWatch);
    Console.WriteLine("]");
}

static void DivideArrayList<T>(ArrayList list, double x)
{
    Console.Write("[");
    Stopwatch stopWatch = new Stopwatch();
    stopWatch.Start();
    for (int i = 0; i < list.Count; i++)
    {
        double y = (int)list[i];

        if (y % x == 0.0)
        {
            Console.Write($"{list[i]}, ");
        }
    }
    stopWatch.Stop();
    Console.WriteLine();
    PrintTime(stopWatch);
    Console.WriteLine("]");
}

static void DivideLinkedList<T>(LinkedList<int> list, double x)
{
    Console.Write("[");
    var currentNode = list.First;
    Stopwatch stopWatch = new Stopwatch();
    stopWatch.Start();
    while (currentNode != null)
    {
        double y = currentNode.Value;
        if (y % x == 0.0)
        {
            Console.Write($"{y}, ");
        }
        currentNode = currentNode.Next;
    }
    stopWatch.Stop();
    Console.WriteLine();
    PrintTime(stopWatch);
    Console.WriteLine("]");
}




//Вызов методов и вывод в консоль
ListVoid<int>(LInt, 1000000);
Console.WriteLine($"Длина листа = {LInt.Count}");
Console.WriteLine($"Первый элемент листа = {LInt[0]}");
Console.WriteLine($"Последний элемент листа = {LInt[LInt.Count - 1]}");
Console.WriteLine();
LAVoid<int>(LArray, 1000000);
Console.WriteLine($"Длина ArrayList = {LArray.Count}");
Console.WriteLine($"Первый элемент ArrayList = {LArray[0]}");
Console.WriteLine($"Последний элемент ArrayList = {LArray[LArray.Count - 1]}");
Console.WriteLine();
LLVoid<int>(LinkedLInt, 1000000);
Console.WriteLine($"Длина LinkedLis = {LinkedLInt.Count}");
Console.WriteLine($"Первый элемент LinkedLis = {LinkedLInt.First?.Value}");
Console.WriteLine($"Последний элемент LinkedLis = {LinkedLInt.Last?.Value}");
Console.WriteLine();
Console.WriteLine("Поиск List");
SearchVoidList<int>(LInt);
Console.WriteLine("Поиск ArrayList");
SearchVoidArrayList(LArray);
Console.WriteLine("Поиск LinkedList");
SearchVoidLinkedList(LinkedLInt);
Console.WriteLine();
Console.WriteLine();
Console.WriteLine();
Console.WriteLine("Числа делимые без остатка на 777. Из List");
DivideList<int>(LInt, 777);
Console.WriteLine();
Console.WriteLine();
Console.WriteLine();
Console.WriteLine("Числа делимые без остатка на 777. Из ArrayList");
DivideArrayList<int>(LArray, 777);
Console.WriteLine();
Console.WriteLine();
Console.WriteLine();
Console.WriteLine("Числа делимые без остатка на 777. Из LinkedList");
DivideLinkedList<int>(LinkedLInt, 777);
Console.ReadLine();



////Метод для вывода коллекции на экран.
// static void PrintList<T>(List<T> list, string Name = "")
//{
//	if (Name != string.Empty)
//	{
//		Console.Write($"{Name}=");
//	}
//	Console.Write("[");
//	for (var i = 0; i < list.Count; i++)
//	{
//		Console.Write($"{list[i]}, ");
//	}
//	Console.WriteLine("]");
//}