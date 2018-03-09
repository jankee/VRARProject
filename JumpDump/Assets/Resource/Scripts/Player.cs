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

    /// <summary>
    /// 방향을 정하고 SmoothMovement 코루틴을 실행
    /// </summary>
    /// <param name="dir"></param>
    public void MoveCharacter(string dir)
    {
        animator.SetTrigger("JUMP");

        switch (dir)
        {
            case "left":
                this.transform.eulerAngles = new Vector3(0, 270, 0);
                StartCoroutine(SmoothMovement(Vector3.left));
                break;

            case "down":
                this.transform.eulerAngles = new Vector3(0, 180, 0);
                StartCoroutine(SmoothMovement(Vector3.back));
                break;

            case "right":
                this.transform.eulerAngles = new Vector3(0, 90, 0);
                StartCoroutine(SmoothMovement(Vector3.right));
                break;

            case "up":
                this.transform.eulerAngles = new Vector3(0, 0, 0);
                StartCoroutine(SmoothMovement(Vector3.forward));
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

                //case "Water":
                //    //Destroy(gameObject);
                //    GameManager.Instance.GamePause();
                //    GameManager.Instance.IsPaused = true;
                //    GameManager.Instance.IsGameOver = true;
                //    break;
        }
    }

    /// <summary>
    /// MoveCharacter에서 값을 받아 움직임
    /// </summary>
    /// <param name="end"></param>
    /// <returns></returns>
    private IEnumerator SmoothMovement(Vector3 end)
    {
        float timer = 0.45f;
        float cooltime = 0f;

        Vector3 starPos = this.transform.position;

        starPos = new Vector3(Mathf.Round(starPos.x), Mathf.Round(starPos.y), Mathf.Round(starPos.z));

        Vector3 endPos = starPos + end;

        while (cooltime < timer)
        {
            cooltime += Time.deltaTime;

            this.transform.localPosition = Vector3.Lerp(starPos, endPos, cooltime / timer);

            yield return null;
        }

        InputManager.Instance.IsMoved = false;
    }
}