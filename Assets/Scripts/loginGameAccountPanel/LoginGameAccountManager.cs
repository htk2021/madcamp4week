using UnityEngine;
using TMPro;
using UnityEngine.Networking;
using System.Collections;

public class LoginGameAccountManager : MonoBehaviour
{
    public TMP_InputField gameIDInput; // 게임 ID 입력 필드
    public TMP_InputField passwordInput; // 비밀번호 입력 필드

    public GameObject homePanel; // 홈 탭 패널
    public GameObject loginGameAccountPanel; // 로그인 패널

    // 로그인 버튼 클릭 시 실행되는 함수
    public void OnLoginButtonClick()
    {
        string gameID = gameIDInput.text; // 게임 ID 가져오기
        string password = passwordInput.text; // 비밀번호 가져오기

        WWWForm form = new WWWForm();
        form.AddField("userId", gameID);
        form.AddField("password", password);

        string url = "http://172.10.5.141:80/user/checkAccount";

        UnityWebRequest www = UnityWebRequest.Post(url, form);

        StartCoroutine(SendJoinRequest(www));
    }

    // 로그인 요청 보내는 코루틴 함수
    private IEnumerator SendJoinRequest(UnityWebRequest www)
    {
        yield return www.SendWebRequest();

        if (www.result == UnityWebRequest.Result.ConnectionError || www.result == UnityWebRequest.Result.ProtocolError)
        {
            // 에러 처리
            Debug.LogError(www.error);
        }
        else
        {
            // 로그인 성공 시, 홈 화면으로 전환
            // TODO: 홈 화면으로 전환하는 코드 추가
            PlayerPrefs.SetString("userId", gameIDInput.text); //Playerprefs 이용해서 userId 앱 전체에서 유지시킴.
            homePanel.SetActive(true); // 홈 패널 활성화
            loginGameAccountPanel.SetActive(false); // 로그인 패널 비활성화
            Debug.Log("로그인 성공");
        }
    }
}
