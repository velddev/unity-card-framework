public interface ITargetable
{
    void AddHealth(int value);
    int GetHealth();

    void AddMana(int value);
    int GetMana();

    void AddArmor(int value);
    int GetArmor();

    bool IsAlive();
}