using UnityEngine;

public class Joinwithgameaccount : MonoBehaviour
{
    public GameObject joinPanel; // 게임 계정 로그인 패널
    public GameObject loginTabPanel; // 로그인 탭 패널

    // "회원가입" 버튼 클릭 시 호출되는 함수
    public void OnJoinButtonClick()
    {
        joinPanel.SetActive(true); // 게임 계정 로그인 패널 활성화
        loginTabPanel.SetActive(false); // 로그인 탭 패널 비활성화
    }
}


