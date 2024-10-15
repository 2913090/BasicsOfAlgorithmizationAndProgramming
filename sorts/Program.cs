// See https://aka.ms/new-console-template for more information
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Reflection;
using static System.Runtime.InteropServices.JavaScript.JSType;

List<int> list1 = new List<int> { 4, 78, 5, 8, 2, 0, 9 };
List<int> list2 = new List<int> { 4, 78, 5, 8, 2, 0, 9 };
List<int> list3 = new List<int> { 4, 78, 5, 8, 2, 0, 9 };
List<int> list4 = new List<int> { 4, 78, 5, 8, 2, 0, 9 };
ShowList(list1);

BubbleSort(ref list1);
ShowList(list1);

Console.WriteLine(list1.BinarSearch(8));

InsertSort(ref list2);
ShowList(list2);

FastSort(ref list3);
ShowList(list3);

MergeSort(ref list4);
ShowList(list4);














void ShowList(List<int> list)
{
    Console.Write("\n|");
    foreach (int i in list)
    {
        Console.Write(i+"|");
    }
    Console.Write("\n\n\n");
}


void BubbleSort(ref List<int> list)
{
    int counter = 0;
    for (int i = list.Count - 1; i >= 0; i--)
    {
        for (int j = 0; j < i; j++)
        {
            if (list[j]> list[j + 1])
            {
                list.swap(j, j + 1);
            }        
            counter++;
        }
    }
    Console.WriteLine("Сортировка пузырьком");
    Console.WriteLine("Сложность алгоритма O(n)=n^2");
    Console.WriteLine($"Длина массива: {list.Count}");
    Console.Write($"Количество действий: {counter}");
}


void InsertSort(ref List<int> list)
{    
    int curNum1;
    int curNum2;
    int counter = 0;
    for (int i = 1; i < list.Count; i++)
    {
        for (int j = i; j > 0 && list[j - 1] > list[j]; j--)
        {
            list.swap(j - 1, j);
            counter++;
        }
    }
    Console.WriteLine("Сортировка вставками");
    Console.WriteLine("Сложность алгоритма O(n)=n^2");
    Console.WriteLine($"Длина массива: {list.Count}");
    Console.Write($"Количество действий: {counter}");
}


void FastSort(ref List<int> list)
{
    int counter = 0;
    FastSortRecursive(ref list, 0, list.Count - 1, ref counter);
    Console.WriteLine("Быстрая сортировка");
    Console.WriteLine("Сложность алгоритма O(n)=n^2");
    Console.WriteLine($"Длина массива: {list.Count}");
    Console.Write($"Количество действий: {counter}");
}

void FastSortRecursive(ref List<int> list, int left, int right, ref int counter)
{
    if (left< right)
    {
        int pivot = createPivot(ref list, left, right, ref counter);
        FastSortRecursive(ref list, left, pivot - 1, ref counter);
        FastSortRecursive(ref list, pivot + 1, right, ref counter);
    }
}

int createPivot(ref List<int> list, int left, int right, ref int counter)
{
    int pivot = left - 1;
    for (int i = left; i < right; i++)
    {
        if (list[i] < list[right])
        {
            pivot++;
            list.swap(pivot, i);
            counter++;
        }
    }
    pivot++;
    counter++;
    list.swap(pivot, right);
    return pivot;
}


void MergeSort(ref List<int> list)
{
    int counter = 0;
    MergeSortRecursive(ref list, 0, list.Count - 1, ref counter);
    Console.WriteLine("Сортировка слиянием");
    Console.WriteLine("Сложность алгоритма O(n)=n log n");
    Console.WriteLine($"Длина массива: {list.Count}");
    Console.Write($"Количество действий: {counter}");
}

void MergeSortRecursive(ref List<int> list, int left, int right, ref int counter)
{
    if (left < right)
    {
        var middleIndex = (left + right) / 2;
        MergeSortRecursive(ref list, left, middleIndex, ref counter);
        MergeSortRecursive(ref list, middleIndex + 1, right, ref counter);
        Merge(ref list, left, middleIndex, right, ref counter);
    }
}

void Merge(ref List<int> list, int left, int middle, int right, ref int counter)
{
    int curLeft = left;
    int curRight = middle + 1;
    int[] newList = new int[right - left + 1];
    int index = 0;

    while ((curLeft <= middle) && (curRight <= right))
    {
        if (list[curLeft] < list[curRight])
        {
            newList[index] = list[curLeft];
            curLeft++;
        }
        else
        {
            newList[index] = list[curRight];
            curRight++;
        }
        counter++;
        index++;
    }

    for (var i = curLeft; i <= middle; i++)
    {
        newList[index] = list[i];
        index++;
    }

    for (var i = curRight; i <= right; i++)
    {
        newList[index] = list[i];
        index++;
    }

    for (var i = 0; i < newList.Length; i++)
    {
        list[left + i] = newList[i];
    }
}





public static class List
{
    public static void swap(this IList<int> list, int num1, int num2)
    {
        int swaper = list[num1];
        list[num1] = list[num2];
        list[num2] = swaper;
    }

    public static int BinarSearch(this List<int> list, int searchNum)
    {
        return BinarSearchRecursive(list, searchNum, 0, list.Count - 1);
    }
    private static int BinarSearchRecursive(this List<int> list, int searchNum, int left, int right)
    {
        int mid;
        mid = (left + right) / 2;
        if (list[mid] == searchNum)
        {
            return mid;
        }
        else if (list[mid] < searchNum)
            left = mid + 1;
        else if (list[mid] > searchNum)
            right = mid - 1;
        return BinarSearchRecursive(list, searchNum, left, right);
    }
}