using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private UIManager _uiManager;

    private float speed;
    private float delay;

    [SerializeField]
    private float speedTime;

    // Use this for initialization
    private void Start()
    {
        //_uiManager = GameObject.Find("UIManager").GetComponent<UIManager>();
    }

    private void Update()
    {
        //if (Input.GetKeyDown(KeyCode.W))
        //{
        //    MoveCharacter(0, 1);
        //}
        //if (Input.GetKeyDown(KeyCode.S))
        //{
        //    MoveCharacter(0, -1);
        //}
        //if (Input.GetKeyDown(KeyCode.A))
        //{
        //    MoveCharacter(1, 0);
        //}
        //if (Input.GetKeyDown(KeyCode.D))
        //{
        //    MoveCharacter(-1, 0);
        //}
    }

    public bool MoveCharacter(int xDir, int zDir)
    {
        //float lerpTime = 1;
        Vector3 start = transform.position;

        Vector3 end = start + new Vector3(xDir, 0, zDir);

        StartCoroutine(SmoothMovement(end));

        return false;
    }

    public IEnumerator SmoothMovement(Vector3 end)
    {
        float sqrRemainingDistance = (transform.position - end).magnitude;

        print(sqrRemainingDistance);

        yield return null;
    }

    // 코인과 충돌지 코인 획득과 코인파괴
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "Coin")
        {
            // 스코어 1추가
            _uiManager.CoinUp();
            // 보너스 사운드 재생
            // 코인 삭제
            Destroy(collision.gameObject);
            //
        }
    }
}