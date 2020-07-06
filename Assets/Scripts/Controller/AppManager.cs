using System.Collections;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;
using TMPro;


public class AppManager : MonoBehaviour
{
    public TextMeshProUGUI responseText;

    public Image[] imgPrefArray;


    public void Request()
    {
        StartCoroutine(getData());
    }

    
    //Dohvacanje API-a
    IEnumerator getData()
    {
        string APIurl = "http://smart.sum.ba/parking?withParkingSpaces=1";


        using (UnityWebRequest webData = UnityWebRequest.Get(APIurl))
        {
            yield return webData.SendWebRequest();

            if (webData.isNetworkError || webData.isHttpError)
            {
                print("ERROR");
                Debug.Log(webData.error);
            }
            else {
                if (webData.isDone)
                {
                    string jsonData = System.Text.Encoding.UTF8.GetString(webData.downloadHandler.data);
                    Debug.Log(jsonData);

                    processJsonData(jsonData);
                }
            }
        }
    }

    #region ProcesData
    //Obrada JSON podataka
    private void processJsonData(string data)
    {
        RootObject[] entities =
                       JsonHelper.getJsonArray<RootObject>(data);
        int br = 0;

        responseText.text = entities[0].normal_occupied.ToString();

        //Provjera zauzetosti parkinga
         for (int i = 0; i < 62; i++)
         {
                if ((entities[0].parkingSpaces[i].occupied == 0))
                {
                    imgPrefArray[br].color = Color.red;
                }
            br++;
        }
    }
    #endregion

}
