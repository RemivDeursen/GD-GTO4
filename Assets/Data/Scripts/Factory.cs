using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Factory : MonoBehaviour
{
    public GameObject prefab;

    public List<ResourceCost> resourceCostList = new List<ResourceCost>();

    public void SpawnCube(Tile tile)
    {
        bool enoughResources = true;
        foreach (ResourceCost item in resourceCostList)
            if (item.cost > item.resources.currentValue) enoughResources = false;
        foreach (ResourceCost item in resourceCostList)
            if (enoughResources)
            {
                item.resources.RemoveAmmount();
            }
        if (enoughResources)
        {
                if (!tile.occupied)
                {
                    GameObject cube = Instantiate(prefab, new Vector3(tile.transform.position.x, 0, tile.transform.position.z), Quaternion.identity);
                    cube.transform.SetParent(tile.transform);
					cube.GetComponent<Renderer>().material.color = this.transform.GetComponentInParent<Player>().playerColor.color;
                    tile.occupied = true;
                    return;
                }
            /*foreach (Tile tile in grid.GetTiles())
            {
            }*/
        }
    }

    [System.Serializable]
    public struct ResourceCost
    {
        public ResourceController resources;
        public float cost;
    }
}
