using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tumba_do_Horror_de_Aço
{
    internal class NPC: StatBase
    {
        public int HP, AC, dmg, atk;
        public string nome;
        public bool incover;
        public string textoataque, textoacerto, textocritico, textomorte, introducao;

        public void criar(string name, int vida, int armadura, int ataque, int damage)
        {
            HP = vida;
            AC = armadura;
            atk = ataque;
            dmg = damage;
            nome = name;
            
        }
        public void texto_ataque() {
            Console.WriteLine(textoataque);
        }
        public void texto_acerto() {
            Console.WriteLine(textoacerto);
        }
        public void texto_critico() {
            Console.WriteLine(textocritico);
        }
        public void texto_morte() {
            Console.WriteLine(textomorte);
        }
        public void introdução()
        {
            Console.WriteLine(introducao);
        }
        
       public void cover()
        {
            Console.WriteLine("The enemy jumps into cover, looking for protection against your fire!");
            AC++;
            incover = true;
        }

        public void criarwarrior()
        {
            criar("Necron Warrior", 8, 14, 2, 4);
            textoataque = "The metallic creature standing before you bring his alen and sinister weapon to bear, looking at you with\n" +
                "contemptuous eyes shining with the everpresent green glow. His cruel-looking gun starts to ignite with power, the ozone smell\n" +
                "filling the air with the promisse of destruction.";
            textoacerto = "The ray of death shot by the monster gun hits you, and even a graze of that destructive energy is enough to\n" +
                "cause a searing pain to spread through your body.";
            textocritico = "the ray of death shot by the monster hits you fully in the chest, desintegrating parts of your armor and\n" +
                "punching a hole through your body. Your vision blurs and you're not sure if you gonna make it. However, the emperor compels.\n" +
                "you must fight.";
            textomorte = "Your shot hits the monster for a final time, and it falls to death, crumpling in a ball of dormant steel.";
            introducao = "A trio of horrible creatures rise from the shadows of a corner, carrying enormous guns burstling with green\n" +
                "energy. Looking like giant metal skeletons, they lumber in your direction. You shudder with the tought of fighting such monsters," +
                "but there is no other option. It's time to fight.";
        }

        public void criarsilent()
        {
            criar("The Silent Master", 30, 16, 5, 8);
            introducao = "at the back of the room, a metallic skeletal creature sits on a throne. it holds a blackstone staff, sparkling with energy.\n" +
                "it slowly rises and point the staff at you, it's cloak reflecting the texture of the night sky, as if it was a window to the universe.\n" +
                "the energy wielded by the creature pulses even stronger, and a ray of energy shoots in your direction. Barely dodging it, you raise your head\n" +
                "to see the monster approaching you. It's time to fight, soldier.";
            textoataque = "The alien raises it's staff, shooting a ray of searing green light at you!";
           textoacerto = "The beam of light hits you with a burning sound and smell, searing a big chunk of meat!";
           textocritico = "You are hit full force by the energy shot from the monster's staff, and a hole is punched through your armor\n" +
                "ignoring armor and burning your organs without mercy. You kneel, blind by pain, but the emperor commands: you must go on!";
            textomorte = "The monster fall to it's knees, finally felled by your shots. It points a finger at you, but it's energy finnaly\n" +
                "ends, and it crumples to death. Your path is free soldier. Enjoy it while you can.";
            
        }
        public void showstats()
        {
            Console.WriteLine(nome + " - HP: " + HP);
        }

    }
}
