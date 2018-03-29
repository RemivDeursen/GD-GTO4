using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class UnitSpawner : MonoBehaviour
{
    private Factory factory;
    private bool isBuilding = false;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (factory != null && isBuilding)
        {
            if (Input.GetMouseButtonUp(0))
            {
				if (EventSystem.current.IsPointerOverGameObject())
				{
					Debug.Log("Mouse was over UI");
					return;
				}
                if (Physics.Raycast(ray, out hit))
                {
                    Tile hitTile = hit.collider.GetComponentInParent<Tile>();
                    if (hitTile != null)
                    {
                        if (!hitTile.occupied)
                        {
                            factory.SpawnCube(hitTile);
                            ExitSpawnMode();
                        }
                    }

                }
            }
        }
    }

    private void OnDisable()
    {
        ExitSpawnMode();
    }

    private void ExitSpawnMode()
    {
        factory = null;
        isBuilding = false;
    }

    public void EnterSpawnMode(Factory factory)
    {
        this.factory = factory;
        isBuilding = true;
    }
}
