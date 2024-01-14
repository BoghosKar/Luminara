using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    // Player
    public GameObject player;
    public GameObject deadMenu;

    // Pause Menu
    public GameObject pauseMenu;
    public Animation pauseAnim;
    // [SerializeField] float pauseOpenAnimationLength = 0.2f;
    public bool isPaused;

    // Timer properties
    public float timerDuration = 60f;
    public float currentTimerValue;
    private float startingTime;
    [SerializeField] private Gradient timerColorGradient;

    // Beat effect properties
    [SerializeField] private float beatEffectSpeed = 1f;
    [SerializeField] private float beatSizeExtra = 0.2f;
    private bool isExpanding;
    private bool isRetraining;
    private float invisTimer;

    // UI elements
    public Text timerText;
    private Vector3 startingSize;

    void Start()
    {
        currentTimerValue = timerDuration;
        startingTime = currentTimerValue;
        startingSize = timerText.transform.localScale;
        UpdateTimerDisplay(currentTimerValue);
        StartCoroutine(TimerTick());
        pauseMenu.SetActive(false);
    }

    void Update()
    {
        if (player)
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                if (isPaused)
                {
                    ResumeGame();
                }
                else
                {
                    PauseGame();
                }
            }
        }

        if (isExpanding && player)
        {
            if (1f > invisTimer)
            {
                invisTimer += beatEffectSpeed * Time.deltaTime;
            }
            else
            {
                invisTimer = 1f;
                isExpanding = false;
                isRetraining = true;
            }
        }
        else if (isRetraining)
        {
            if (invisTimer > 0f)
            {
                invisTimer -= beatEffectSpeed * Time.deltaTime / 1.5f;
            }
            else
            {
                invisTimer = 0f;
                isRetraining = false;
            }
        }

        timerText.transform.localScale = Vector3.Lerp(startingSize, startingSize + new Vector3(beatSizeExtra, beatSizeExtra, beatSizeExtra), invisTimer);
    }

    private IEnumerator TimerTick()
    {
        while (currentTimerValue > 0f && player)
    {
        yield return new WaitForSeconds(1);
        currentTimerValue -= 1f;
        if (player) // Add this check to make sure the player is still alive
        {
            UpdateTimerDisplay(currentTimerValue);
        }
    }
    GameOver();
    }

    private void UpdateTimerDisplay(float timerValue)
    {
        timerText.text = timerValue.ToString("F0");
        timerText.color = timerColorGradient.Evaluate(1f - (timerValue / startingTime));
        isExpanding = true;
    }

       public void GameOver()
    {
        Destroy(pauseMenu);
        deadMenu.SetActive(true);
        player.SetActive(false);
        Invoke("Delay", 1.5f);
    }

    public void PauseGame()
    {
        pauseMenu.SetActive(true);
        // pauseAnim.Play();
        // Invoke("ZeroTime",pauseOpenAnimationLength);
        ZeroTime();
    }

    public void ZeroTime()
    {
        Time.timeScale = 0f;
        isPaused = true;
    }

    public void ResumeGame()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
        isPaused = false;
    }
}

    






	/*
	public static Timer Instance { get; set; }
	private Text text;	
	private float timer;	
	private bool stop;
	
	private void Awake()
	{
		Timer.Instance = this;
		this.text = base.GetComponent<Text>();
		this.stop = false;
		this.StartTimer();
	}

	
	public void StartTimer()
	{
		this.stop = false;
		this.timer = 0f;
	}


	private void Update()
	{
		
		this.timer += Time.deltaTime;
		
		this.text.text = Timer.GetFormattedTime(this.timer);
	}

	
	public static string GetFormattedTime(float f)
	{
		if (f == 0f)
		{
			return "nan";
		}
		string arg = Mathf.Floor(f / 60f).ToString("00");
		string arg2 = Mathf.Floor(f % 60f).ToString("00");
		string text = (f * 1000f % 1000f).ToString("00");
		if (text.Equals("100"))
		{
			text = "99";
		}
		return string.Format("{1}:{2}", arg, arg2, text);
	}

	
	public float GetTimer()
	{
		return this.timer;
	}

	
	public void Stop()
	{
		this.stop = true;
	}

	
	public int GetMinutes()
	{
		return (int)Mathf.Floor(this.timer / 60f);
	}
	*/