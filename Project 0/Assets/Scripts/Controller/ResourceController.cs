using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.UIElements;
using Button = UnityEngine.UI.Button;
using UnityEngine.UI;

public class ResourceController : MonoBehaviour
{
    public ResourceModel Resource;
    public Button AddButton;
    public Button RemoveButton;
    public int AddAmount;
    public int RemoveAmount;

    public void Start()
    {
        this.AddButton.onClick.AddListener(()=>{AddGold(AddAmount);});
        this.RemoveButton.onClick.AddListener(() => { RemoveGold(RemoveAmount);});
    }

    public void AddGold(float amount)
    {
        Resource.amount += amount;
        Resource.Trigger();
//        var buttons = this.GetComponentsInChildren<Button>();
//        foreach (var button in buttons)
//        {
//            button.interactable = false;
//        }
    }

    public void RemoveGold(float amount)
    {
        Resource.amount -= amount;
        Resource.Trigger();
    }
}
