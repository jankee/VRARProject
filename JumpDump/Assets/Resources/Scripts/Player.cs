using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private float speed;
    private float delay;

    [SerializeField]
    private float hp;

    private Animator animator;

    private PlayerHealth playerHealth;

    private InputManager inputManager;

    [SerializeField]
    private float speedTime;

    public float HP
    {
        get
        {
            return hp;
        }

        set
        {
            hp = value;
        }
    }

    // Use this for initialization
    private void Start()
    {
        animator = transform.GetChild(0).GetComponent<Animator>();

        playerHealth = GetComponent<PlayerHealth>();

        inputManager = GameObject.FindObjectOfType<InputManager>();
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
                StartCoroutine(SmoothMovement(Vector3.left, 0.5f));
                break;

            case "Back":
                this.transform.eulerAngles = new Vector3(0, 180, 0);
                StartCoroutine(SmoothMovement(Vector3.back, 0.5f));
                break;

            case "right":
                this.transform.eulerAngles = new Vector3(0, 90, 0);
                StartCoroutine(SmoothMovement(Vector3.right, 0.5f));
                break;

            case "up":
                this.transform.eulerAngles = new Vector3(0, 0, 0);
                StartCoroutine(SmoothMovement(Vector3.forward, 0.5f));

                break;
        }
    }

    /// <summary>
    /// 콜리젼과 콜라이더의 차이 점 때문에 코인은 여기서 처리
    /// </summary>
    /// <param name="other"></param>
    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Coin")
        {
            int value = other.transform.GetComponent<Coins>().CoinValue;
            GameManager.Instance.CoinUp(value);
            Destroy(other.gameObject);
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        switch (other.transform.tag)
        {
            case "Water":
                print("Water");

                playerHealth.TakeDamage(10f);
                StartCoroutine(FallIntoWater(2f));
                break;

            case "Raft":
                //Destroy(gameObject);
                TakeOnRaft(other);
                break;

            case "Vehicle":
                StartCoroutine(SmoothMovement(Vector3.back, 0.3f));
                StartCoroutine(TakeStun(1.3f));
                playerHealth.TakeDamage(20f);
                break;

            case "Train":
                StartCoroutine(SmoothMovement(Vector3.back, 0.3f));
                StartCoroutine(TakeStun(2.3f));
                playerHealth.TakeDamage(60f);
                break;
        }
    }

    public void OnCollisionExit(Collision other)
    {
        if (other.transform.tag == "Raft")
        {
            this.transform.parent = null;
        }
    }

    private void TakeOnRaft(Collision other)
    {
        this.transform.SetParent(other.transform);
    }

    /// <summary>
    /// MoveCharacter에서 값을 받아 움직임
    /// </summary>
    /// <param name="end"></param>
    /// <returns></returns>
    private IEnumerator SmoothMovement(Vector3 end, float aniTime)
    {
        // 움직임이 있을 때 다시 입력이 들어오면 리턴
        //if (InputManager.Instance.IsMoved == true)
        //{
        //    yield break;
        //}

        inputManager.IsMoved = true;
        inputManager.IsBakeMoved = true;

        float timer = aniTime;
        float cooltime = 0f;

        //자신의 위치 값에 받은 end값을 더 함
        Vector3 starPos = this.transform.position;

        starPos = FloatRound(starPos);
        print("starPos : " + starPos);

        Vector3 endPos = starPos + end;

        endPos = FloatRound(endPos);
        print("endPos : " + endPos);

        //만약 데미지 값이 있다면
        if (aniTime == 0.3f)
        {
            animator.SetTrigger("DAMAGE");
        }

        //카메라 셋팅
        Camera.main.GetComponent<Camerafollow>().OriginPosition(endPos);

        while (cooltime < timer)
        {
            cooltime += Time.deltaTime;

            this.transform.position = Vector3.Lerp(starPos, endPos, cooltime / timer);

            yield return null;
        }

        //캐릭터 움직임 마무리
        transform.position = endPos;

        inputManager.IsMoved = false;
        inputManager.IsBakeMoved = false;

        GameManager.Instance.ScoreUp();

        //로드 제네레이터의 플레이어 함수를 찾는다
        RoadGenerator.Instance.FindPlayer();
    }

    // 소수점값을 반올림 한다
    private Vector3 FloatRound(Vector3 value)
    {
        value = new Vector3(Mathf.Round(value.x), Mathf.Round(value.y), Mathf.Round(value.z));

        return value;
    }

    public IEnumerator FallIntoWater(float value)
    {
        inputManager.IsStun = true;

        animator.SetBool("WATER", true);

        yield return new WaitForSeconds(value);

        animator.SetBool("WATER", false);

        inputManager.IsStun = false;
    }

    public IEnumerator TakeStun(float value)
    {
        inputManager.IsStun = true;

        yield return new WaitForSeconds(value);

        animator.SetBool("STUN", false);

        inputManager.IsStun = false;
    }
}