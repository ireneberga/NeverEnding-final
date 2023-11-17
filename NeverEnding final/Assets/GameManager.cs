using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // Singleton instance for easy access from other scripts
    public static GameManager instance;

    // Game mode: 0 - Free 1st person gameplay, 1 - UI interactions
    public int gameMode = 0;

    private void Awake()
    {
        // Singleton pattern
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}