using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    //플레이어 담을 변수
    private Player player;

    // Use this for initialization
    private void Start()
    {
        if (player == null)
        {
            player = GameObject.FindObjectOfType<Player>();
        }
    }

    // Update is called once per frame
    private void Update()
    {
        HandleInput();
    }

    //실제 인풋이 들어 오는 함수
    public void HandleInput()
    {
        if (Input.GetMouseButtonDown(0))
        {
            //마우스가 누른다
            print("마우스가 누른다");
        }
        else if (Input.GetMouseButton(0))
        {
            //마우스 드레그 중인가
            print("마우스 드레그 중인가");
        }
        else if (Input.GetMouseButtonUp(0))
        {
            //마우스를 띄였을 때
            print("마우스를 띄였을 때");
        }
    }
}