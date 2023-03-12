using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ButtonSave : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject PanelForDimension;
    public GameObject Rooms;
    public void modifyDimesion()
    {

        string test =(PanelForDimension.transform.Find("NomPiece").GetComponent<TextMeshProUGUI>().text).ToString();
       Rooms.transform.Find(test).transform.localScale = new Vector3(float.Parse(PanelForDimension.transform.Find("DonneeLongueur").Find("Text Area").gameObject.GetComponentInChildren<TextMeshProUGUI>().text), Rooms.transform.Find(test).transform.localScale.y, float.Parse(PanelForDimension.transform.Find("DonneeLargeur").Find("Text Area").gameObject.GetComponentInChildren<TextMeshProUGUI>().text));
        Rooms.transform.Find(test).Find("MurArriere").transform.localScale = new Vector3( Rooms.transform.Find(test).transform.Find("MurArriere").transform.localScale.x, float.Parse(PanelForDimension.transform.Find("DonneeHauteurArriere").Find("Text Area").gameObject.GetComponentInChildren<TextMeshProUGUI>().text), Rooms.transform.Find(test).transform.Find("MurArriere").transform.localScale.z);
        Rooms.transform.Find(test).Find("MurAvant").transform.localScale = new Vector3(Rooms.transform.Find(test).transform.Find("MurAvant").transform.localScale.x, float.Parse(PanelForDimension.transform.Find("DonneeHauteurAvant").Find("Text Area").gameObject.GetComponentInChildren<TextMeshProUGUI>().text), Rooms.transform.Find(test).transform.Find("MurAvant").transform.localScale.z);
        Rooms.transform.Find(test).Find("MurDroit").transform.localScale = new Vector3(Rooms.transform.Find(test).transform.Find("MurDroit").transform.localScale.x, float.Parse(PanelForDimension.transform.Find("DonneeHauteurDroit").Find("Text Area").gameObject.GetComponentInChildren<TextMeshProUGUI>().text), Rooms.transform.Find(test).transform.Find("MurDroit").transform.localScale.z);
        Rooms.transform.Find(test).Find("MurGauche").transform.localScale = new Vector3(Rooms.transform.Find(test).transform.Find("MurGauche").transform.localScale.x, float.Parse(PanelForDimension.transform.Find("DonneeHauteurGauche").Find("Text Area").gameObject.GetComponentInChildren<TextMeshProUGUI>().text), Rooms.transform.Find(test).transform.Find("MurGauche").transform.localScale.z);


    }


}
