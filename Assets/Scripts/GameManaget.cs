using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class GameManaget : MonoBehaviour
{

    public GameObject cardMoveObject;
    public CardControll cardcon;
    public SpriteRenderer cardSpriteRenderer;
    public TMP_Text Scripttext;
    public TMP_Text characName;
    public Vector3 pos; 
    public float fSideMargin;
    public float fSideTrigger;
    public float fMoving;
    public picManager PicManager;
    private string Left;
    private string Right;
    private string ask;
    public int health;
    public int money;
    public int relation;
    public int study;

    public float rotateE;
    public Card currentCard;
    public Card testCard;

    // Start is called before the first frame update
    void Start()
    {
        Load(testCard);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButton(0)&&cardcon.isMouseOver){
            Vector2 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            cardMoveObject.transform.position = pos;
        }
        else{
            cardMoveObject.transform.position = Vector2.MoveTowards(cardcon.transform.position,new Vector2(0,0),fMoving);
        }

        if(cardMoveObject.transform.position.x>fSideMargin){
           Scripttext.alpha = Mathf.Min(cardMoveObject.transform.position.x,1); 
                       Scripttext.text=Right;
                       if(Input.GetMouseButtonUp(0)){
                        NewCard();
                       }
        }
        else if(cardMoveObject.transform.position.x<fSideMargin){
              Scripttext.alpha = Mathf.Min(-cardMoveObject.transform.position.x,1); 
                     if(Input.GetMouseButtonUp(0)){
                        NewCard();
                       }
            Scripttext.text=Left;
        }
        else{
            Scripttext.text=ask;
        }
       cardMoveObject.transform.eulerAngles = new Vector3(0,0,cardMoveObject.transform.position.x*rotateE); 

    }

    public void Load(Card card){
        cardSpriteRenderer.sprite=PicManager.sprites[(int)card.sprite];
        Left=card.leftQuote;
        Right=card.rightquote;
        ask = card.askquote;
    }
    public void NewCard(){
        int rollDice = Random.Range(0,PicManager.cards.Length);
        Load(PicManager.cards[rollDice]);
    } 
    public void setStat(int up,int down, int stat){
        
    }
}
