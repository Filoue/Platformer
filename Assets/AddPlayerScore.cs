using UnityEngine;

public class AddPlayerScore : MonoBehaviour
{
    [Header("Debug")]
    [SerializeField] private SO_Score levelScore;
    
    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.TryGetComponent(out PlayerScore playerScore))
        {
            playerScore.lvl1(levelScore.Scorelvl1);
            playerScore.lvl2(levelScore.Scorelvl2);
            playerScore.lvl3(levelScore.Scorelvl3);
        }
    }

}
