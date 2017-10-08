using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class popbuttoninjury : MonoBehaviour {

    public GameObject pHeart;
    public RectTransform ParentPanel;
	public int difficulte;

    // Use this for initialization
    void Start () {
    
        GameObject goButton = Instantiate(pHeart) as GameObject; 
        goButton.transform.SetParent(ParentPanel, false);
        goButton.transform.localScale = new Vector3(1, 1, 1);
        var x = 0;
        var y = 0;

        while(x > -5 && x < 68 && y > -76 && y < 35)
        {
            x = Random.Range(-188, 306);
            y = Random.Range(-159, 105);
        }
        goButton.transform.localPosition = new Vector2(x, y);

		PlayerPrefs.SetInt ("difficulte", difficulte);
        Button tempButton = goButton.GetComponent<Button>();

        tempButton.onClick.AddListener(() => ButtonClicked(goButton));
    }

    

    // Update is called once per frame
    void Update () {
		
	}

    public void ButtonClicked(GameObject goButton)
    {
        goButton.transform.localScale += new Vector3(5, 5, 5);
    }


}
