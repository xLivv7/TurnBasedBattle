using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyGame.Core
{
    public class Mage : Character
    {
        
        public Mage(string name, int health, int attackDamage, int defense, string abilityName, int abilityPower, int mana, int maxMana, int abilityManaCost) : base(name, health, attackDamage, defense, abilityName, abilityPower, mana, maxMana, abilityManaCost)
        {
        }

        public override string Attack(Character target)
        {
            int damageDealt = AttackDamage;
            string message;
            if (target == null) throw new ArgumentNullException(nameof(target));
            if (IsAttackCritical())
            {
                damageDealt *= 2;
                message = $"{Name} casts a critical spell dealing {damageDealt-target.Defense} damage to {target.Name}!";
                target.TakeDamage(damageDealt);
            }
            else
            {
                message =$"{Name} casts a basic spell dealing {damageDealt-target.Defense} damage to {target.Name}!";
                target.TakeDamage(damageDealt);
            }
            return message;
                
        }

        public override string UseAbility(Character target)
        {
            string message;
            if (target == null) throw new ArgumentNullException(nameof(target));
            if (!CanUseAbility) throw new InvalidOperationException("Cannot use ability yet.");
            message=$"{Name} unleashes a powerful arcane blast at {target.Name}!";
            target.TakeDamage(AbilityPower);
            Mana -= AbilityManaCost;
            return message;
        }
    }
}