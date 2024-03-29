﻿using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class Model : MonoBehaviour
{
    public float startingAmmount = 20;
    public float currentValue;
    public UnityEvent changeEvent = new UnityEvent();

    public float CurrentValue
    {
        get { return currentValue; }
        set
        {
            currentValue = value;
            changeEvent.Invoke();
            print("Model: Add 2");
        }
    }

    private UnityAction addEvent;
    private UnityAction removeEvent;
    public ResourceController ResourceController;


    // Use this for initialization
    void Start()
    {
        addEvent += AddAmmount;
        removeEvent += RemoveAmmount;
        CurrentValue = startingAmmount;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void AddAmmount()
    {
        CurrentValue += 10;
        print("Model: Add");
    }

    public void RemoveAmmount()
    {
        if (currentValue > 0)
        {
            CurrentValue -= 10;
        }
    }

}