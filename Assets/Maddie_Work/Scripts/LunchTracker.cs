using UnityEngine;

public enum FoodGroup
{
    FruitVeg,
    Starchy,
    Protein,
    Dairy,
    OilsSpreads,
    Sugary
}

public static class LunchTracker
{
    public const int GroupCount = 6;

    private static int[] counts = new int[GroupCount];

    public static void Add(FoodGroup group)
    {
        counts[(int)group]++;
        Debug.Log("Added " + group + ". Total now: " + counts[(int)group]);
    }

    public static int GetCount(FoodGroup group)
    {
        return counts[(int)group];
    }

    public static void ResetCounts()
    {
        counts = new int[GroupCount];
    }
}