using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Selectable : MonoBehaviour {
	public Material selectedMat;
	public Material deselectedMat;
	public Material hoverMat;
	private bool isSelected;
	void Start () {
	}

	void OnMouseOver()
	{
		if (!isSelected)
		{
			this.GetComponent<Renderer>().material = hoverMat;
		}
	}

	private void OnMouseExit() {
		if (!isSelected)
		{
			this.GetComponent<Renderer>().material = deselectedMat;
		}
	}

	public void Select(){
		isSelected = true;
		this.GetComponent<Renderer>().material = selectedMat;
	}
	public void Deselect(){
		isSelected = false;
		this.GetComponent<Renderer>().material = deselectedMat;
	}
}
