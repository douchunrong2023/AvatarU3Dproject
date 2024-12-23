using System.Collections;
using System.Collections.Generic;
// using UnityEditor.iOS;
using UnityEngine;
using UnityEngine.UIElements;

public class ChangeBg : MonoBehaviour
{
   
    public Texture2D bg1;
    public Texture2D bg2;
    public Material material1;
    // Start is called before the first frame update
    void Start()
    {
        MeshRenderer mr = GetComponent<MeshRenderer>();
        material1 = mr.material;

        material1.mainTexture = bg1;
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void togglebg()
    {
        material1.mainTexture = bg2;

    }
}
