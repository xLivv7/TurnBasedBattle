using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TurnBattle
{
    public class Warrior : Character
    {
        public Warrior(string name, int health, int attackDamage, int defense, string abilityName, int abilityPower) : base(name, health, attackDamage, defense, abilityName, abilityPower)
        {
        }

        public override void Attack(Character target)
        {
            int damageDealt = AttackDamage;

            if (target == null) throw new ArgumentNullException(nameof(target));
            Console.WriteLine($"{Name} swings their sword dealing {damageDealt} damage to {target.Name}!");
            target.TakeDamage(damageDealt);
            IncrementAttackCount();
        }

        public override void UseAbility(Character target)
        {
            if (target == null) throw new ArgumentNullException(nameof(target));
            if (!CanUseAbility) throw new InvalidOperationException("Cannot use ability yet.");
            Console.WriteLine($"{Name} summons the power of justice and deals {AbilityPower} damage to {target.Name} with their blade!");
            target.TakeDamage(AbilityPower);
            ResetAttackCount();
        }
    }
}