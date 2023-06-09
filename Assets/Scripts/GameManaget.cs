 using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class GameManaget : MonoBehaviour
{

    public GameObject cardMoveObject;
    public CardControll cardcon;
    public SpriteRenderer cardSpriteRenderer;
    public TMP_Text Scripttext;
    public TMP_Text characName;
    public TMP_Text dayCount;
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
    
    public GameObject StartImage;


    public int health;
    public int money;
    public int people;
    public int intel;
    private int gameStatus=0;
    private int count=0;
    private int start = 0;

    public float rotateE;
    public Card currentCard;
    public Card testCard;
    public Count HC;
    public Count MC;
    public Count PC;
    public Count IC;
    public Card healthZero;
    public Card healthMax;
    public Card moneyZero;
    public Card moneyMax;
    public Card peopleZero;
    public Card peopleMax;
    public Card intelZero;
    public Card intelMax;
    public Card gameOver;
    public Card tutorial;


    // Start is called before the first frame update
    void Start()
    { 
    }

    // Update is called once per frame
    void Update()
    {   
        
        if(start==1){
            characName.text=name;

            HC.setStat(health);
            MC.setStat(money);
            PC.setStat(people);
            IC.setStat(intel);
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
                            if(gameStatus==1){
                                count=0;
                                clearStat();
                                gameStatus=2;
                                Load(gameOver);
                            }
                            else if(gameStatus==2){
                                SceneManager.LoadScene("Ranking");
                            }
                            else if(gameStatus==3){
                                gameStatus=4;
                                Load(tutorial);
                            }
                            else if(gameStatus==4){
                                gameStatus=0;
                                NewCard();
                            }
                            else{
                                NewCard();
                                count=count+1;
                            }
                        }
            }
        else if(cardMoveObject.transform.position.x<fSideMargin){
              Scripttext.alpha = Mathf.Min(-cardMoveObject.transform.position.x,1); 
                     if(Input.GetMouseButtonUp(0)){
                        setStat(1);
                          if(gameStatus==1){
                            count = 0;
                            clearStat();
                            gameStatus=2;
                            Load(gameOver);
                            }
                            else if(gameStatus==2){
                                 gameStatus=0;
                                 NewCard();
                            } 
                            else if(gameStatus==3){
                            gameStatus=4;
                            Load(tutorial);
                            }
                            else if(gameStatus==4){
                            gameStatus=0;
                            NewCard();
                            }
                           else{
                                NewCard();
                                count=count+1;
                            }
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
            checkOver();
            dayCount.text=" "+count+" ";
            }
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
        int rollDice = Random.Range(0,7);
        Load(PicManager.cards[rollDice]);
    } 
    public void clearStat(){
        health=50;
        money=50;
        intel=50;
        people=50;
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
    public void checkOver(){
        if(health<=0){
            gameStatus=1;
            Load(healthZero);
        }
        if(health>=100){
            gameStatus=1;
            Load(healthMax);
        }
        if(people<=0){
            gameStatus=1;
            Load(peopleZero);
        }
        if(people>=100){
            gameStatus=1;
            Load(peopleMax);
        }
         if(money<=0){
            gameStatus=1;
            Load(moneyZero);
        }
        if(money>=100){
            gameStatus=1;
            Load(moneyMax);
        }
        if(intel<=0){
            gameStatus=1;
            Load(intelZero);
        }
        if(intel>=100){
            gameStatus=1;
            Load(intelMax);
        }
    }
    public void onClickStartButton(){
        start =1;
        StartImage.SetActive(false);
        HC.setStat(health);
        MC.setStat(money);
        PC.setStat(people);
        IC.setStat(intel);
        gameStatus=3;
        Load(testCard);
    }
}
