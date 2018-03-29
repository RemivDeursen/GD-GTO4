using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Selection : MonoBehaviour
{
    private Tile currentSelection;
    private Tile moveSelection;
    public TurnManager turnManager;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonUp(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                if (currentSelection == null)
                {
                    currentSelection = hit.collider.GetComponentInParent<Tile>();
                    OnCurrentSelection();
                }
                else if (moveSelection == null)
                {
                    Debug.Log("MoveSelection");
                    moveSelection = hit.collider.GetComponentInParent<Tile>();
                    OnMoveSelection();
                }
            }
            else
            {
                if (currentSelection != null)
                {
                    Debug.Log("DeselectAll");
                    DeselectAll();
                }
            }
        }
    }
    private void OnCurrentSelection()
    {
        if (currentSelection != null)
        {
            if (currentSelection.occupied)
            {
                if (currentSelection.unit.player.playerId == turnManager.currentPlayer.playerId)
                {
                    Debug.Log("CurrentID: " + currentSelection.unit.player.playerId + " TargetID: " + turnManager.currentPlayer.playerId);
                    currentSelection.transform.GetComponent<Selectable>().Select();
                }
            }
            else
            {
                currentSelection = null;
            }
        }
    }

    private void OnMoveSelection()
    {
        if (!turnManager.hasMoved)
        {
            if (currentSelection.unit.player.playerId == turnManager.currentPlayer.playerId)
            {
                if (moveSelection != null)
                {
                    if (!moveSelection.occupied)
                    {
                        if (currentSelection.unit.Move(moveSelection))
                        {
                            turnManager.addAction("movement");
                        }
                    }
                }
            }
        }
        DeselectAll();
    }
    private void DeselectAll()
    {
        if (currentSelection != null)
        {
            currentSelection.transform.GetComponent<Selectable>().Deselect();
        }
        if (moveSelection != null)
        {
            moveSelection.transform.GetComponent<Selectable>().Deselect();
        }
        currentSelection = null;
        moveSelection = null;
    }
}
