using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManaget : MonoBehaviour
{

    public GameObject cardMoveObject;
    public Card card;
    public SpriteRenderer SpriteRenderer;
    public Vector3 pos; 
    public float fMoving;


    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButton(0)&&card.isMouseOver){
            Vector2 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            cardMoveObject.transform.position = pos;
        }
        else{
            cardMoveObject.transform.position = Vector2.MoveTowards(card.transform.position,new Vector2(0,1),fMoving);
        }

        if(cardMoveObject.transform.position.x>0.5){
            SpriteRenderer.color=Color.green;
        }
        else if(cardMoveObject.transform.position.x<-0.5){
                    SpriteRenderer.color=Color.white;
        }
        else{
                        SpriteRenderer.color=Color.red;
        }
    }
}
