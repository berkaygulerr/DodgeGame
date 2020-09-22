using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static bool gameOver, baslangic;
    int sayac = 3;
    float time = 0;
    public Text sayacText;
    void Start()
    {
        gameOver = false;
        baslangic = true;
    }

    void Update()
    {
        CountDown();
    }

    void CountDown()
    {
        if (Time.time > time)
        {
            sayacText.text = "" + sayac;

            sayac--;

            time = Time.time + 1;
        }

        if (sayac < 0)
        {
            sayacText.enabled = false;
            baslangic = false;
        }
    }
}
