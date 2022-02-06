using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour
{
    public float targetTime = 60f;

    public float spawnTime = 5f;

    private float _bossTime;
    private bool _isBoss;

    public Text timerText;

    [SerializeField]
    private GameObject _enemy;

    [SerializeField]
    private GameObject _boss;

    [SerializeField]
    private Transform _player;

    private Vector3[] _doors;

    public static bool _isClearGame;

    private void Start()
    {
        _isClearGame = false;
        _doors = new Vector3[3];
        _doors[0] = new Vector3(-9.37f,8.55f,0f);
        _doors[1] = new Vector3(19.6f,8.55f,0f);
        _doors[2] = new Vector3(37.528f,8.55f,0f);
        //timerText.text = "Time: " + targetTime.ToString();
        _bossTime = targetTime / 2;
        _isBoss = false;
    }

    void Update()
    {
        targetTime -= Time.deltaTime;
        spawnTime -= Time.deltaTime;

        DisplayTime(targetTime);

        void DisplayTime(float timeToDisplay)
        {
            if(timeToDisplay < 0)
            {
                timeToDisplay = 0;
            }

            else if(timeToDisplay > 0)
            {
                timeToDisplay += 1;
            }

            float minutes = Mathf.FloorToInt(timeToDisplay / 60);
            float seconds = Mathf.FloorToInt(timeToDisplay % 60);

            timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
        }


        if (spawnTime <= 0f)
        {
            //Debug.Log("Enemy Appears");
            int randomVector = Random.Range(0,3);
            GameObject clone;
            clone = Instantiate(_enemy, _doors[randomVector], Quaternion.identity);
            clone.GetComponent<MeleeEnemyBehavior>().player = _player; 
            spawnTime = 3f;
        }

        if(targetTime <= _bossTime && _isBoss == false)
        {
            //Debug.Log("Boss Appears");
            GameObject clone;
            clone = Instantiate(_boss, new Vector3(15.2f, -3.4f, 0f), Quaternion.identity);
            clone.GetComponent<BossEnemyBehavior>().player = _player;
            _isBoss = true;
        }

        if(targetTime <= 0f)
        {
            timerEnded();
        }

    }

    void timerEnded()
    {
        _isClearGame = false;
        SceneManager.LoadScene("End Game");
    }


}
