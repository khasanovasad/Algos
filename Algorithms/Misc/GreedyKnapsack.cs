using System;
using System.Collections.Generic;

namespace Algorithms.Misc;

public static class GreedyKnapsack
{
    private class Item
    {
        public int Value { get; set; }
        public int Weight { get; set; }
        public double Ratio => (double)Value / (double)Weight;

        public Item(int value, int weight)
        {
            Value = value;
            Weight = weight;
        }
    }

    private class CustomComparer : IComparer<Item>
    {
        public int Compare(Item x, Item y)
        {
            if (x.Ratio < y.Ratio)
            {
                return 1;
            }
            else if (x.Ratio > y.Ratio)
            {
                return -1;
            }
            else
            {
                return 0;
            }
        }
    }

    private static Item[] GenerateItemsArray(int[] values, int[] weights)
    {
        var items = new Item[values.Length];
        for (int i = 0; i < values.Length; ++i)
        {
            items[i] = new Item(value: values[i], weight: weights[i]);
        }

        return items;
    }

    public static double Calculate(int[] values, int[] weights, int maxWeight)
    {
        Item[] items = GenerateItemsArray(values, weights);
        var comparer = new CustomComparer();

        Array.Sort(items, comparer);

        double totalValue = 0f;
        int currentWeight = 0;
        foreach (var item in items)
        {
            double remainder = maxWeight - currentWeight;

            if (item.Weight <= remainder)
            {
                totalValue += item.Value;
                currentWeight += item.Weight;
            }
            else
            {
                if (remainder == 0)
                {
                    break;
                }

                double fraction = remainder / (double)item.Weight;
                totalValue += fraction * (double)item.Value;
                currentWeight += (int)(fraction * (double)item.Weight);
            }
        }

        return totalValue;
    }
}