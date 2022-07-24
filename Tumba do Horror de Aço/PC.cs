using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tumba_do_Horror_de_Aço
{
    internal class PC: StatBase
    {
        public int HP, AC, dmg, atk;
        public string nome;
        public bool incover;
        public string textoataque, textoacerto, textocritico, textomorte;
        public string[] inventory = new string[6];
        public void criar(string name, int vida, int armadura, int ataque, int damage)
        {
            HP = vida;
            AC = armadura;
            atk = ataque;
            dmg = damage;
            nome = name;
            
        }
        public void texto_ataque()
        {
            Console.WriteLine(textoataque);
        }
        public void texto_acerto()
        {
            Console.WriteLine(textoacerto);
        }
        public void texto_critico()
        {
            Console.WriteLine(textocritico);
        }
        public void texto_morte()
        {
            Console.WriteLine(textomorte);
        }
        public void cover() {
            Console.WriteLine("You jump behind a nearby object, protecting youself against the deadly rays of the enemy!");
            AC++;
            incover = true;
        }
        public void gerarinventario(string arma, string armadura )

        
        {
            inventory[0] = arma;
            inventory[1] = armadura;
            inventory[2] = " ";
            inventory[3] = " ";
            inventory[4] = " ";

        }
        public void inventario()
        {
            Console.WriteLine(inventory[0]+ " - Accuracy: " + atk + " - Damage: " + dmg);
            Console.WriteLine(inventory[1] + " - Armor Class: " + AC);
            if (inventory[2] != " " )
            {
                Console.WriteLine(inventory[2]);
            }
            if (inventory[3] != " " )
            {
                Console.WriteLine(inventory[3]);
            }
            if (inventory[4] != " ")
            {
                Console.WriteLine(inventory[4]);
            }
        }
        public void showstats()
        {
            Console.WriteLine(nome + " - HP: " + HP);
        }

    }
}
