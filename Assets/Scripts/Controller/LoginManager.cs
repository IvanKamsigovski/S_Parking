using System.Collections;
using UnityEngine;
using UnityEngine.Networking;
using TMPro;
using UnityEngine.SceneManagement;

public class LoginManager : MonoBehaviour
{
    //ivan@gmai.com

    // public TMP_InputField l_email;
    // public TMP_InputField l_password;

    // string l_email = GameObject.Find("LoginUsername").GetComponent<TMP_InputField>().text;
    // string l_password = GameObject.Find("LoginPassword").GetComponent<TMP_InputField>().text;

    string token;

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

    #region login
    public void SubmitLoginForm()
    {
        string l_email = GameObject.Find("LoginUsername").GetComponent<TMP_InputField>().text;
        string l_password = GameObject.Find("LoginPassword").GetComponent<TMP_InputField>().text;

        if (string.IsNullOrEmpty(l_email) )
         {
             SceneController.Instance.ChangeAutentichationMessage("Email is empty");
         }
         if (string.IsNullOrEmpty(l_password))
         {
            SceneController.Instance.ChangeAutentichationMessage("Password is empty");
         }
         if (!string.IsNullOrEmpty(l_email) && !string.IsNullOrEmpty(l_password))
         {
             StartCoroutine(SendLoginData(l_email, l_password));
         }
    }

    private IEnumerator SendLoginData(string Email, string Password)
    {
        
        var user = new User
        {
            email = Email,
            password = Password
        };

        Routes.CookieString = null;

        var request = Routes.Post(Routes.loginUrl, JsonUtility.ToJson(user));
        yield return request.SendWebRequest();

        if (request.isNetworkError || request.isHttpError)
        {
            Debug.Log(request.error);
            SceneController.Instance.ChangeAutentichationMessage("Invalid email or password");
        }
        else
        {
            //Nisam siguran za splitanje
            Routes.CookieString = request.GetResponseHeader("set-cookie").Split('=')[1];
            //Routes.CookieString = request.downloadHandler.text.Split(',') [1];

            Debug.Log(Routes.CookieString);
           // Debug.Log(request.downloadHandler.text.Split(',') [1]);
            SceneManager.LoadScene(3);
        }
    }
    #endregion

    #region reservation

    #endregion
}

