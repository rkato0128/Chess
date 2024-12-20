using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using DG.Tweening;

public class Card_Play : MonoBehaviour
{
    public Constants.PieceType type;
    [SerializeField] private TextMeshProUGUI cardName;
    [SerializeField] private Image pieceImage;
    [SerializeField] private GameObject cardBg_white;
    [SerializeField] private GameObject cardBg_black;
    [SerializeField] private Button cardBtn;
    [SerializeField] private RectTransform cardRect;

    [SerializeField] private Sprite[] pieceImgResources;

    private void Start()
    {
        cardBtn.onClick.AddListener(CardSelected);
    }


    public void SetData(Constants.PieceType pieceType, Constants.Team team)
    {
        type = pieceType;

        cardName.text = type.ToString();

        // Set Piece Image : white 0~5 / black 6~11
        pieceImage.sprite = pieceImgResources[(int)type + 6 * (int)team];

        // Set Card Bg by team
        cardBg_white.SetActive(team == Constants.Team.WHITE ? true : false);
        cardBg_black.SetActive(team == Constants.Team.BLACK ? true : false);
    }

    void CardSelected()
    {
        // Call BM to Change Phase
        BM.boardManager.CardSelected(this);
        //this.gameObject.GetComponent<RectTransform>().DOScale();

        // Select UI On
    }

    public void CardUnSelectedAnim()
    {
        cardRect.DOAnchorPosY(0, 0.1f);
    }

    public void CardSelectedAnim()
    {
        cardRect.DOAnchorPosY(72, 0.1f);
    }

    Sequence sequence1;
}
