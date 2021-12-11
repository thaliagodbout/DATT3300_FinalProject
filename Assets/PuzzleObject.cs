using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleObject : MonoBehaviour
{
    static bool solved = false;
    public string requiredKey;

    public GameObject solvedPuzzle;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (solved) {
            GetComponent<MeshRenderer>().enabled = false;
            solvedPuzzle.SetActive(true);
        }
    }

    public bool isSolved() {
        return solved;
    }

    public string getRequiredKey() {
        return requiredKey;
    }

    public void solve() {
        solved = true;
    }
}
