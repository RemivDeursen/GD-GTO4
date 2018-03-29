using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Factory : MonoBehaviour
{
    public Unit prefab;
    public TurnManager turnManager;
    public List<ResourceCost> resourceCostList = new List<ResourceCost>();

    public void SpawnCube(Tile tile)
    {
        if (!turnManager.hasSpawned)
        {
            bool enoughResources = true;
            foreach (ResourceCost item in resourceCostList)
            {
                if (item.cost > item.resources.currentValue)
                {
                    enoughResources = false;
                }
            }
            foreach (ResourceCost item in resourceCostList)
            {
                if (enoughResources)
                {
                    item.resources.RemoveAmmount();
                }
            }
            if (enoughResources)
            {
                if (!tile.occupied)
                {
                    Unit cube = Instantiate(prefab, new Vector3(tile.transform.position.x, 0, tile.transform.position.z), Quaternion.identity);
                    cube.transform.SetParent(tile.transform);
                    cube.GetComponent<Renderer>().material.color = this.transform.GetComponentInParent<Player>().playerColor.color;
                    cube.player = turnManager.currentPlayer;
                    tile.SetUnit(cube);
                    turnManager.addAction("spawn");
                    return;
                }
            }
        }
    }

    [System.Serializable]
    public struct ResourceCost
    {
        public ResourceController resources;
        public float cost;
    }
}
