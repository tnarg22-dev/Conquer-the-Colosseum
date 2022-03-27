public struct CurrentHealth
{
    public float previous;
    public float current;
    public float percentage;

    public CurrentHealth(float previousHealth, float currentHealth, float percentage) : this()
    {
        this.previous = previousHealth;
        this.current = currentHealth;
        this.percentage = percentage;
    }
}