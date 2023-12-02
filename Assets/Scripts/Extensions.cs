using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Extensions
{
    public static void Shuffle<T>(this List<T> list)
    {
        // Loop through all cards and randomize them
        for (int i = 0; i < list.Count; ++i)
        {
            // Return card between 0 and card 
            int randomIndex = UnityEngine.Random.Range(0, list.Count);
            list[i] = list[randomIndex];
            list.RemoveAt(randomIndex); // Remove card from original deck
        }
    }
}
