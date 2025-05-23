using System;
using System.Collections.Generic;

class FoodItem
{
    public string Name { get; set; }
    public int Calories { get; set; }

    public FoodItem(string name, int calories)
    {
        Name = name;
        Calories = calories;
    }

    public void DisplayInfo()
    {
        Console.WriteLine($"Jedzenie: {Name}, Kalorie: {Calories} kcal");
    }
}
class Meal
{
    public string Name { get; set; }
    public List<FoodItem> FoodItems { get; set; }

    public Meal(string name)
    {
        Name = name;
        FoodItems = new List<FoodItem>();
    }

    public void AddFood(FoodItem food)
    {
        FoodItems.Add(food);
    }

    public int GetTotalCalories()
    {
        int total = 0;
        foreach (var food in FoodItems)
        {
            total += food.Calories;
        }
        return total;
    }

    public void DisplayMealInfo()
    {
        Console.WriteLine($"Posiłek: {Name}");
        Console.WriteLine("Składniki:");
        foreach (var food in FoodItems)
        {
            food.DisplayInfo();
        }
        Console.WriteLine($"Łącznie: {GetTotalCalories()} kcal\n");
    }
}
class DailyIntake
{
    public List<Meal> Meals { get; set; }

    public DailyIntake()
    {
        Meals = new List<Meal>();
    }

    public void AddMeal(Meal meal)
    {
        Meals.Add(meal);
    }
}