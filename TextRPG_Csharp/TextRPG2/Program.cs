using System;
using System.Collections.Generic;
using System.Text;

namespace TextRPG_Csharp.TextRPG2
{
    class Program
    {
        static void Main(string[] args)
        {
            Player player = new Knight();
            Monster monster = new Orc();

            int damage = player.GetAttack();
            monster.OnDamage(damage);
        }
    }
}
