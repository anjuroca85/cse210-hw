public class SpendingValue
{
    private float _amount; // Private field to keep encapsulation

    public SpendingValue(float amount) // Constructor 
    {
        _amount = amount;
    }

    public float GetAmount() //Getter
    {
        return _amount;
    }
}