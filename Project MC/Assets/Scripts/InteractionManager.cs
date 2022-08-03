using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionManager : MonoBehaviour
{
    
    public enum TurnState
    {
        PIECESELECT,
        PATHSELECT
    }

    public TurnState currentTurnState;

    [SerializeField] private BoardManager boardManager;

    private void Start()
    {

    }

    private void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if(Physics.Raycast(ray, out hit))
            {
                Debug.Log(hit.transform.gameObject.name);

                switch(currentTurnState)
                {
                    case(TurnState.PIECESELECT):
                        break;

                    case(TurnState.PATHSELECT):
                        break;
                }
            }
        }
    }
}
