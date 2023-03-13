using System.Runtime.InteropServices;
using TMPro;
using UnityEngine;

public class ButtonSave : MonoBehaviour
{
    // Start is called before the first frame update

    // public GameObject PanelForDimension;

  
    public void modifyDimesion()
    {
        var PanelForDimension = GameObject.Find("panelDimension");
        var original  = GameObject.Find(PanelForDimension.transform.Find("NomPiece").GetComponent<TextMeshProUGUI>().text);
        var test = Instantiate( GameObject.Find(PanelForDimension.transform.Find("NomPiece").GetComponent<TextMeshProUGUI>().text));

        foreach(string x in test.GetComponent<CollisionTrigger>().collisionlist)
        {
            Debug.Log(x + "TEST COLLISION LISt ---------------");
        }
        Debug.Log(test.name);
      
        //string test =(PanelForDimension.transform.Find("NomPiece").GetComponent<TextMeshProUGUI>().text).ToString();
        if (!string.IsNullOrWhiteSpace(PanelForDimension.transform.Find("DonneeLongueur").GetComponentInChildren<TMP_InputField>().text))
        {
            if (!original.GetComponent<CollisionTrigger>().front)
            {
                float scalePetit = test.transform.Find("MurAvant").Find("MurD").localScale.x ;
                float movex = ((scalePetit * float.Parse(PanelForDimension.transform.Find("DonneeLongueur").GetComponentInChildren<TMP_InputField>().text)) + 1) / 2;
                test.transform.Find("MurAvant").Find("MurD").position = new Vector3(movex, test.transform.Find("MurAvant").Find("MurD").localScale.y, test.transform.Find("MurAvant").Find("MurD").localScale.z);
                test.transform.Find("MurAvant").Find("MurG").position = new Vector3(-movex, test.transform.Find("MurAvant").Find("MurG").localScale.y, test.transform.Find("MurAvant").Find("MurG").localScale.z);

                test.transform.Find("MurArriere").Find("MurG").position = new Vector3(movex, test.transform.Find("MurArriere").Find("MurG").localScale.y, test.transform.Find("MurArriere").Find("MurG").localScale.z);
                test.transform.Find("MurArriere").Find("MurD").position = new Vector3(-movex, test.transform.Find("MurArriere").Find("MurD").localScale.y, test.transform.Find("MurArriere").Find("MurD").localScale.z);

                test.transform.Find("MurAvant").Find("MurD").position = new Vector3(scalePetit * float.Parse(PanelForDimension.transform.Find("DonneeLongueur").GetComponentInChildren<TMP_InputField>().text), test.transform.Find("MurAvant").Find("MurD").localScale.y, test.transform.Find("MurAvant").Find("MurD").localScale.z);
                test.transform.Find("MurAvant").Find("MurG").position = new Vector3(scalePetit * float.Parse(PanelForDimension.transform.Find("DonneeLongueur").GetComponentInChildren<TMP_InputField>().text), test.transform.Find("MurAvant").Find("MurG").localScale.y, test.transform.Find("MurAvant").Find("MurG").localScale.z);

                test.transform.Find("MurArriere").Find("MurG").position = new Vector3(scalePetit * float.Parse(PanelForDimension.transform.Find("DonneeLongueur").GetComponentInChildren<TMP_InputField>().text), test.transform.Find("MurArriere").Find("MurG").position.y, test.transform.Find("MurArriere").Find("MurG").localScale.z);
                test.transform.Find("MurArriere").Find("MurD").position = new Vector3(scalePetit * float.Parse(PanelForDimension.transform.Find("DonneeLongueur").GetComponentInChildren<TMP_InputField>().text), test.transform.Find("MurArriere").Find("MurD").position.y, test.transform.Find("MurArriere").Find("MurD").localScale.z);

                test.transform.Find("MurAvant").Find("MurHaut").localScale = new Vector3((scalePetit * 2) +1, test.transform.Find("MurArriere").Find("MurHaut").localScale.y, test.transform.Find("MurArriere").Find("MurHaut").localScale.z);
                test.transform.Find("MurArriere").Find("MurHaut").localScale = new Vector3((scalePetit * 2) + 1, test.transform.Find("MurArriere").Find("MurHaut").localScale.y, test.transform.Find("MurArriere").Find("MurHaut").localScale.z);

                test.transform.Find("MurAvant").position = ()
            }

            test.transform.localScale = new Vector3(float.Parse(PanelForDimension.transform.Find("DonneeLongueur").GetComponentInChildren<TMP_InputField>().text), test.transform.localScale.y, test.transform.localScale.z);


            if (test.GetComponent<CollisionTrigger>().collisionlist.Count == 0)
            {
                original.transform.localScale = new Vector3(float.Parse(PanelForDimension.transform.Find("DonneeLongueur").GetComponentInChildren<TMP_InputField>().text), test.transform.localScale.y, test.transform.localScale.z);
            }


        }
        if (!string.IsNullOrWhiteSpace(PanelForDimension.transform.Find("DonneeLargeur").GetComponentInChildren<TMP_InputField>().text))


        {
            test.transform.localScale = new Vector3(test.transform.localScale.x, test.transform.localScale.y, float.Parse(PanelForDimension.transform.Find("DonneeLargeur").GetComponentInChildren<TMP_InputField>().text));
            if (test.GetComponent<CollisionTrigger>().collisionlist.Count == 0)
            {
                original.transform.localScale = new Vector3(test.transform.localScale.x, test.transform.localScale.y, float.Parse(PanelForDimension.transform.Find("DonneeLargeur").GetComponentInChildren<TMP_InputField>().text));
            }

            Debug.Log("Impossible d'ajuster a cette largeur puisqu'elle touche un autre objet");
        }


        if (!string.IsNullOrWhiteSpace(PanelForDimension.transform.Find("DonneeHauteurArriere").GetComponentInChildren<TMP_InputField>().text))
        {
            test.transform.Find("MurArriere").transform.localScale = new Vector3(test.transform.Find("MurArriere").transform.localScale.x, float.Parse(PanelForDimension.transform.Find("DonneeHauteurArriere").GetComponentInChildren<TMP_InputField>().text), test.transform.Find("MurArriere").transform.localScale.z);

        }
        if (!string.IsNullOrWhiteSpace(PanelForDimension.transform.Find("DonneeHauteurAvant").GetComponentInChildren<TMP_InputField>().text))
        {
            test.transform.Find("MurAvant").transform.localScale = new Vector3(test.transform.Find("MurAvant").transform.localScale.x, float.Parse(PanelForDimension.transform.Find("DonneeHauteurAvant").GetComponentInChildren<TMP_InputField>().text), test.transform.Find("MurAvant").transform.localScale.z);

        }
        if (!string.IsNullOrWhiteSpace(PanelForDimension.transform.Find("DonneeHauteurDroit").GetComponentInChildren<TMP_InputField>().text))
        {
            test.transform.Find("MurDroit").transform.localScale = new Vector3(test.transform.Find("MurDroit").transform.localScale.x, float.Parse(PanelForDimension.transform.Find("DonneeHauteurDroit").GetComponentInChildren<TMP_InputField>().text), test.transform.Find("MurDroit").transform.localScale.z);

        }
        if (!string.IsNullOrWhiteSpace(PanelForDimension.transform.Find("DonneeHauteurGauche").GetComponentInChildren<TMP_InputField>().text))
        {
            test.transform.Find("MurGauche").transform.localScale = new Vector3(test.transform.Find("MurGauche").transform.localScale.x, float.Parse(PanelForDimension.transform.Find("DonneeHauteurGauche").GetComponentInChildren<TMP_InputField>().text), test.transform.Find("MurGauche").transform.localScale.z);

        }



        Destroy(test);


    }


}
