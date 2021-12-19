// using System.Collections;
// using System.Collections.Generic;
using UnityEngine;

// Stores all progress variables
public static class ProgressManager
{
    public static int numSolvedPuzzles = 0;
    public static int totalPuzzles = 4;

    // Rlly not the best way of doing this but change # array items depending on # puzzles
    // Time constraints - try to fix this later...if ur reading this im sorry
    public static string[] inventoryItem = {"", "", "", "", "", "", ""};
    public static string[] prevGrabbedThings = {"", "", "", "", "", "", ""}; // Track previously grabbed things
    public static bool[] puzzleStatuses = {false, false, false, false};

    public static Vector3 overworldSpawnPoint = new Vector3(354, 7, 191);
    public static bool isSpawnInOverworld = false;

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

    public static bool hasItem(string wantedItem) {
        foreach (string item in inventoryItem) {
            if (item == wantedItem) {
                return true;
            }
        }
        return false;
    }

    public static bool hasGrabbed(string wantedItem) {
        foreach (string item in prevGrabbedThings) {
            if (item == wantedItem) {
                return true;
            }
        }
        return false;
    }

    public static void pickUp(string newItem) {
        addToInventory(newItem);
        addToGrabbedThings(newItem);

        Debug.Log("Inventory: ");
        foreach (string item in inventoryItem) {
            if (item != "") {
                Debug.Log(item);
            }
        }

        if (newItem == "wood1" || newItem == "wood2" || newItem == "wood3") { // Also a bad way of doing this...fix later
            int woodCount = 0;
            foreach (string item in inventoryItem) {
                if (item == "wood1" || item == "wood2" || item == "wood3") {
                    woodCount ++;
                }
            }
            Debug.Log("Wood amount: " + woodCount);

            if (woodCount == 3) {
                addToInventory("allTheWood");
                addToGrabbedThings("allTheWood");
            }
        }
    }

    static void addToInventory(string newItem) {
        for (int i = 0; i < inventoryItem.Length; i++) {
            if (inventoryItem[i] == "") {
                inventoryItem[i] = newItem;
                return;
            }
        }
    }

    static void addToGrabbedThings(string newItem) {
        for (int i = 0; i < prevGrabbedThings.Length; i++) {
            if (prevGrabbedThings[i] == "") {
                prevGrabbedThings[i] = newItem;
                return;
            }
        }
    }

    public static void removeItem(string item) {
        for (int i = 0; i < inventoryItem.Length; i++) {
            if (inventoryItem[i] == item) {
                inventoryItem[i] = "";
            }
        }
    }
}