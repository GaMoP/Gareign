using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Card : MonoBehaviour
{
    BoxCollider2D thisCard;
    public bool isMouseOver;

    // Start is called before the first frame update
    private void Start()
    {
        thisCard = gameObject.GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
   private void OnMouseOver(){
        isMouseOver = true;
   }
   private void OnMouseExit(){
        isMouseOver = false;
   }
}
