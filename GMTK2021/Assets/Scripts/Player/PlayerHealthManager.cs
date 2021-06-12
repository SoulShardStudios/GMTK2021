using System.Collections.Generic;
public static class PlayerHealthManager
{
    static readonly int _startingHealth = 10;
    static int _health;
    static public Timer damageCooldown = new Timer(1);
    static List<Player> _players = new List<Player>(0);
    public static void AddToManager(Player player) => _players.Add(player);
    public static void Init() => _health = _startingHealth;
    public static void ApplyDamage(int damage)
    {
        if (damageCooldown.IsDone())
        {
            _health -= damage;
            if (_health < 0)
            {
                foreach (Player p in _players)
                    p.Death();
                return;
            }
            foreach (Player p in _players)
                p.animator.StartDamageFlash();
            GameUIControler.S.UpdateHPUI((float)_health / _startingHealth);
            damageCooldown.Reset();
        }
    }
}