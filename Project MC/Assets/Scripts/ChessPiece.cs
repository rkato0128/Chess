using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChessPiece : MonoBehaviour
{
    public ChessPiece(int unitType)
    {

    }
    
    public void Move()
    {
        this.gameObject.transform.localPosition = new Vector3();
    }
}
