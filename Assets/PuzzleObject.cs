using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleObject : MonoBehaviour
{
    private bool solved = false;
    public string requiredKey;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
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
