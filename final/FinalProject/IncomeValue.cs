public class IncomeValue
{
    private float _amount; // Private field to keep encapsulation

    public IncomeValue(float amount) // Constructor 
    {
        _amount = amount;
    }

    public float GetAmount() //Getter
    {
        return _amount;
    }
}