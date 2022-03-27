public struct MaximumHealth
{
    public float previous;
    public float current;

    public MaximumHealth(float previousMaximumHealth, float currentMaximumHealth) : this()
    {
        this.previous = previousMaximumHealth;
        this.current = currentMaximumHealth;
    }
}