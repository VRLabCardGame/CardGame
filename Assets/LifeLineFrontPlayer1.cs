using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LifeLineFrontPlayer1 : MonoBehaviour
{
    public Image image;
    public int maximum;
    public int current;
    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        ApplyCurrentFill();
    }

    public void ApplyCurrentFill()
    {
        float fillAmount = (float)current / (float)maximum;
        image.transform.localScale = new Vector3(fillAmount, 1, 1);
    }

    public int GetCurrentFill()
    {
        return current;
    }

    public void SetCurrentFill(int NewFill)
    {
        current = NewFill;
    }








}
