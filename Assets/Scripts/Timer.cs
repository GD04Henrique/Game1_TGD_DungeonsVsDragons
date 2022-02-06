using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour
{
    public float targetTime = 60f;

    public float spawnTime = 2f;

    private float _bossTime;
    private bool _isBoss;

    public Text timerText;

    [SerializeField]
    private GameObject _enemy;

    [SerializeField]
    private GameObject _boss;

    [SerializeField]
    private Transform _player;

    private void Start()
    {
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


        /**if (spawnTime <= 0f)
        {
            Debug.Log("Enemy Appears");
            GameObject clone;
            clone = Instantiate(_enemy, new Vector3(0.699999988f, 5.94000006f, 0), Quaternion.identity);
            clone.GetComponent<MeleeEnemyBehavior>().player = _player; 
            spawnTime = 2f;
        }

        if(targetTime <= _bossTime && _isBoss == false)
        {
            Debug.Log("Boss Appears");
            GameObject clone;
            clone = Instantiate(_boss, new Vector3(0.699999988f, 5.94000006f, 0), Quaternion.identity);
            clone.GetComponent<BossEnemyBehavior>().player = _player;
            _isBoss = true;
        }**/

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
