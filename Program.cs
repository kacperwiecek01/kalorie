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
    public int GetDailyCalories()
    {
        int total = 0;
        foreach (var meal in Meals)
        {
            total += meal.GetTotalCalories();
        }
        return total;
    }

    public void DisplayDailySummary()
    {
        Console.WriteLine("=== PODSUMOWANIE DNIA ===");
        foreach (var meal in Meals)
        {
            meal.DisplayMealInfo();
        }
        Console.WriteLine($"RAZEM DZIŚ: {GetDailyCalories()} kcal");
    }
}

class Program
{
    static void Main()
    {
        // Przykładowe użycie
        FoodItem banana = new FoodItem("Banan", 105);
        FoodItem oatmeal = new FoodItem("Płatki owsiane", 150);
        FoodItem chicken = new FoodItem("Kurczak", 200);
        FoodItem bread = new FoodItem("Chleb", 50);
        FoodItem tomato = new FoodItem("Pomidor", 30);

        Meal breakfast = new Meal("Śniadanie");
        breakfast.AddFood(banana);
        breakfast.AddFood(oatmeal);
        breakfast.AddFood(bread);
        breakfast.AddFood(tomato);

        Meal dinner = new Meal("Obiad");
        dinner.AddFood(chicken);

        DailyIntake today = new DailyIntake();
        today.AddMeal(breakfast);
        today.AddMeal(dinner);

        today.DisplayDailySummary();
    }
}