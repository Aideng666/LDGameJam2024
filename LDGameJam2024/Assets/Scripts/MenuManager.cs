using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class MenuManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Options()
    {

    }

    public void PointerEnter(GameObject button)
    {
        button.transform.localScale = new Vector2(1.2f, 1.2f);
    }

    public void PointerExit(GameObject button)
    {
        button.transform.localScale = new Vector2(1f, 1f);
    }

    public void RotateObjectEnter(GameObject obj)
    {
        obj.transform.Rotate(new Vector3(0, 0, 1), -135f);
        obj.GetComponent<Image>().color = new Color(0.3537736f, 0.9136526f, 1, 1);
    }

    public void RotateObjectExit(GameObject obj)
    {
        obj.transform.Rotate(new Vector3(0, 0, 1), 135f);
        obj.GetComponent<Image>().color = new Color(0.4392157f, 0.08627451f, 0.5450981f, 1);
    }

    public void ExitGame()
    {
        //Application.Quit();    
    }
}
