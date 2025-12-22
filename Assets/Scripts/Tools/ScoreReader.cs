using Singleton;
using TMPro;
using UnityEngine;

public class ScoreReader : MonoBehaviour
{
    [SerializeField] private TMP_Text _scoreText;
    // Update is called once per frame
    void Update()
    {
        _scoreText.text = ScoreKeeper.Instance().Score.ToString();
    }
}
