using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class BoardState : MonoBehaviour
{
    [SerializeField] private Tilemap piecesMap = null;
    [SerializeField] private Tilemap boardMap = null;




    GamePiece[,] BoardData = new GamePiece[8, 8];

    void SetUpBoardData()
    {
        for (int i = 0; i < BoardData.GetLength(0); i++)
        {
            for (int j = 0; j < BoardData.GetLength(1); j++)
            {
                BoardData[i, j] = new GamePiece(GamePiece.PieceColor.Empty);
            }
        }
    }
    void Start()
    {


        SetUpBoardData();


    }


    //Sets up the starting 4 gamepieces in the typical othello setup
    void SetBoardStart()
    {


    }


    public void PlacePiece(GamePiece plannedPiece, Vector3Int targetLocation)
    {


        if(LocationStatus(targetLocation).pieceColor != GamePiece.PieceColor.Empty) {
            Debug.LogWarning("Can't Place a piece here");
            return;
        }
        BoardData[targetLocation.x, targetLocation.y] = plannedPiece;
        piecesMap.SetTile(targetLocation, plannedPiece.tile);

    }


    //Returns if the location on a board has a piece
    public GamePiece LocationStatus(Vector3Int location)
    {
        if (!IsInsideBoard(location))
        {
            Debug.LogWarning("Your selected space is not within the board");
            return null;
        }
        Debug.Log(BoardData[0, 0].pieceColor);

        Debug.Log("TEWFDS" + BoardData[location.x, location.y].pieceColor);
        return BoardData[location.x, location.y];
    }

    //Returns true if location is in board
    public bool IsInsideBoard(Vector3Int targetPos)
    {
        if (0 > targetPos.x || 7 < targetPos.x)
            return false;
        if (0 > targetPos.y || 7 < targetPos.y)
            return false;
        return true;
    }

}
