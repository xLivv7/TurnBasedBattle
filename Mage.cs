using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TurnBattle
{
    public class Mage : Character
    {
        public Mage(string name, int health, int attackDamage, int defense, string abilityName, int abilityPower) : base(name, health, attackDamage, defense, abilityName, abilityPower)
        {
        }

        public override void Attack(Character target)
        {
            int damageDealt = AttackDamage;

            if (target == null) throw new ArgumentNullException(nameof(target));
            Console.WriteLine($"{Name} casts a basic spell dealing {damageDealt} damage to {target.Name}!");
            target.TakeDamage(damageDealt);
            IncrementAttackCount();
        }

        public override void UseAbility(Character target)
        {
            if (target == null) throw new ArgumentNullException(nameof(target));
            if (!CanUseAbility) throw new InvalidOperationException("Cannot use ability yet.");
            Console.WriteLine($"{Name} unleashes a powerful arcane blast at {target.Name}!");
            target.TakeDamage(AbilityPower);
            ResetAttackCount();
        }
    }
}