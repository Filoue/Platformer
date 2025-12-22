using Singleton;
using UnityEngine;

public class Scorer : MonoBehaviour
{
    public int _scoreAdd;
    public void AddScore()
    {
        ScoreKeeper.Instance().Score += _scoreAdd;
    }
}