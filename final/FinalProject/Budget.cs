using System;
using System.Collections.Generic;
using System.IO;

public abstract class Budget
{
    protected string _month;
    protected int _year;
    protected List<string> categories;

    public Budget(string month, int year)
    {
        _month = month;
        _year = year;
        categories = new List<string>();
    }

    public string GetMonth()
    {
        return _month;
    }

    public int GetYear()
    {
        return _year;
    }

    public void SetMonth(string month)
    {
        _month = month;
    }

    public void SetYear(int year)
    {
        _year = year;
    }

    public abstract string CategorizeExpense(string item);
    public abstract bool IsFinished();

    public void AddCategory(string category)
    {
        categories.Add(category);
    }

    public List<string> GetCategories()
    {
        return categories;
    }
}
