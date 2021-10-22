using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
//using WebsocketConnection;
public class GridController : MonoBehaviour
{
    private Grid grid;
    [SerializeField] private Tilemap interactiveMap = null;
    [SerializeField] private Tilemap piecesMap = null;
    //[SerializeField] private Tile hoverTile = null;
    //[SerializeField] private Tile boardTile = null;
    [SerializeField] private Tile whiteBoardTile = null;
    [SerializeField] private Tile blackBoardTile = null;

    [SerializeField] private BoardState boardState = null;

    Vector3Int mousePos;
    private Vector3Int previousMousePos = new Vector3Int();

    GamePiece blackPiece;
    GamePiece whitePiece;
    GamePiece currentPiece;

    // Start is called before the first frame update
   void Start()
   {
        grid = gameObject.GetComponent<Grid>();
        blackPiece = new GamePiece(GamePiece.PieceColor.Black);
        whitePiece = new GamePiece(GamePiece.PieceColor.White);

        currentPiece = blackPiece;
   }

   // Update is called once per frame
   void Update()
   {

       // Mouse over -> highlight tile
        mousePos = GetMouseTilePosition();

        if (!mousePos.Equals(previousMousePos))
        {
            if (!boardState.IsInsideBoard(mousePos)) { return; }

            interactiveMap.SetTile(previousMousePos, null); // Remove old hoverTile
            interactiveMap.SetTile(mousePos, currentPiece.tile);
            previousMousePos = mousePos;
        }

        if (Input.GetMouseButtonDown(0))
       {
            boardState.PlacePiece ((currentPiece.pieceColor),  GetMouseTilePosition());
           //WebsocketManager.WebsocketSendText(Input.mousePosition.ToString());
       }

       // Right mouse click -> remove path tile
       if (Input.GetMouseButtonDown(1))
       {
            boardState.PlacePiece((GamePiece.PieceColor.Empty), GetMouseTilePosition());
        }

        if (Input.GetKeyDown(KeyCode.S))
        {
            if (currentPiece == blackPiece)
                currentPiece = whitePiece;
            else
                currentPiece = blackPiece;


            interactiveMap.SetTile(mousePos, currentPiece.tile);
            Debug.Log("Switch");
        }

        if (Input.GetKeyDown(KeyCode.Q))
        {
            Debug.Log("Piece @" + GetMouseTilePosition() + " is "+ boardState.LocationStatus(GetMouseTilePosition()).pieceColor);
        }
   }
    Vector3Int GetMouseTilePosition()
    {
        Vector3 mouseWorldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition) + new Vector3Int(0, 0, 10);//10 on Z-axis to offset camera
        Vector3Int mouseGridPos = grid.WorldToCell(mouseWorldPos);
        // Debug.Log("MouseGridPos is" + mouseGridPos);

        return mouseGridPos;
    }

}





