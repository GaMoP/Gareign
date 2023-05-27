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
    private string name;
    private int upThing;
    private int downThing;
    private int stat;
    
    public int health;
    public int money;
    public int people;
    public int intel;
    

    public float rotateE;
    public Card currentCard;
    public Card testCard;
    public Count HC;
    public Count MC;
    public Count PC;
    public Count IC;


    // Start is called before the first frame update
    void Start()
    {
        HC.setStat(health);
        MC.setStat(money);
        PC.setStat(people);
        IC.setStat(intel);
        Load(testCard);
    }

    // Update is called once per frame
    void Update()
    {
        characName.text=name;
        if(Input.GetMouseButton(0)&&cardcon.isMouseOver){
            Vector2 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            cardMoveObject.transform.position = pos;
        }
        else{
            cardMoveObject.transform.position = Vector2.MoveTowards(cardcon.transform.position,new Vector2(0,0),fMoving);
            Scripttext.text = ask;
            Scripttext.alpha=255;
        }
        if(cardMoveObject.transform.position.x==0){
            Scripttext.text=ask;
            if(Input.GetMouseButton(0)&&cardcon.isMouseOver){
                characName.text=" ";
            }
            else{      
                setChange();
                Scripttext.text=ask;      
            }
        }
        else if(cardMoveObject.transform.position.x>fSideMargin){
           Scripttext.alpha = Mathf.Min(cardMoveObject.transform.position.x,1); 
                       Scripttext.text=Right;
                        characName.text=" ";
                        showChange(0);
                       if(Input.GetMouseButtonUp(0)){
                        setStat(0);
                        NewCard();
                       }
        }
        else if(cardMoveObject.transform.position.x<fSideMargin){
              Scripttext.alpha = Mathf.Min(-cardMoveObject.transform.position.x,1); 
                     if(Input.GetMouseButtonUp(0)){
                        setStat(1);
                        NewCard();
                   }
            showChange(1);
            characName.text=" ";
            Scripttext.text=Left;
        }
        else{
            setChange();
            Scripttext.alpha=255;
            Scripttext.text=ask;
        }
       cardMoveObject.transform.eulerAngles = new Vector3(0,0,cardMoveObject.transform.position.x*rotateE); 

    }

    public void Load(Card card){
        cardSpriteRenderer.sprite=PicManager.sprites[(int)card.sprite];
        Left=card.leftQuote;
        Right=card.rightquote;
        ask = card.askquote;
        name = card.cardName;
        stat =card.stat;
        upThing = card.up;
        downThing =card.down;
    }
    public void NewCard(){
        int rollDice = Random.Range(0,PicManager.cards.Length);
        Load(PicManager.cards[rollDice]);
    } 
    public void setStat(int i){
        if(i==0){
             switch (upThing){
                 case 0:
                    health=health+stat;
                    HC.upStat(health);
                    break;
                case 1:
                    money= money+stat;
                    MC.upStat(money);
                break;
                case 2:
                    people= people+stat;
                    PC.upStat(people);
                break;
                case 3:
                    intel= intel+stat;
                    IC.upStat(intel);
                    break;
                default:
                break;
            }
        
            switch (downThing){
                case 0:
                    health=health-stat;
                    HC.downStat(health);
                    break;
                 case 1:
                    money= money-stat;
                    MC.downStat(money);
                    break;
                case 2:
                    people= people-stat;
                    PC.downStat(people);
                    break;
                case 3:
                    intel= intel-stat;
                    IC.downStat(intel);
                    break;
                default:
                  break;
            }
        }
        else{
              switch (downThing){
                 case 0:
                    health=health+stat;
                    HC.upStat(health);
                    break;
                case 1:
                    money= money+stat;
                    MC.upStat(money);
                break;
                case 2:
                    people= people+stat;
                    PC.upStat(people);
                break;
                case 3:
                    intel= intel+stat;
                    IC.upStat(intel);
                    break;
                default:
                break;
            }
        
            switch (upThing){
                case 0:
                    health=health-stat;
                    HC.downStat(health);
                    break;
                case 1:
                    money= money-stat;
                    MC.downStat(money);
                    break;
                case 2:
                    people= people-stat;
                    PC.downStat(people);
                    break;
                case 3:
                    intel= intel-stat;
                    IC.downStat(intel);
                    break;
                default:
                  break;
            }
        }
    }
    public void showChange(int i){
        setChange();
        if(i==0){
            switch (upThing){
                case 0:
                    HC.up.fillAmount=1;
                    break;
                case 1:
                    MC.up.fillAmount=1;
                break;
                case 2:
                    PC.up.fillAmount=1;
                break;
                case 3:
                    IC.up.fillAmount=1;
                    break;
                default:
                break;
            }
            switch (downThing){
                case 0:
                    HC.down.fillAmount=1;
                    break;
                case 1:
                    MC.down.fillAmount=1;
                break;
                case 2:
                    PC.down.fillAmount=1;
                break;
                case 3:
                    IC.down.fillAmount=1;
                    break;
                default:
                break;
            }
        }
        else{
              switch (downThing){
                case 0:
                    HC.up.fillAmount=1;
                    break;
                case 1:
                    MC.up.fillAmount=1;
                break;
                case 2:
                    PC.up.fillAmount=1;
                break;
                case 3:
                    IC.up.fillAmount=1;
                    break;
                default:
                break;
            }
        
            switch (upThing){
                case 0:
                    HC.down.fillAmount=1;
                    break;
                case 1:
                    MC.down.fillAmount=1;
                break;
                case 2:
                    PC.down.fillAmount=1;
                break;
                case 3:
                    IC.down.fillAmount=1;
                    break;
                default:
                break;
            }
        }
    }
     public void setChange(){
        HC.up.fillAmount=0;
        HC.down.fillAmount=0;
        
        MC.up.fillAmount=0;
        MC.down.fillAmount=0;

        PC.up.fillAmount=0;
        PC.down.fillAmount=0;

        IC.up.fillAmount=0;
        IC.down.fillAmount=0;
    }
}
