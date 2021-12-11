// using System.Collections;
// using System.Collections.Generic;
using UnityEngine;

// Stores all progress variables
public static class ProgressManager
{
    public static int numSolvedPuzzles = 0;
    public static int totalPuzzles = 3;
    public static string inventoryItem;
    public static bool[] puzzleStatuses = {false, false, false};

    public static void solveAnother() {
        if (numSolvedPuzzles < totalPuzzles) {
            numSolvedPuzzles = numSolvedPuzzles + 1;
            Debug.Log("Solved puzzle count: " + numSolvedPuzzles);

        } else {
            Debug.Log("Oops: max puzzles exceeded");
        }
    }

    public static bool isCompleted() {
        if (numSolvedPuzzles == totalPuzzles) {
            return true;
        } else {
            return false;
        }
    }
}