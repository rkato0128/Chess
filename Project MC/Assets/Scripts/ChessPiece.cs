using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using DG.Tweening;

public class ChessPiece : MonoBehaviour
{
    // prefab 단에서 설정
    [Header("Piece Initial Option")]
    public Constants.PieceType type;

    [Space]
    [SerializeField] private Constants.Team _team;
    public Constants.Team team { get { return _team; } }
    public BoardTile currentTile;

    // Moving Direction Enum
    public enum Direction
    {
        NEGATIVE = -1,
        ZERO = 0,
        POSITIVE = 1
    }

    
    public void Set(BoardTile setTile)
    {
        currentTile = setTile;
        currentTile.pieceOnTile = this;

        this.gameObject.transform.localPosition = new Vector3(setTile.transform.localPosition.x, 0.5f, setTile.transform.localPosition.z);
    }

    
    public void Move(BoardTile targetTile)
    {
        // Attack
        if (targetTile.isPieceOnTile)
        {
            targetTile.pieceOnTile.Death();
        }

        // Move
        currentTile.pieceOnTile = null;

        targetTile.pieceOnTile = this;
        this.gameObject.transform.localPosition = new Vector3(targetTile.transform.localPosition.x, 1.25f, targetTile.transform.localPosition.z);

        currentTile = targetTile;
    }

    public void Death()
    {
        currentTile.pieceOnTile = null;

        if (type == Constants.PieceType.KING)
        {
            // End Game
            BM.boardManager.EndGame();
        }

        Destroy(this.gameObject);
    }


    public virtual void CheckPath()
    {
        // 하위 말에서 상속받아 override 해 사용
    }

    // 일반적인 경로 계산
    public void CheckGeneralPath(Vector2Int boardCoord, Direction dirX, Direction dirY, int moveCount = 1, bool isPawn = false)
    {
        int count = 1;

        while(true)
        {
            boardCoord.x += 1 * (int) dirX;
            boardCoord.y += 1 * (int) dirY;
            
            if(boardCoord.x < 0 || boardCoord.x >= BM.boardManager.size.x || boardCoord.y < 0 || boardCoord.y >= BM.boardManager.size.y || count > moveCount)
            {
                break;
            }

            //Debug.Log("board X : " + boardCoord.x + " board Y :" + boardCoord.y);

            if(BM.boardManager.board[boardCoord.x, boardCoord.y].isPieceOnTile)
            {
                if(BM.boardManager.board[boardCoord.x, boardCoord.y].pieceOnTile.team != team && !isPawn)
                {
                    BM.boardManager.moveableArea.Add(BM.boardManager.board[boardCoord.x, boardCoord.y]);
                }

                break;
            }
            else
            {
                BM.boardManager.moveableArea.Add(BM.boardManager.board[boardCoord.x, boardCoord.y]);
            }

            count++;
        }
    }

    // 한 타일이 이동 가능한 타일인지 확인
    public void CheckTileMoveable(Vector2Int boardCoord)
    {
        if (boardCoord.x > -1 && boardCoord.x < BM.boardManager.size.x &&
            boardCoord.y > -1 && boardCoord.y < BM.boardManager.size.y)
        {
            if (BM.boardManager.board[boardCoord.x, boardCoord.y].isPieceOnTile)
            {
                if (BM.boardManager.board[boardCoord.x, boardCoord.y].pieceOnTile.team != team)
                {
                    BM.boardManager.moveableArea.Add(BM.boardManager.board[boardCoord.x, boardCoord.y]);
                }
            }
            else
            {
                BM.boardManager.moveableArea.Add(BM.boardManager.board[boardCoord.x, boardCoord.y]);
            }
        }
    }

    public void Check()
    { 

    }

    public void PieceSelectedAnim()
    {
        this.gameObject.GetComponent<Transform>().DOLocalMoveY(1f, 0.2f);
    }

    public void PieceUnSelectedAnim()
    {
        this.gameObject.GetComponent<Transform>().DOLocalMoveY(0.5f, 0.2f).SetDelay(0.075f);
    }
}