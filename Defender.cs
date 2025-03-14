using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TurnBattle
{
    public class Defender : Character
    {
        private bool shieldBuffActive = false;
        public Defender(string name, int health, int attackDamage, int defense, string abilityName, int abilityPower, int mana, int maxMana, int abilityManaCost) : base(name, health, attackDamage, defense, abilityName, abilityPower, mana,maxMana,abilityManaCost)
        {
        }

        public override void Attack(Character target)
        {
            int damageDealt = AttackDamage;
            if (target == null) throw new ArgumentNullException(nameof(target));

            if (IsAttackCritical())
            {
                damageDealt *= 2;
                System.Console.WriteLine($"{Name} swings their shield with great force, dealing {damageDealt-target.Defense} damage to {target.Name}!");
                target.TakeDamage(damageDealt);
                
            }
            else
            {
                Console.WriteLine($"{Name} attacks {target.Name} with a stout shield bash for {damageDealt-target.Defense} damage!");
                target.TakeDamage(damageDealt);
                
            }
        }

        public override void TakeDamage(int damage)
        {
            if (damage < 0) damage = 0;
            int finalDamage = Math.Max(damage - Defense, 0);

            if (shieldBuffActive)
            {
                finalDamage = (int)(finalDamage *0.3);
                shieldBuffActive = false;
                Console.WriteLine($"{Name} resists most of the incoming damage thanks to the shield slam!");
            }
            Health = Math.Max(Health - finalDamage, 0);
        }
        public override void UseAbility(Character target)
        {
            if (target == null) throw new ArgumentNullException(nameof(target));
            if (!CanUseAbility) throw new InvalidOperationException("Cannot use ability yet.");
            int damageDealt = AbilityPower;
            Console.WriteLine($"{Name} slams the shield into the ground, dealing {damageDealt-target.Defense} damage to {target.Name} and fortifying defense!");
            target.TakeDamage(damageDealt);
            shieldBuffActive = true;
            Mana -= AbilityManaCost;
            
        }
    }
}