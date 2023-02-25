using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SwitchSlide : MonoBehaviour
{
    private Image ruleimage;
    public Sprite[] rulesprites;
    int count;
    // Start is called before the first frame update
    void Start()
    {
        count = 0;
        ruleimage = GetComponent<Image>();
        ruleimage.sprite = rulesprites[0];
    }

    public void ClickNext()
    {
        switch (count)
        {
            case 0:
                ruleimage.sprite = rulesprites[1];
                count++;
                break;
            case 1:
                ruleimage.sprite = rulesprites[2];
                count++;
                break;
            case 2:
                ruleimage.sprite = rulesprites[3];
                count++;
                break;
            case 3:
                ruleimage.sprite = rulesprites[0];
                count = 0;
                break;
        }
    }

    public void ClickBack()
    {
        switch (count)
        {
            case 0:
                ruleimage.sprite = rulesprites[3];
                count = 3;
                break;
            case 1:
                ruleimage.sprite = rulesprites[0];
                count = 0;
                break;
            case 2:
                ruleimage.sprite = rulesprites[1];
                count = 1;
                break;
            case 3:
                ruleimage.sprite = rulesprites[2];
                count = 2;
                break;
        }
    }
}
