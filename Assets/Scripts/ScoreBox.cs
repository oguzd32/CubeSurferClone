using UnityEngine;

public class ScoreBox : MonoBehaviour
{
    [SerializeField] private int multipleScore;

    private bool once = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Cube" && once == false)
        {
            once = true;

            other.gameObject.transform.parent = null;
            FindObjectOfType<CubeHealth>().DealDamage(1);
            FindObjectOfType<GameSession>().AddToScore(multipleScore);
            if (CubeHealth.currentCubeAmount <= 0)
            {
                GameSession.levelComplete = true;
            }
        }
    }
}
