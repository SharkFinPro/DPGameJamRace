using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//tyler wrote this
public class EnableScript : MonoBehaviour
{
    public GameObject buttonObj;    
    public bool fadeIn = true;
    public float fadeTime = 0;
    Button buttonscript;
    Color oldColor;
    GameObject gameToBeEnabled;
    public bool isActivated;
    // Start is called before the first frame update
    void Start()
    {
        buttonscript = buttonObj.GetComponent<Button>();
        SpriteRenderer SpriteColor = this.gameObject.GetComponent<SpriteRenderer>();
        oldColor = SpriteColor.color;
        Color clearColor = oldColor;
        clearColor.a = 0f;
        gameToBeEnabled = this.gameObject;
        if (fadeIn == true)
        {
            SpriteColor.color = clearColor;
        }
        BoxCollider2D boxcollider = gameToBeEnabled.GetComponent<BoxCollider2D>();
        boxcollider.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        isActivated = buttonscript.isOn;
        if (buttonscript.isOn == true)
        { 
            SpriteRenderer SpriteColor = this.gameObject.GetComponent<SpriteRenderer>();            
            if (fadeIn == true)
            {
                Color currentColor = SpriteColor.color;
                SpriteColor.color = Color.Lerp(currentColor, oldColor, fadeTime * Time.deltaTime);
            }
            else
                SpriteColor.color = oldColor;
            BoxCollider2D boxcollider = gameToBeEnabled.GetComponent<BoxCollider2D>();
            boxcollider.enabled = true;
        }
    }
}
