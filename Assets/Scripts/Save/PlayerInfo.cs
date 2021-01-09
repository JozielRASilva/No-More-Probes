using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class PlayerInfo : MonoBehaviour
{

    public static int point = 0;
    public static int bestPoint = 0;


    public Text pointText;
    public Text newBest;

    public UnityEvent OnStart;

    void Start()
    {

        Application.targetFrameRate = 30;

        OnStart.Invoke();

        LoadPoint();
    }

    public void resetPoint()
    {
        point = 0;
    }

    public void setPoint()
    {
        if (pointText.text != point.ToString())
        {
            pointText.text = point.ToString();
        }
    }

    public void setBestPoint()
    {
        if (newBest.text != newBest.ToString())
        {
            newBest.text = "BEST " + bestPoint.ToString();
        }
    }


    public void DetermineBestPoint()
    {

        if (point > bestPoint)
        {
            bestPoint = point;

            if (newBest != null)
            {
                newBest.gameObject.SetActive(true);
            }


        }
        else
        {
            if (newBest != null)
            {
                newBest.gameObject.SetActive(false);
            }
        }

        SavePoint();
    }

    public void SavePoint()
    {
        SaveSystem.Save();
    }


    public static void AddPoints(int value)
    {
        point += value;

    }


    public void LoadPoint()
    {
        PlayerData data = SaveSystem.Load();
        if (data != null)
        {
            bestPoint = data.bestPoint;
        }
        else
        {
            bestPoint = 0;
        }

    }
}
