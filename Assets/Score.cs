using TMPro;
using UnityEngine;

public class Score : MonoBehaviour
{
    private int score = 0;
    public TextMeshProUGUI scoreText;

    private GameManager _gameManager;

    private void OnEnable()
    {
        _gameManager= FindObjectOfType<GameManager>();
        Debug.Log(_gameManager);
    }

    void Update()
    {
        scoreText.text = "SCORE:" + _gameManager.score;
    }
}
    