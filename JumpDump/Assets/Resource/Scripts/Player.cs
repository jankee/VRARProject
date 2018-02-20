using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private UIManager _uiManager;

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

                UIManager.Instance.ScoreUp();
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