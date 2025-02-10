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

        public Character(string name, int health, int attackDamage, int defense, string AbilityName, int AbilityPower)
        {
            if (string.IsNullOrWhiteSpace(name)) throw new ArgumentException("Name cannot be empty.", nameof(name));
            if (health <= 0) throw new ArgumentOutOfRangeException(nameof(health), "Health must be positive.");
            if (attackDamage < 0) throw new ArgumentOutOfRangeException(nameof(attackDamage), "AttackDamage cannot be negative.");
            if (defense < 0) throw new ArgumentOutOfRangeException(nameof(defense), "Defense cannot be negative.");
            if (string.IsNullOrWhiteSpace(abilityName)) abilityName = "No Ability";
            if (abilityPower < 0) abilityPower = 0;

            Name = name;
            Health = health;
            MaxHealth = health;
            AttackDamage = attackDamage;
            Defense = defense;
            AbilityName = abilityName;
            AbilityPower = abilityPower;
        }

        public abstract void Attack(Character target); //metoda ataku, która jest abstrakcyjna, ponieważ każda postać atakuje inaczej
    }
}