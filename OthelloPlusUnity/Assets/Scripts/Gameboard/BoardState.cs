using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class BoardState : MonoBehaviour
{
    [SerializeField] private Tilemap piecesMap = null;
  //  [SerializeField] private Tilemap boardMap = null;


    int boardWidth;
    int boardLength;

    GamePiece[,] BoardData = new GamePiece[8, 8];

    void SetUpBoardData(int width, int legnth)
    {
        for (int i = 0; i < width; i++)
        {
            for (int j = 0; j < legnth; j++)
            {
                BoardData[i, j] = new GamePiece(GamePiece.PieceColor.Empty);
            }
        }
    }
    void Start()
    {
        boardWidth = BoardData.GetLength(0);
        boardLength = BoardData.GetLength(1);

        SetUpBoardData(boardWidth, boardLength);
        SetStartPos();


    }


    //Sets up the starting 4 gamepieces in the typical othello setup
    void SetStartPos()
    {
        int startPos = (boardLength / 2) - 1;

        for (int i = 0; i < 2; i++)
        {


            Vector3Int whitePos = new Vector3Int(startPos + i, startPos + i, 0);
            Vector3Int blackPos = new Vector3Int(startPos + i, startPos + 1 - i, 0);

            PlacePiece(GamePiece.PieceColor.White, whitePos);
            PlacePiece(GamePiece.PieceColor.Black, blackPos);
        }


    }


    public void PlacePiece(GamePiece.PieceColor plannedColor, Vector3Int targetLocation)
    {
        GamePiece plannedPiece = new GamePiece(plannedColor);

        if (plannedPiece.pieceColor != GamePiece.PieceColor.Empty)
        {
            if (LocationStatus(targetLocation).pieceColor != GamePiece.PieceColor.Empty)
            {
                Debug.LogWarning("Can't Place a piece here");
                return;
            }
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
