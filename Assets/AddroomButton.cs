using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;


public class AddroomButton : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform m_ContentContainer;
    public GameObject buttonTemplate;
    public GameObject Pannel2;
    public GameObject Pannel1;
    public TMP_Dropdown dropdown;
    public List<GameObject> gameobjectlist;

     void Start()
    {
        gameobjectlist= new List<GameObject>(Resources.LoadAll<GameObject>("Room"));
        foreach(GameObject go in gameobjectlist) { Debug.Log(go.name); }
       
    }
    public void Click()
    {

        gameobjectlist = new List<GameObject>(Resources.LoadAll<GameObject>("Room"));
        foreach (GameObject go in gameobjectlist) { Debug.Log(go.name); }


        var newItem = Instantiate(buttonTemplate);
        
        newItem.name = dropdown.name;
        newItem.GetComponentInChildren<TMP_Text>().text = dropdown.GetComponentInChildren<TMP_Text>().text;
       

        newItem.transform.SetParent(m_ContentContainer.transform);
        newItem.transform.localScale = Vector2.one;
        Debug.Log(newItem.GetComponentInChildren<TMP_Text>().text);
        newItem.AddComponent<DimensionScript>().prefabOfSalle = Instantiate(gameobjectlist.Where(x => x.name == newItem.GetComponentInChildren<TMP_Text>().text).FirstOrDefault());
        newItem.GetComponent<DimensionScript>().PanelForDimension = Pannel2;
        newItem.GetComponent<Button>().onClick.AddListener(() => newItem.GetComponent<DimensionScript>().onClickForDimension());

        }

}
