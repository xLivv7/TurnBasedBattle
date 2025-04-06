using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyGame.Core
{
    public class Warrior : Character
    {
        public Warrior(string name, int health, int attackDamage, int defense, string abilityName, int abilityPower, int mana, int maxMana, int abilityManaCost) : base(name, health, attackDamage, defense, abilityName, abilityPower, mana, maxMana, abilityManaCost)
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
                message=$"{Name} swings his sword, hitting the enemy's weak point, dealing {damageDealt-target.Defense} damage!";
                target.TakeDamage(damageDealt);
                
            }
            else
            {
                message=$"{Name} swings their sword dealing {damageDealt-target.Defense} damage to {target.Name}!";
                target.TakeDamage(damageDealt);
                
            }
            return message;
           
        }

        public override string UseAbility(Character target)
        {
            string message;
            if (target == null) throw new ArgumentNullException(nameof(target));
            if (!CanUseAbility) throw new InvalidOperationException("Cannot use ability yet.");
            message=$"{Name} summons the power of justice and deals {AbilityPower-target.Defense} damage to {target.Name} with their blade!";
            target.TakeDamage(AbilityPower);
            Mana -= AbilityManaCost;
            return message;
        }
    }
}