using TMPro;
using UnityEngine;
public class Lives : MonoBehaviour
{
    private int lives = 3;
    private GameManager _gameManager;
    public TextMeshProUGUI LivesText;
    private void OnEnable()
    {
        _gameManager = FindObjectOfType<GameManager>();
        Debug.Log(_gameManager);

    }

    void Update()
    {
        LivesText.text = "LIVES:" + _gameManager.lives;
    }
}