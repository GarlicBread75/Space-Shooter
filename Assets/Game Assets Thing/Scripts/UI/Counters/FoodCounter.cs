using TMPro;
using UnityEngine;

public class FoodCounter : MonoBehaviour
{
    public TextMeshProUGUI counter;
    int foods;

    RocketCounter rockets;

    private void Start()
    {
        rockets = GameObject.Find("RCO").GetComponent<RocketCounter>();
    }

    void Update()
    {
        if (foods >= 50)
        {
            foods = 0;
            rockets.AddRocket(1);
        }
        ShowFoods();
    }

    public void ShowFoods()
    {
        counter.text = foods.ToString();
    }

    public void AddFood(int foodsNum)
    {
        foods += foodsNum;
    }
}
