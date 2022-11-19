using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class Game : MonoBehaviour
{
    public Player Controls;
    public GameObject Loss;

    static public int Level;
    [SerializeField] private GameObject[] _levels;

    [SerializeField] private Canvas _loseScreen;
    [SerializeField] private Canvas _winScreen;

    [SerializeField] private GameObject _confetti;

    [SerializeField] private TextMeshProUGUI _levelText;

    private void Awake()
    {
        Application.targetFrameRate = 60;

        if (Level >= _levels.Length) Level = 0;
        GameObject level = Instantiate(_levels[Level], transform);
        _levelText.text = $"Level {Level + 1}";
    }

    public enum State
    {
        Playing,
        Won,
        Loss,
    }

    public State CurrentState { get; private set; }

    public void OnPlayerDied()
    {
        if (CurrentState != State.Playing) return;
        CurrentState = State.Loss;
        Controls.enabled = false;
        Debug.Log("Game Over!");
        Loss.SetActive(true);
        _loseScreen.gameObject.SetActive(true);
    }

    public void OnPlayerWon()    
    {
        if (CurrentState != State.Playing) return;
        CurrentState = State.Won;
        Controls.enabled = false;
        Debug.Log("You Won!");
        _winScreen.gameObject.SetActive(true);
        _confetti.SetActive(true);
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(0);
    }
    public void NextLevel()
    {
        Level++;
        SceneManager.LoadScene(0);
    }

}
