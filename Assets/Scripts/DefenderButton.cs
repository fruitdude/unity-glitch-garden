using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DefenderButton : MonoBehaviour{

    [SerializeField] Defender defenderPrefab;

    SpriteRenderer spriteRenderer;

    // Start is called before the first frame update
    void Start(){
        spriteRenderer = GetComponent<SpriteRenderer>();
        LabelBUttonWithCost();
    }

    private void LabelBUttonWithCost() {
        Text costText = GetComponentInChildren<Text>();
        if (!costText) {
            Debug.LogError(name + "has no cost text, add text");
        } else {
            costText.text = defenderPrefab.GetStarCost().ToString();
        }
    }

    private void OnMouseDown() {
        var buttons = FindObjectsOfType<DefenderButton>();
        foreach(DefenderButton button in buttons) {
            button.GetComponent<SpriteRenderer>().color = new Color32(89, 89, 89, 255);
        }
        GetComponent<SpriteRenderer>().color = Color.white;
        FindObjectOfType<DefenderSpawner>().SetSelectedDefender(defenderPrefab);
    }
}
