using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace TurnBattle
{
    public class Archer : Character
    {
        private bool attackBuffActive = false;
        private int BuffedAttacksCount = 0;
        
        public Archer(string name, int health, int attackDamage, int defense, string abilityName, int abilityPower) : base(name, health, attackDamage, defense, abilityName, abilityPower)
        {
        }
        public override void Attack(Character target)
        {
            int damageDealt = AttackDamage + (int)(0.3*AbilityPower);
            if (target == null) throw new ArgumentNullException(nameof(target));
            if (attackBuffActive && BuffedAttacksCount <= 3)
            {
                Console.WriteLine($"{Name} shoots a poisoned arrow at {target.Name} dealing {damageDealt-target.Defense} damage to him!");
                target.TakeDamage(damageDealt);
                IncrementAttackCount();
                BuffedAttacksCount++;
                if (BuffedAttacksCount == 3)
                {
                    attackBuffActive = false;
                    BuffedAttacksCount = 0;
                }
            }
            else
            {
                Console.WriteLine($"{Name} attacks {target.Name} with a bow for {AttackDamage} damage.");
                target.TakeDamage(AttackDamage);
                IncrementAttackCount();
            }
            
            
        }

        public override void UseAbility(Character target)
        {
            if (target == null) throw new ArgumentNullException(nameof(target));
            if (!CanUseAbility) throw new InvalidOperationException("Cannot use ability yet.");
            Console.WriteLine($"{Name}  poisons his 3 arrows, dealing greater damage to {target.Name} during the next 3 shots fired!");
            attackBuffActive = true;
            Attack(target);
            ResetAttackCount();
        }
    }
}