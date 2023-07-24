using UnityEngine;

public class Loginwithkakaoaccount : MonoBehaviour
{
    public GameObject kakaoAccountLoginPanel; // 게임 계정 로그인 패널
    public GameObject loginTabPanel; // 로그인 탭 패널

    // "카카오 계정으로 로그인" 버튼 클릭 시 호출되는 함수
    public void OnKakaoAccountLoginButtonClick()
    {
        kakaoAccountLoginPanel.SetActive(true); // 게임 계정 로그인 패널 활성화
        loginTabPanel.SetActive(false); // 로그인 탭 패널 비활성화
    }
}

