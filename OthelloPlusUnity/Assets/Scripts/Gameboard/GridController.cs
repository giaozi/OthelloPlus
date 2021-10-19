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
    //[SerializeField] private Tile boardTile = null;
    [SerializeField] private Tile whiteBoardTile = null;
    [SerializeField] private Tile blackBoardTile = null;

    [SerializeField] private BoardState boardState = null;


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
            if (!boardState.IsInsideBoard(mousePos)) { return; }

            interactiveMap.SetTile(previousMousePos, null); // Remove old hoverTile
            interactiveMap.SetTile(mousePos, hoverTile);
            previousMousePos = mousePos;
       }


       if (Input.GetMouseButtonDown(0))
       {
            Debug.Log("Click");
            Debug.Log("Tile Position @" + GetMouseTilePosition());


            boardState.PlacePiece (NewGamePiece(GamePiece.PieceColor.Black),  GetMouseTilePosition());
           //WebsocketManager.WebsocketSendText(Input.mousePosition.ToString());
       }

       // Right mouse click -> remove path tile
       if (Input.GetMouseButton(1))
       {
            boardMap.SetTile(mousePos, null);
       }

        if (Input.GetKey(KeyCode.Q))
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

    //used to set the tile
    GamePiece NewGamePiece(GamePiece.PieceColor color)
    {
        if(color != GamePiece.PieceColor.White && color != GamePiece.PieceColor.Black)
        {
            Debug.LogWarning("Piece has no color");
            return null;
        }


        Tile newPieceTile =null;
        if(color == GamePiece.PieceColor.White) { newPieceTile = whiteBoardTile; }
        if(color == GamePiece.PieceColor.Black) { newPieceTile = blackBoardTile; }


        return new GamePiece(color, newPieceTile);

 
     }


}





