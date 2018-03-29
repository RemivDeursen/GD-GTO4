using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ResourceController : MonoBehaviour
{
    public float startingAmmount = 20;
    public float currentValue;
    public UnityEvent changeEvent = new UnityEvent();
    private UnityAction addEvent;
    private UnityAction removeEvent;
    void Start()
    {
        currentValue = startingAmmount;
        changeEvent.Invoke();
    }

    public void AddAmmount()
    {
        currentValue += 10;
        changeEvent.Invoke();
    }

    public void RemoveAmmount()
    {
        if (currentValue > 0)
        {
            currentValue -= 10;
            changeEvent.Invoke();
        }
    }
}
