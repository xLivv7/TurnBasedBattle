using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TurnBattle
{
    public class Mage : Character
    {
        public Mage(string name, int health, int attackDamage, int defense, string abilityName, int abilityPower, int mana, int maxMana, int abilityManaCost) : base(name, health, attackDamage, defense, abilityName, abilityPower, mana, maxMana, abilityManaCost)
        {
        }

        public override void Attack(Character target)
        {
            int damageDealt = AttackDamage;
            if (target == null) throw new ArgumentNullException(nameof(target));
            if (IsAttackCritical())
            {
                damageDealt *= 2;
                Console.WriteLine($"{Name} casts a critical spell dealing {damageDealt-target.Defense} damage to {target.Name}!");
                target.TakeDamage(damageDealt);
            }
            else
            {
                Console.WriteLine($"{Name} casts a basic spell dealing {damageDealt-target.Defense} damage to {target.Name}!");
                target.TakeDamage(damageDealt);
            }
                
                
        }

        public override void UseAbility(Character target)
        {
            if (target == null) throw new ArgumentNullException(nameof(target));
            if (!CanUseAbility) throw new InvalidOperationException("Cannot use ability yet.");
            Console.WriteLine($"{Name} unleashes a powerful arcane blast at {target.Name}!");
            target.TakeDamage(AbilityPower);
            Mana -= AbilityManaCost;
        }
    }
}