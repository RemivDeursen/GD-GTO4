using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class View : MonoBehaviour
{
    public ResourceController Model;
    private Text DataText;
    private UnityAction updateText;
    // Use this for initialization
    void Awake ()
    {
        updateText += UpdateText;
        DataText = this.GetComponent<Text>();
	    Model.changeEvent.AddListener(updateText);
	}

    void UpdateText()
    {
        DataText.text = Model.currentValue.ToString();
    }
}
