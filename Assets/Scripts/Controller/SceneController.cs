using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    public static SceneController Instance { set; get; }


    private void Start()
    {
        Instance = this;
    }

    public void SceneParking()
    {
        SceneManager.LoadScene(1);
    }
    public void SceneLogin()
    {
        SceneManager.LoadScene(2);
    }
    public void ChangeAutentichationMessage(string msg)
    {
        GameObject.Find("AutenticationMsgText").GetComponent<TextMeshProUGUI>().text = msg;
    }
}
