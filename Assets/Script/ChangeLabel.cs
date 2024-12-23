using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.UI;

public class ChangeLabel : MonoBehaviour
{
    public Text tmpText;
    public InputField tmpInput;

    
    public void changeLabel(string speedStirng) {
        tmpText.text = speedStirng;
    }

    //这个很重要，关联iOS方法
    [DllImport("__Internal" )]
     static extern void iOSLog(string value);

     public void btnClick(){
       iOSLog(tmpInput.text);
    }
}

