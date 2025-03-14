//klasa postać, po której dziedziczą inne postacie
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TurnBattle
{
    public abstract class Character
    {
        public string Name { get;}
        public int Health { get;  set; }
        public int MaxHealth { get; }
        public int AttackDamage { get; }
        public int Defense { get; }
        public string AbilityName { get; }
        public int AbilityPower { get; }
        public int Mana { get; protected set; }
        public int MaxMana { get; }
        // Ile many kosztuje użycie umiejętności
        public int AbilityManaCost { get; }
        public int HealingItem { get; set; }
        public Character(string name, int health, int attackDamage, int defense, string abilityName, int abilityPower, int mana,int maxMana, int abilityManaCost)
        {
            if (string.IsNullOrWhiteSpace(name)) throw new ArgumentException("Name cannot be empty.", nameof(name));
            if (health <= 0) throw new ArgumentOutOfRangeException(nameof(health), "Health must be positive.");
            if (attackDamage < 0) throw new ArgumentOutOfRangeException(nameof(attackDamage), "Attack Damage cannot be negative.");
            if (defense < 0) throw new ArgumentOutOfRangeException(nameof(defense), "Defense cannot be negative.");
            if (string.IsNullOrWhiteSpace(abilityName)) throw new ArgumentException("Ability cannot be empty.", nameof(abilityName));
            if (abilityPower <= 0) throw new ArgumentOutOfRangeException(nameof(abilityPower), "AbilityPower must be positive.");

            Name = name;
            Health = health;
            MaxHealth = health;
            AttackDamage = attackDamage;
            Defense = defense;
            AbilityName = abilityName;
            AbilityPower = abilityPower;
            HealingItem = 1;
            Mana = 0;
            MaxMana = maxMana;
            AbilityManaCost=abilityManaCost;
        }

        public bool IsAttackCritical()
        {
            Random random = new Random();
            int chance = random.Next(1, 101);
            return chance <= 20;
        }
        public abstract void Attack(Character target); //metoda ataku, która jest abstrakcyjna, ponieważ każda postać atakuje inaczej
        
         public virtual void TakeDamage(int damage)
        {
            int finalDamage = Math.Max(damage - Defense, 0);
            Health = Math.Max(Health - finalDamage, 0);
        }

        
        public virtual void Heal()
        {
            if (Health == MaxHealth) throw new InvalidOperationException("Cannot heal at full health.");
            Health = (int)(Health + (MaxHealth - Health) * 0.7);
            Console.WriteLine($"{Name} uses a healing item and restores 70% of their missing health!");
            HealingItem--;
        }

        public bool HasHealingItem => HealingItem > 0;
        public bool CanUseAbility => Mana >= AbilityManaCost;
        public abstract void UseAbility(Character target);
        public virtual void RegenerateMana(int amount)
        {
            if (amount < 0) return;
            Mana = Math.Min(Mana + amount, MaxMana);
        }
        
    }
}