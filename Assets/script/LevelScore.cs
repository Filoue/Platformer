using UnityEngine;

public class LevelScore : MonoBehaviour
{
    public int maxScore = 3;
    public Transform LevelUi;
    public GameObject lvlPrefab;

    public bool isAlive = true;

    public int currentScore;
    
    void Awake()
    {
        UpdateScoreBar();
        currentScore = 3;
    }

    public void UpdateScoreBar()
    {
        foreach (Transform child in LevelUi)
        {
            Destroy(child.gameObject);
        }

        for (int i = 0; i < currentScore; i++)
        {
            Instantiate(lvlPrefab, LevelUi);
        }
    }

}
