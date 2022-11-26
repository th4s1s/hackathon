using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public static GameController Instance { get; private set; }
    [SerializeField] int maxOxy;
    int oxy;
    float timeReduceOxy=0;

    [SerializeField] GameObject gameOverPanel;
    public int Oxy
    {
        get { return oxy; }
        set { oxy = value; }
    }
    [SerializeField] int oxyReduceSpeed;
    [SerializeField] Slider slider;
    [SerializeField] Gradient gradient;
    [SerializeField] Image fill;
    private void Awake()
    {
        Instance = this;
    }
    private void Start()
    {
        oxy = maxOxy / 2;
        slider.value = (float)oxy / maxOxy;
    }
    private void FixedUpdate()
    {
        if (Time.time>=timeReduceOxy+5)
        {
            timeReduceOxy = Time.time;
            oxy -= oxyReduceSpeed;
        }
        if (oxy > maxOxy) oxy = maxOxy;
        slider.value = (float)oxy / maxOxy;
        fill.color = gradient.Evaluate(slider.value);
    }
    public void NextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void Restart()
    {
        Debug.Log("Restart Level");
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void Win()
    {
        Debug.Log("Win");
    }

    public void Lose()
    {
        Player.Instance.Die();
        gameOverPanel.SetActive(true);
        Invoke("Restart", 5);
        //Todo
    }

    public void Exit()
    {
        //Todo
    }
    
}
