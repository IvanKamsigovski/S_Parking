using UnityEngine;
using UnityEngine.Networking;

public class Routes
{
    public static readonly string loginUrl = "http://localhost:4000/api/user/login";
    public static readonly string reservationUrl = "http://localhost:4000/api/reservations";

    public static string CookieString
    {
        get
        {
            return PlayerPrefs.GetString("cookie");
        }
        set
        {
            PlayerPrefs.SetString("cookie", value);
        }
    }

    public static UnityWebRequest Post(string path, string jsonString)
    {
        var request = new UnityWebRequest(path, "POST");

        if (!string.IsNullOrEmpty(CookieString))
        {
           // request.SetRequestHeader("cookie", CookieString);
            request.SetRequestHeader("authorization", "Bearer " + CookieString);
        }

        byte[] bodyRaw = new System.Text.UTF8Encoding().GetBytes(jsonString);
        request.uploadHandler = (UploadHandler)new UploadHandlerRaw(bodyRaw);
        request.downloadHandler = (DownloadHandler)new DownloadHandlerBuffer();
        request.SetRequestHeader("Content-Type", "application/json");
        return request;
    }

    public static UnityWebRequest PostReservation(string path, string jsonString)
    {
        var request = new UnityWebRequest(path, "POST");

        request.SetRequestHeader("authorization", "Bearer " + CookieString);
        byte[] bodyRaw = new System.Text.UTF8Encoding().GetBytes(jsonString);
        request.uploadHandler = (UploadHandler)new UploadHandlerRaw(bodyRaw);
        request.downloadHandler = (DownloadHandler)new DownloadHandlerBuffer();
        request.SetRequestHeader("Content-Type", "application/json");
        //request.SetRequestHeader("authorization", "Bearer " + CookieString);

        return request;
    }
}
