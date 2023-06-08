using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Count : MonoBehaviour
{
    public Image self;
    public Image up;
    public Image down;

    // Start is called before the first frame update
    void Start()
    {
     
      self.fillAmount = 0/100;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void setStat(int st){
       
        self.fillAmount = (float)st/100;

    }
    public void upStat(int st){
       
        self.fillAmount = (float)st/100;

    }
     public void downStat(int st){
       
        self.fillAmount = (float)st/100;

    }
}
