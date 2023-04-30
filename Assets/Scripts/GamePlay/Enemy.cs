using UnityEngine;

public class Enemy : MonoBehaviour
{
    private void ShowLose()
    {
        if (GameManager.Instance.currentState != State.Lose)
        {
            GameManager.Instance.ShowLose();
        }
    }

    private bool isCollider;

    void OnCollisionEnter2D(Collision2D col)
    {
        if (!isCollider)
        {
            isCollider = true;
            
            if (col.gameObject.CompareTag("End"))
            {
                Debug.Log("Loseeeeee");
                ShowLose();
            }
            else if (col.gameObject.CompareTag("Wall"))
            {
                isCollider = false;
            }
            else
            {
                var e = GetComponent<PlayerController>();

                if (e)
                {
                    Destroy(e);
                }
            
                TheLevelTMP.Instance.Add();
                SpawnEnemy.Instance.Spawn();

                GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
            }
        }
       
    }
}