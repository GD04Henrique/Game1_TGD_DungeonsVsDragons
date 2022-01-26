using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour
{
    public float targetTime = 60f;

    public float spawnTime = 2f;

    public Text timerText;

    [SerializeField]
    private GameObject _enemy;

    private void Start()
    {
        timerText.text = "Time: " + targetTime.ToString();
    }

    void Update()
    {
        timerText.text = "Time: " + targetTime.ToString();
        targetTime -= Time.deltaTime;
        spawnTime -= Time.deltaTime;

        if (spawnTime <= 0f)
        {
            Debug.Log("Enemy Appears");
            Instantiate(_enemy, new Vector3(0.699999988f, 5.94000006f, 0), Quaternion.identity);
            spawnTime = 2f;
        }

        if(targetTime <= 0f)
        {
            timerEnded();
        }

    }

    void timerEnded()
    {
        SceneManager.LoadScene(1);
    }


}
