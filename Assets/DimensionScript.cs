using System.Collections.Generic;
using TMPro;
using UnityEngine;
public class DimensionScript : MonoBehaviour
{
    private TextMeshProUGUI largeurMur;
    private TextMeshProUGUI longeurMur;
    private TextMeshProUGUI hauteurMurArriere;
    private TextMeshProUGUI hauteurMurAvant;
    private TextMeshProUGUI hauteurMurDroit;
    private TextMeshProUGUI hauteurMurGauche;
    //will be receive by the name of the button we click
    public GameObject prefabOfSalle;
    public GameObject PanelForDimension;
    public int boutonId;
    static private Dictionary<int, GameObject> matchboutton = new Dictionary<int, GameObject>();

    static private int id = 0;
    void Start()
    {
        setDimension();

    }

    public void onClickForDimension()
    {

        PanelForDimension.SetActive(true);
        SeeDimension();
       

    }

    private void SeeDimension()
    {


    }

    private void modifyDimesion()
    {

    }

    private void setDimension()
    {
        id = id + 1;
        Debug.Log(prefabOfSalle.name);
        var prefab = Instantiate(prefabOfSalle);
        prefab.name = prefab.name + id;
        Debug.Log(prefab.name.ToString());
        PanelForDimension.transform.Find("DonneeLongueur").Find("Text Area").gameObject.GetComponentInChildren<TextMeshProUGUI>().text = prefab.transform.localScale.x.ToString(); //prefab.transform.localScale.z.ToString();
        PanelForDimension.transform.Find("DonneeLargeur").Find("Text Area").gameObject.GetComponentInChildren<TextMeshProUGUI>().text = prefab.transform.localScale.z.ToString();
        PanelForDimension.transform.Find("DonneeHauteurArriere").Find("Text Area").gameObject.GetComponentInChildren<TextMeshProUGUI>().text = prefab.transform.Find("MurArriere").gameObject.transform.localScale.y.ToString();
        PanelForDimension.transform.Find("DonneeHauteurAvant").Find("Text Area").gameObject.GetComponentInChildren<TextMeshProUGUI>().text = prefab.transform.Find("MurAvant").gameObject.transform.localScale.y.ToString();
        PanelForDimension.transform.Find("DonneeHauteurDroit").Find("Text Area").gameObject.GetComponentInChildren<TextMeshProUGUI>().text = prefab.transform.Find("MurDroit").gameObject.transform.localScale.y.ToString();
        PanelForDimension.transform.Find("DonneeHauteurGauche").Find("Text Area").gameObject.GetComponentInChildren<TextMeshProUGUI>().text = prefab.transform.Find("MurGauche").gameObject.transform.localScale.y.ToString();

    }

}
// Start is called before the first frame update

