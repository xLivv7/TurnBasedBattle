using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TurnBattle
{
    public class Warrior : Character
    {
        public Warrior(string name, int health, int attackDamage, int defense, string abilityName, int abilityPower, int mana, int maxMana, int abilityManaCost) : base(name, health, attackDamage, defense, abilityName, abilityPower, mana, maxMana, abilityManaCost)
        {
        }

        public override void Attack(Character target)
        {
            int damageDealt = AttackDamage;

            if (target == null) throw new ArgumentNullException(nameof(target));

            if (IsAttackCritical())
            {
                damageDealt *= 2;
                Console.WriteLine($"{Name} swings his sword, hitting the enemy's weak point, dealing {damageDealt-target.Defense} damage!");
                target.TakeDamage(damageDealt);
                
            }
            else
            {
                Console.WriteLine($"{Name} swings their sword dealing {damageDealt-target.Defense} damage to {target.Name}!");
                target.TakeDamage(damageDealt);
                
            }
           
        }

        public override void UseAbility(Character target)
        {
            if (target == null) throw new ArgumentNullException(nameof(target));
            if (!CanUseAbility) throw new InvalidOperationException("Cannot use ability yet.");
            Console.WriteLine($"{Name} summons the power of justice and deals {AbilityPower-target.Defense} damage to {target.Name} with their blade!");
            target.TakeDamage(AbilityPower);
            Mana -= AbilityManaCost;
        }
    }
}