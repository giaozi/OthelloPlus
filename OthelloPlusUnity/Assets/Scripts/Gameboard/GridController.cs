using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
//using WebsocketConnection;
public class GridController : MonoBehaviour
{
    private Grid grid;
    [SerializeField] private Tilemap interactiveMap = null;
    [SerializeField] private Tilemap boardMap = null;
    [SerializeField] private Tile hoverTile = null;
    [SerializeField] private Tile boardTile = null;



    private Vector3Int previousMousePos = new Vector3Int();

    // Start is called before the first frame update
   void Start()
   {
       grid = gameObject.GetComponent<Grid>();
   }

   // Update is called once per frame
   void Update()
   {

       // Mouse over -> highlight tile
       Vector3Int mousePos = GetMouseTilePosition();
       if (!mousePos.Equals(previousMousePos))
       {
            if (!CanPlaceTile(mousePos)) { return; }
            Debug.Log("Replacing @" + mousePos);
            interactiveMap.SetTile(previousMousePos, null); // Remove old hoverTile
            interactiveMap.SetTile(mousePos, hoverTile);
            previousMousePos = mousePos;
       }


       if (Input.GetMouseButtonDown(0))
       {
            Debug.Log("Click");
            Debug.Log("Tile Position @" + GetMouseTilePosition());
            boardMap.SetTile(mousePos, boardTile);
           //WebsocketManager.WebsocketSendText(Input.mousePosition.ToString());
       }

       // Right mouse click -> remove path tile
       if (Input.GetMouseButton(1))
       {
            boardMap.SetTile(mousePos, null);
       }
   }
    Vector3Int GetMouseTilePosition()
    {
        Vector3 mouseWorldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition) + new Vector3Int(0, 0, 10);//10 on Z-axis to offset camera
        Vector3Int mouseGridPos = grid.WorldToCell(mouseWorldPos);
        // Debug.Log("MouseGridPos is" + mouseGridPos);

        return mouseGridPos;
    }

    bool CanPlaceTile(Vector3Int targetPos)
    {
        if (-4 > targetPos.x || 3 < targetPos.x)
            return false;
        if (-4 > targetPos.y || 3 < targetPos.y)
            return false;
        return true;
    }
    
}





