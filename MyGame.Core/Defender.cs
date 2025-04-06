using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyGame.Core
{
    public class Defender : Character
    {
        private bool shieldBuffActive = false;
        public Defender(string name, int health, int attackDamage, int defense, string abilityName, int abilityPower, int mana, int maxMana, int abilityManaCost) : base(name, health, attackDamage, defense, abilityName, abilityPower, mana,maxMana,abilityManaCost)
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
                message=$"{Name} swings their shield with great force, dealing {damageDealt-target.Defense} damage to {target.Name}!";
                target.TakeDamage(damageDealt);
                
            }
            else
            {
                message=$"{Name} attacks {target.Name} with a stout shield bash for {damageDealt-target.Defense} damage!";
                target.TakeDamage(damageDealt);
                
            }
            return message; 
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
        public override string UseAbility(Character target)
        {
            string message;
            if (target == null) throw new ArgumentNullException(nameof(target));
            if (!CanUseAbility) throw new InvalidOperationException("Cannot use ability yet.");
            int damageDealt = AbilityPower;
            message=$"{Name} slams the shield into the ground, dealing {damageDealt-target.Defense} damage to {target.Name} and fortifying defense!";
            target.TakeDamage(damageDealt);
            shieldBuffActive = true;
            Mana -= AbilityManaCost;
            return message;
            
        }
    }
}