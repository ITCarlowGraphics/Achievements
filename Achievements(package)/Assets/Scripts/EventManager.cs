using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventManager : MonoBehaviour
{
    private Dictionary<string, Action<int>> eventDictionary = new Dictionary<string, Action<int>>();

    public static EventManager _instance;
    
    public static EventManager Instance
    {
        get
        {
            if (_instance == null)
            {
                // Check if an existing GameManager is present in the scene
                _instance = FindObjectOfType<EventManager>();

                if (_instance == null)
                {
                    // No existing GameManager found, so create a new GameObject and add this script
                    GameObject em = new GameObject("EventManager");
                    _instance = em.AddComponent<EventManager>();

                    // Optionally, make this object persistent
                    DontDestroyOnLoad(em);
                }
            }
            return _instance;
        }
    }

    public void Subscribe(string eventType, Action<int> listener)
    {
        if (!eventDictionary.ContainsKey(eventType))
        {
            eventDictionary.Add(eventType, listener);
        }
        else
        {
            eventDictionary[eventType] += listener;
        }
    }

    public void Unsubscribe(string eventType, Action<int> listener)
    {
        if (eventDictionary.ContainsKey(eventType))
        {
            eventDictionary[eventType] -= listener;
        }
    }

    public void RaiseEvent(string eventType, int param)
    {
        if (eventDictionary.ContainsKey(eventType))
        {
            eventDictionary[eventType]?.Invoke(param);
        }
    }
}

