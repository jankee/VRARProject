using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private float speed;
    private float delay;

    private Animator animator;

    [SerializeField]
    private float speedTime;

    // Use this for initialization
    private void Start()
    {
        animator = transform.GetChild(0).GetComponent<Animator>();
    }

    private void Update()
    {
    }

    public void MoveCharacter(string dir)
    {
        animator.SetTrigger("JUMP");

        switch (dir)
        {
            case "left":
                this.transform.eulerAngles = new Vector3(0, 270, 0);
                break;

            case "down":
                this.transform.eulerAngles = new Vector3(0, 180, 0);
                break;

            case "right":
                this.transform.eulerAngles = new Vector3(0, 90, 0);
                break;

            case "up":
                this.transform.eulerAngles = new Vector3(0, 0, 0);

                GameManager.Instance.ScoreUp();
                break;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        switch (other.tag)
        {
            case "Coin":
                int value = other.GetComponent<Coins>().CoinValue;
                GameManager.Instance.CoinUp(value);
                Destroy(other.gameObject);
                break;

            case "Water":
                //Destroy(gameObject);
                GameManager.Instance.GamePause();
                GameManager.Instance.IsPaused = true;
                GameManager.Instance.IsGameOver = true;
                break;

            default:
                break;
        }
    }

    public IEnumerator SmoothMovement(Vector3 end)
    {
        float sqrRemainingDistance = (transform.position - end).magnitude;

        print(sqrRemainingDistance);

        yield return null;
    }
}