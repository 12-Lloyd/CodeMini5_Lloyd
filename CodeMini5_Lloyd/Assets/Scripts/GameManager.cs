using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public GameObject addEnergyPrefab;
    public GameObject minusEnergyPrefab;
    public GameObject TimeLimit;
    public int numberOfSpawn;
    public float levelTime;
    // Start is called before the first frame update
    void Start()
    {
        if (instance == null)
        {
            instance = this;
        }
        for (int i =0; i < numberOfSpawn; i++)
        {
            Vector3 randomPos = new Vector3(Random.Range(-15, 15), 0, Random.Range(-15, 15));
            if( Random.Range(0,2)<1)
            {
                Instantiate(addEnergyPrefab, randomPos, Quaternion.identity);
            }
            else
            {
                Instantiate(minusEnergyPrefab, randomPos, Quaternion.identity);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (levelTime > 0)
        {
            levelTime -= Time.deltaTime;
            //print("levelTime: " + levelTime);
            print("LevelTime: " + FormatTime(levelTime));
            TimeLimit.GetComponent<Text>().text = "LevelTime: " + FormatTime(levelTime);
        }
        else
        {
            levelTime = 0;
            print("Times up");
        }
        if (GameManager.instance.levelTime < 0)
        {
            TimeLimit.GetComponent<Text>().text = "LevelTime: 00:00:000";
        }
    }
    public string FormatTime(float time)
    {
        int minutes = (int)time / 60;
        int seconds = (int)time - 60 * minutes;
        int milliseconds = (int)(1000 * (time - minutes * 60 - seconds));
        return string.Format("{0:00}:{1:00}:{2:000}",minutes,seconds,milliseconds);
    }
    public void spawn()
    {
        for (int i = 0; i < numberOfSpawn; i++)
        {
            Vector3 randomPos = new Vector3(Random.Range(-15, 15), 0, Random.Range(-15, 15));
            if (Random.Range(0, 2) < 1)
            {
                Instantiate(addEnergyPrefab, randomPos, Quaternion.identity);
            }
            else
            {
                Instantiate(minusEnergyPrefab, randomPos, Quaternion.identity);
            }
        }
        if (instance == null)
        {
            instance = this;
        }
    }
}
