using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class WinScript : MonoBehaviour
{
    public string level;
    private void OnTriggerEnter2D(Collider2D other)
    {
        SceneManager.LoadScene(level);
    }
}
