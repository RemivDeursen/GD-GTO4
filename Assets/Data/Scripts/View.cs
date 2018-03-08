using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class View : MonoBehaviour
{
    public Model Model;
    private Text DataText;
    private UnityAction updateText;
    // Use this for initialization
    void Start ()
    {
        updateText += UpdateText;
        DataText = this.GetComponent<Text>();
	    Model.changeEvent.AddListener(updateText);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void UpdateText()
    {
        DataText.text = Model.CurrentValue.ToString();
        print("test");
    }
}
