using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChessUnit : MonoBehaviour
{
    public ChessUnit(int unitType)
    {

    }
    
    public void Move()
    {
        this.gameObject.transform.localPosition = new Vector3();
    }
}
