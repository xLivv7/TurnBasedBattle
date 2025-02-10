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
        public int Health { get; private set; }
        public int MaxHealth { get; }
        public int AttackDamage { get; }
        public int Defense { get; }
        public string AbilityName { get; }
        public int AbilityPower { get; }
        private int _attacksCount;
        public Character(string name, int health, int attackDamage, int defense, string abilityName, int abilityPower)
        {
            if (string.IsNullOrWhiteSpace(name)) throw new ArgumentException("Name cannot be empty.", nameof(name));
            if (health <= 0) throw new ArgumentOutOfRangeException(nameof(health), "Health must be positive.");
            if (attackDamage < 0) throw new ArgumentOutOfRangeException(nameof(attackDamage), "AttackDamage cannot be negative.");
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
        }

        public abstract void Attack(Character target); //metoda ataku, która jest abstrakcyjna, ponieważ każda postać atakuje inaczej
        protected void IncrementAttackCount()
        {
            _attacksCount++;
        }
         public virtual void TakeDamage(int damage)
        {
            int finalDamage = Math.Max(damage - Defense, 0);
            Health = Math.Max(Health - finalDamage, 0);
        }
        public virtual void Heal(int amount)
        {
            Health = Math.Min(Health + amount, MaxHealth);
        }

        public bool CanUseAbility => _attacksCount >= 3;
        public abstract void UseAbility(Character target);
        public void ResetAttackCount()
        {
            _attacksCount = 0;
        }

    }
}