using UnityEngine;
using TMPro;
using UnityEngine.Networking;
using System.Collections;

public class JoinManager : MonoBehaviour
{
    public TMP_InputField gameIDInput; // 게임 ID 입력 필드
    public TMP_InputField passwordInput; // 비밀번호 입력 필드
    public TMP_InputField nicknameInput; // 닉네임 입력 필드

    public GameObject homePanel; // 홈 탭 패널
    public GameObject joinPanel; // 회원가입 패널

    // 회원가입 버튼 클릭 시 실행되는 함수
    public void OnJoinButtonClick()
    {
        string gameID = gameIDInput.text; // 게임 ID 가져오기
        string password = passwordInput.text; // 비밀번호 가져오기
        string nickname = nicknameInput.text; // 닉네임 가져오기

        // 회원가입 요청을 보낼 WWW Form 데이터 생성
        WWWForm form = new WWWForm();
        form.AddField("userId", gameID);
        form.AddField("password", password);
        form.AddField("nickname", nickname);

        // 회원가입 요청을 보낼 서버 주소
        string url = "http://172.10.5.141:80/user/add";

        // UnityWebRequest를 사용하여 회원가입 요청 보내기
        UnityWebRequest www = UnityWebRequest.Post(url, form);

        // 비동기로 서버에 요청 보내기
        StartCoroutine(SendJoinRequest(www));
    }

    // 회원가입 요청 보내는 코루틴 함수
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
            // 회원가입 성공 시, 홈 화면으로 전환
            // TODO: 홈 화면으로 전환하는 코드 추가
            homePanel.SetActive(true); // 홈 패널 활성화
            joinPanel.SetActive(false); // 회원가입 패널 비활성화
            Debug.Log("회원가입 성공");
        }
    }
}
