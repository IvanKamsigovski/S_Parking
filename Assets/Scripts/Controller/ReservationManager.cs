using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.Networking;

public class ReservationManager : MonoBehaviour
{

    public TMP_Dropdown parkingName;
    public TMP_InputField dateField;
    public TMP_Dropdown arivalTime;
    public TMP_Dropdown timeDropdown;

    private List<string> parking = new List<string>() { "P-1", "P-2", "P-3", "P-4" };
   // private List<DateTime> date = new List<DateTime>();
    private List<string> arival = new List<string>() {"10:00", "11:00", "14:00", "18:00" };
    private List<string> timeL = new List<string>() { "1", "2", "3", "4", "5", "6" };

    private void Start()
    {
        //parkingName.ClearOptions();
       // StartCoroutine(getParkingName());
        populateLists();
    }



    #region eventHandlers
    public void SubmitReservation()
    {
        string parkingSpot = parkingName.options[parkingName.value].text;
        string arival = arivalTime.options[arivalTime.value].text;
        string stayingTime = timeDropdown.options[timeDropdown.value].text;
         StartCoroutine(createReservation(parkingSpot, dateField.text, arival, stayingTime));
    }

    #endregion

    #region getData
   /* IEnumerator getParkingName()
    {
        string url = "http://smart.sum.ba/parking?withParkingSpaces=1";

        using (UnityWebRequest www = UnityWebRequest.Get(url))
        {
            yield return www.SendWebRequest();

            if (www.isNetworkError || www.isHttpError)
            {
                Debug.Log(www.isNetworkError);
            }
            else
            {
                if (www.isDone)
                {
                    Debug.Log("Dobar");
                    string jsonData = System.Text.Encoding.UTF8.GetString(www.downloadHandler.data);

                    PopulateNameList(jsonData);
                }
            }
        }
    }*/
    #endregion

    #region sendData
   /* public static UnityWebRequest Post(string path, string jsonString)
    {
        var request = new UnityWebRequest(path, "POST");

        byte[] bodyRaw = new System.Text.UTF8Encoding().GetBytes(jsonString);
        request.uploadHandler = (UploadHandler)new UploadHandlerRaw(bodyRaw);
        request.downloadHandler = (DownloadHandler)new DownloadHandlerBuffer();
        request.SetRequestHeader("Content-Type", "application/json");
        return request;
    }*/
    private IEnumerator createReservation(string Parking, string Date, string Time, string Quantity)
    {
       // dateField.text = String.Format("{0:yyyy-MM-dd}", Date);
        var reservation = new Reservation
        {
            parking = Parking,
            datum = Date,
            time = Time,
            quantity = Quantity
        };

        

        var request = Routes.PostReservation(Routes.reservationUrl, JsonUtility.ToJson(reservation));

        yield return request.SendWebRequest();



        if (request.isNetworkError || request.isHttpError)
        {
            Debug.Log(request.error);

            Debug.Log(Routes.CookieString);
        }
        else
        {
            Debug.Log("-----------------------------");
            Debug.Log(Routes.CookieString);
            Debug.Log(request.downloadHandler.text);
        }
    }
    #endregion

    #region dropDown
   /* void PopulateNameList(string data)
    {
        RootObject[] entities =
                       JsonHelper.getJsonArray<RootObject>(data);


        //Provjera zauzetosti parkinga
         for (int i = 0; i < 62; i++)
         {
            parkingName.options.AddRange(
            entities.Select(x =>
            new TMP_Dropdown.OptionData()
            {
                text = x.parkingSpaces[i].parking_space_name
            }).ToList());

        }
        parkingName.value = 0;
    }*/
    void populateLists()
    {

        parkingName.AddOptions(parking);
        timeDropdown.AddOptions(timeL);
        arivalTime.AddOptions(arival);
    }
    #endregion
}
