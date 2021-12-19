using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleObject : MonoBehaviour
{
    private bool solved = false;
    public string requiredKey;

    public GameObject solvedPuzzle;
    public int ID;

    public bool disableAfterSolve;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        solved = ProgressManager.puzzleStatuses[ID];
        
        if (solved) {
            if (disableAfterSolve) {
                GetComponent<MeshRenderer>().enabled = false;
                GetComponent<Collider>().enabled = false;
            }
            solvedPuzzle.SetActive(true);
        }
    }

    public bool isSolved() {
        return ProgressManager.puzzleStatuses[ID];
    }

    public string getRequiredKey() {
        return requiredKey;
    }

    public void solve() {
        ProgressManager.solveAnother();
        ProgressManager.puzzleStatuses[ID] = true;
    }
}
