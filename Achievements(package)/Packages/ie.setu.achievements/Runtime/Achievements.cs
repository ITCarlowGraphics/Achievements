using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Achievements : MonoBehaviour
{
    private Dictionary<string, Action<int>> eventDictionary = new Dictionary<string, Action<int>>();

    public static Achievements _instance;

    private int QuestionCorrectByCurrentPlayer = 0;

    public static Achievements Instance
    {
        get
        {
            if (_instance == null)
            {
                // Check if an existing achievemnts is present in the scene
                _instance = FindObjectOfType<Achievements>();

                if (_instance == null)
                {
                    // No existing achievemnts found, so create a new achievemnts and add this script
                    GameObject a = new GameObject("Achievemnts");
                    _instance = a.AddComponent<Achievements>();

                    // Optionally, make this object persistent
                    DontDestroyOnLoad(a);
                }
            }
            return _instance;
        }
    }

    public static void recordEvent(int i)
    {
        Debug.Log("Hey");
    }
}

