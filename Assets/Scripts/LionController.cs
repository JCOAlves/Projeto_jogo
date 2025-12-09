using UnityEngine;
using UnityEngine.Tilemaps;

public class LionController : MonoBehaviour
{
    [SerializeField] private Tilemap tilemap;

    private void Update()
    {
        Debug.Log(tilemap.GetTile(new Vector3Int(0, 2, 0)).name);
    }
}