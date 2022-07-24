using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tumba_do_Horror_de_Aço
{
    internal class Engine
    {
        public PC heroi = new PC();
        public NPC inimigo = new NPC();
        Random dado = new Random();
        int roll, roll2, roll3, comando, direction;
        bool operação = true;
        List<NPC> grupo = new List<NPC>();
        public string[,] dungeon = new string[3, 3];
        public int linha, coluna, lchave, cchave, lsaida, csaida;
        public string current;
        public string buffer = "-@-";
        public bool alive = true;
        public bool exploring = true;
        public bool chave = false;
        public bool foundexit = false;
        public bool gotit = false;
        public bool scope = false;
        public bool steelbarrel = false;
        public bool paddedunim = false;


        public void bossfight()
        {
            while (operação == true)
            {
                Console.WriteLine("-------------------------------------------");
                heroi.showstats();
                heroi.inventario();
                Console.WriteLine("-------------------------------------------");
                inimigo.showstats();
                Console.WriteLine("-------------------------------------------");

                //================================================== Turno Jogador ========================================================//
                if (heroi.incover == true)
                {
                    Console.WriteLine("You leave the safety of your cover for a better line of sight.");
                    heroi.AC--;
                    heroi.incover = false;
                }
               
                Console.WriteLine("Choose an action soldier!\n" +
                    "1 - Shoot the enemy! Purge it!.\n" +
                    "2 - Jump into cover! Protect yourself from their unholy weapons!\n" +
                    "3 - flee the firefight. But the emperor looks down on cowardice!");
                comando = int.Parse(Console.ReadLine());
                switch (comando)
                {
                    case 1:
                        heroi.texto_ataque();
                        roll = dado.Next(1, 21);
                        if ((roll + heroi.atk) >= inimigo.AC && roll < 20)
                        {
                            heroi.texto_acerto();
                            roll = dado.Next(1, heroi.dmg);
                            Console.WriteLine("you caused " + roll + " damage!");
                            inimigo.HP -= roll;
                        }
                        else if ((roll + heroi.atk) >= inimigo.AC && roll >= 20)
                        {
                            heroi.texto_critico();
                            roll = dado.Next(1, (heroi.dmg * 2));
                            Console.WriteLine("you caused " + roll + " damage with an critical hit!");
                            inimigo.HP -= roll;
                        }
                        else
                        {
                            Console.WriteLine("Your shot missed the enemy! Focus soldier!");
                        }
                        break;
                    case 2:
                        heroi.cover();
                        break;
                    case 3:
                        Console.WriteLine("Unable to fight with such a powerful enemy, you escape, running through the shadowy halls\n" +
                            "until you can't hear their movement and their weapons. You live to see another day, but the shame weights\n" +
                            "on your shoulders...");
                        gotit = false;
                        operação = false;
                        goto end;
                        break;
                }
                if (inimigo.HP <= 0)
                {
                    inimigo.texto_morte();
                    gotit = true;
                    operação = false;
                    goto end;

                }
                //=================================================== turno chefe =================================================//
                if (inimigo.incover == true)
                {
                    Console.WriteLine("The enemy leaves it's cover, preparing an lethal shot at you!");
                    inimigo.AC--;
                    inimigo.incover = false;
                }
                comando = dado.Next(1, 3);
                switch (comando)
                {
                    case 1:
                        inimigo.texto_ataque();
                        roll = dado.Next(1, 21);
                        if ((roll + inimigo.atk) >= heroi.AC && roll < 20)
                        {
                            inimigo.texto_acerto();
                            roll = dado.Next(1, inimigo.dmg);
                            Console.WriteLine("You suffered " + roll + " damage!");
                            heroi.HP -= roll;
                        }
                        else if ((roll + inimigo.atk) >= heroi.AC && roll >= 20)
                        {
                            inimigo.texto_critico();
                            roll = dado.Next(1, (inimigo.dmg * 2));
                            Console.WriteLine("You suffered " + roll + " damage from an enemy attack!");
                            heroi.HP -= roll;
                        }
                        else
                        {
                            Console.WriteLine("The enemy shot missed you by a hair! They are still coming, tho!");
                        }
                        break;
                    case 2:
                        inimigo.cover();
                        break;
                }
                if (heroi.HP <= 0)
                {
                    Console.WriteLine("Enemy fire finally take you down. You stare at their mallicious green eyes with despair\n" +
                        "holding your guts at place with an hand. You are powerless to react as he raises his staff and prepares for\n" +
                        "the coup de grace...");
                        
                    gotit = false;
                    alive = false;
                    operação = false;
                    
                    goto end;
    
                }
            end:;
            }

        }
        public void normalfight()
        {
            while (operação == true)
            {
                Console.WriteLine("-------------------------------------------");
                heroi.showstats();
                heroi.inventario();
                Console.WriteLine("-------------------------------------------");
                grupo[0].showstats();
                grupo[1].showstats();
                grupo[2].showstats();
                Console.WriteLine("-------------------------------------------");

                //================================================== Turno Jogador ========================================================//
                if (heroi.incover == true)
                {
                    Console.WriteLine("You jump out of cover to get a better line of sight to the enemy!");
                    heroi.AC--;
                    heroi.incover = false;
                }
                Console.WriteLine("Choose an action Soldier!\n" +
                    "1 - Shoot the enemy! Purge them!\n" +
                    "2 - Jump into cover! Protect youself from their fire!\n" +
                    "3 - escape from the firefight. However, the emperor looks down on cowardice!");
                comando = int.Parse(Console.ReadLine());
                switch (comando)
                {
                    case 1:
                        Console.WriteLine("Which enemy you wish to shoot at, soldier?");
                        Console.WriteLine("1 - " + grupo[0].nome + " HP: " + grupo[0].HP);
                        Console.WriteLine("2 - " + grupo[1].nome + " HP: " + grupo[1].HP);
                        Console.WriteLine("3 - " + grupo[2].nome + " HP: " + grupo[2].HP);
                        comando = int.Parse(Console.ReadLine());
                        switch (comando)
                        {
                            case 1:
                                if (grupo[0].HP >= 0)
                                {
                                    heroi.texto_ataque();
                                    roll = dado.Next(1, 21);
                                    if ((roll + heroi.atk) >= grupo[0].AC && roll < 20)
                                    {
                                        heroi.texto_acerto();
                                        roll = dado.Next(1, heroi.dmg);
                                        Console.WriteLine("you caused " + roll + " damage!");
                                        grupo[0].HP -= roll;
                                    }
                                    else if ((roll + heroi.atk) >= grupo[0].AC && roll >= 20)
                                    {
                                        heroi.texto_acerto();
                                        roll = dado.Next(1, (heroi.dmg * 2));
                                        Console.WriteLine("you caused " + roll + " damage with an critical hit!");
                                        grupo[0].HP -= roll;
                                    }
                                    else
                                    {
                                        Console.WriteLine("your shots missed the enemy! Focus soldier!");
                                    }
                                }
                                else
                                {
                                    Console.WriteLine("This enemy is already destroyed!");
                                }
                                if (grupo[0].HP <= 0 && grupo[1].HP <= 0 && grupo[2].HP <= 0)
                                {
                                    gotit = true;
                                    operação = false;
                                }
                                break;
                            case 2:
                                if (grupo[1].HP >= 0)
                                {
                                    heroi.texto_ataque();
                                    roll = dado.Next(1, 21);
                                    if ((roll + heroi.atk) >= grupo[1].AC && roll < 20)
                                    {
                                        heroi.texto_acerto();
                                        roll = dado.Next(1, heroi.dmg);
                                        Console.WriteLine("you caused " + roll + " damage!");
                                        grupo[1].HP -= roll;
                                    }
                                    else if ((roll + heroi.atk) >= grupo[1].AC && roll >= 20)
                                    {
                                        heroi.texto_critico();
                                        roll = dado.Next(1, (heroi.dmg * 2));
                                        Console.WriteLine("you caused " + roll + " damage with an critical hit!");
                                        grupo[1].HP -= roll;
                                    }
                                    else
                                    {
                                        Console.WriteLine("your shots missed the enemy! Focus soldier!");
                                    }
                                }
                                else
                                {
                                    Console.WriteLine("This enemy is already destroyed!");
                                }
                                if (grupo[0].HP <= 0 && grupo[1].HP <= 0 && grupo[2].HP <= 0)
                                {
                                    gotit = true;
                                    
                                    operação = false;
                                }
                                break;
                            case 3:
                                if (grupo[2].HP >= 0)
                                {
                                    heroi.texto_ataque();
                                    roll = dado.Next(1, 21);
                                    if ((roll + heroi.atk) >= grupo[2].AC && roll < 20)
                                    {
                                        heroi.texto_acerto();
                                        roll = dado.Next(1, heroi.dmg);
                                        Console.WriteLine("you caused " + roll + " damage!");
                                        grupo[2].HP -= roll;
                                    }
                                    else if ((roll + heroi.atk) >= grupo[1].AC && roll >= 20)
                                    {
                                        heroi.texto_critico();
                                        roll = dado.Next(1, (heroi.dmg * 2));
                                        Console.WriteLine("you caused " + roll + " damage with an critical hit!");
                                        grupo[2].HP -= roll;
                                    }
                                    else
                                    {
                                        Console.WriteLine("your shots missed the enemy! Focus soldier!");
                                    }
                                }
                                else
                                {
                                    Console.WriteLine("This enemy is already destroyed!");
                                }
                                if (grupo[0].HP <= 0 && grupo[1].HP <= 0 && grupo[2].HP <= 0)
                                {
                                    Console.WriteLine("You finally kill all the enemies, and you stare wide-eyed at\n" +
                                        "the massacre, their parts and your blood mixed togheter. There is still much\n" +
                                        "to explore, and you have no time to lose hesitating. Time to move fowards soldier.");
                                    gotit = true;
                                    
                                    operação = false;
                                    goto end;
                                }
                                break;
                        }
                        break;
                    case 2:
                        heroi.cover();
                        break;
                    case 3:
                        Console.WriteLine("Unable to fight with such a powerful enemy, you escape, running through the shadowy halls\n" +
                            "until you can't hear their movement and their weapons. You live to see another day, but the shame weights\n" +
                            "on your shoulders...");
                        gotit = false;
                        operação = false;
                        goto end;
                        break;
                }

                //============================================== turno dos inimigos ===============================================//
                //============================================== inimigo 1 =======================================================//
                if (grupo[0].incover == true)
                {
                    Console.WriteLine("The enemy leaves it's cover, preparing an lethal shot at you!");
                    grupo[0].AC--;
                    grupo[0].incover = false;
                }
                comando = dado.Next(1, 3);
                switch (comando)
                {
                    case 1:
                        inimigo.texto_ataque();
                        roll = dado.Next(1, 21);
                        if ((roll + grupo[0].atk) >= heroi.AC && roll < 20)
                        {
                            grupo[0].texto_acerto();
                            roll = dado.Next(1, grupo[0].dmg);
                            Console.Write("You suffered " + roll + " damage!");
                            heroi.HP -= roll;
                        }
                        else if ((roll + grupo[0].atk) >= heroi.AC && roll >= 20)
                        {
                            grupo[0].texto_critico();
                            roll = dado.Next(1, (grupo[0].dmg * 2));
                            Console.Write("You suffered " + roll + " from an enemy critical hit!");
                            heroi.HP -= roll;
                        }
                        else
                        {
                            Console.WriteLine("the enemy shot missed you by a hair!But they are still coming!");
                        }

                        break;
                    case 2:
                        grupo[0].cover();
                        break;
                }
                if (heroi.HP <= 0)
                {
                    Console.WriteLine("Enemy fire finally take you down. You stare at their mallicious green eyes with despair\n" +
                             "holding your guts at place with an hand. You are powerless to react as they snatch your weapon\n" +
                             "and break your neck with a cold casualty...");
                    gotit = false;
                    alive = false;
                    operação = false;
                    goto end;
                }

                //=================================================== inimigo 2 ================================================//
                if (grupo[1].incover == true)
                {
                    Console.WriteLine("The enemy leaves it's cover, preparing an lethal shot at you!");
                    grupo[1].AC--;
                    grupo[1].incover = false;
                }
                comando = dado.Next(1, 2);
                switch (comando)
                {
                    case 1:
                        inimigo.texto_ataque();
                        roll = dado.Next(1, 21);
                        if ((roll + grupo[1].atk) >= heroi.AC && roll < 20)
                        {
                            grupo[1].texto_acerto();
                            roll = dado.Next(1, grupo[1].dmg);
                            Console.WriteLine("You suffered " + roll + " damage!");
                            heroi.HP -= roll;
                        }
                        else if ((roll + grupo[1].atk) >= heroi.AC && roll >= 20)
                        {
                            grupo[1].texto_critico();
                            roll = dado.Next(1, (grupo[1].dmg * 2));
                            Console.WriteLine("You suffered " + roll + " from an enemy critical hit!");
                            heroi.HP -= roll;
                        }
                        else
                        {
                            Console.WriteLine("the enemy shot missed you by a hair!But they are still coming!");
                        }
                        break;
                    case 2:
                        grupo[1].cover();
                        break;
                }
                if (heroi.HP <= 0)
                {
                    Console.WriteLine("Enemy fire finally take you down. You stare at their mallicious green eyes with despair\n" +
                             "holding your guts at place with an hand. You are powerless to react as they snatch your weapon\n" +
                             "and break your neck with a cold casualty...");
                    gotit = false;
                    alive = false;
                    operação = false;
                    goto end;
                }

                //=================================================== inimigo 3 ================================================//
                if (grupo[2].incover == true)
                {
                    Console.WriteLine("The enemy leaves it's cover, preparing an lethal shot at you!");
                    grupo[2].AC--;
                    grupo[2].incover = false;
                }
                comando = dado.Next(1, 2);
                switch (comando)
                {
                    case 1:
                        inimigo.texto_ataque();
                        roll = dado.Next(1, 21);
                        if ((roll + grupo[2].atk) >= heroi.AC && roll < 20)
                        {
                            grupo[2].texto_acerto();
                            roll = dado.Next(1, grupo[2].dmg);
                            Console.WriteLine("You suffered " + roll + " damage!");
                            heroi.HP -= roll;
                        }
                        else if ((roll + grupo[2].atk) >= heroi.AC && roll >= 20)
                        {
                            grupo[2].texto_critico();
                            roll = dado.Next(1, (grupo[2].dmg * 2));
                            Console.WriteLine("You suffered " + roll + " from an enemy critical hit!");
                            heroi.HP -= roll;
                        }
                        else
                        {
                            Console.WriteLine("the enemy shot missed you by a hair!But they are still coming!");
                        }
                        break;
                    case 2:
                        grupo[2].cover();
                        break;
                }
                if (heroi.HP <= 0)
                {
                    Console.WriteLine("Enemy fire finally take you down. You stare at their mallicious green eyes with despair\n" +
                             "holding your guts at place with an hand. You are powerless to react as they snatch your weapon\n" +
                             "and break your neck with a cold casualty...");
                    gotit = false;
                    alive = false;
                    operação = false;
                    goto end;
                }
            end:;

            }
        }
            
        public void events()
        {
            roll = dado.Next(1, 100);
            if (roll >= 1 && roll <= 20) // itens = 30%
            {
                roll2 = dado.Next(1, 100);
                if (roll2 >= 1 && roll2 <= 15)
                {
                    Console.WriteLine("You find the corpse of your squad's heavy trooper, still warm and recently killed off by one of the\n" +
                        "metallic creatures, you reckon. He is holding his Heavy Bolter with all the ammo belts still intact. Will you\n" +
                        "take it?");
                    Console.WriteLine("1 - Yes\n" +
                        "2 - No");
                    comando = int.Parse(Console.ReadLine());
                    switch (comando)
                    {
                        case 1:
                            Console.WriteLine("You take the weapon from his arms, testing it's mechanisms and strapping the feeder mechanisms\n" +
                                "to your back. You should be able to shoot powerful bolt bullets at high speeds, but the weight and kick of \n" +
                                "the heavy gun will cost you some accuracy.");
                            heroi.inventory[0] = "Heavy Bolter";
                            heroi.atk = 1;
                            heroi.dmg = 8;
                            if (scope == true)
                            {
                                heroi.atk += 2;
                            }
                            if (steelbarrel == true)
                            {
                                heroi.dmg++;
                            }
                            gotit = true;
                            break;
                        case 2:
                            Console.WriteLine("You want to let your poor comrade rest in peace, and can't bring yourself to loot his equipment\n" +
                                "you pray for the emperor to guide his soul, and also pray that you won't need such guidance today. As you prepare\n" +
                                "to leave to room and look back, it's layout is already changed,the corpse of your comrade forever lost.");
                            gotit = true;
                            break;
                    }

                }
                if (roll2 >= 16 && roll2 <= 26)
                {
                    Console.WriteLine("You find the corpse of your squad heavy trooper, still warm and recently killed off by one of the\n" +
                        "metallic creatures, you reckon. He is holding an intact reiforced steel barrel, able to be affixed to an weapon\n" +
                        "and greatly improve it's firepower. Will you take it?");
                    Console.WriteLine("1 - Yes\n" +
                        "2 - No");
                    comando = int.Parse(Console.ReadLine());
                    switch (comando)
                    {
                        case 1:
                            Console.WriteLine("You take the weapon mod from his cold hands, and spend some minutes affixing it to your gun.\n" +
                                "you should be able to kill the enemies spending less shots, now.");
                            heroi.inventory[2] = "Reinforced Steel Barrel - +1 to damage";
                            heroi.dmg++;
                            steelbarrel = true;
                            gotit = true;
                            break;
                        case 2:
                            Console.WriteLine("You want to let your poor comrade rest in peace, and can't bring yourself to loot his equipment\n" +
                                "you pray for the emperor to guide his soul, and also pray that you won't need such guidance today. As you prepare\n" +
                                "to leave to room and look back, it's layout is already changed,the corpse of your comrade forever lost.");
                            gotit = true;
                            break;
                    }

                }
                if (roll2 >= 27 && roll2 <= 37)
                {
                    Console.WriteLine("You find the corpse of your squad heavy trooper, still warm and recently killed off by one of the\n" +
                        "metallic creatures, you reckon. He is equipped with an intact padded uniform, able to absorb heat, impact and piercing\n" +
                        "attacks. Will you take it?");
                    Console.WriteLine("1 - Yes\n" +
                        "2 - No");
                    comando = int.Parse(Console.ReadLine());
                    switch (comando)
                    {
                        case 1:
                            Console.WriteLine("You wear his uniform, fitting some parts of it to your body with straps and belts. You should be\n" +
                                "safer now against the denizens and traps of this place.");

                            heroi.inventory[3] = "Padded Uniform - +2 to Armor Class";
                            heroi.AC += 2;
                            paddedunim = true;
                            gotit = true;
                            break;
                        case 2:
                            Console.WriteLine("You want to let your poor comrade rest in peace, and can't bring yourself to loot his equipment\n" +
                                "you pray for the emperor to guide his soul, and also pray that you won't need such guidance today. As you prepare\n" +
                                "to leave to room and look back, it's layout is already changed,the corpse of your comrade forever lost.");
                            gotit = true;
                            break;
                    }

                }
                if (roll2 >= 48 && roll2 <= 58)
                {
                    Console.WriteLine("You find the corpse of your squad sniper, still warm and recently killed off by one of the\n" +
                        "metallic creatures, you reckon. His lasgun is completely thrashed, but it's scope and laser sights are\n" +
                        "still intact. will you take it?");
                    Console.WriteLine("1 - Yes\n" +
                        "2 - No");
                    comando = int.Parse(Console.ReadLine());
                    switch (comando)
                    {
                        case 1:
                            Console.WriteLine("You affix the laser sights and scope to your gun. You look down the lens and calibrate\n" +
                                "the optic sensors and light beam emitters. You should be able to shoot much more accurately now. ");

                            heroi.inventory[4] = "Scope and Laser Sights - +2 to Hit";
                            heroi.atk += 2;
                            scope = true;
                            gotit = true;
                            break;
                        case 2:
                            Console.WriteLine("You want to let your poor comrade rest in peace, and can't bring yourself to loot his equipment\n" +
                                "you pray for the emperor to guide his soul, and also pray that you won't need such guidance today. As you prepare\n" +
                                "to leave to room and look back, it's layout is already changed,the corpse of your comrade forever lost.");
                            gotit = true;
                            break;
                    }

                }
                if (roll2 >= 69 && roll2 <= 79)
                {
                    Console.WriteLine("You find the corpse of your squad sniper, still warm and recently killed off by one of the\n" +
                        "metallic creatures, you reckon. His Sniper Lasgun, modified for maximum range and accuracy is still intact.\n" +
                        "will you take it?");
                    Console.WriteLine("1 - Yes\n" +
                        "2 - No");
                    comando = int.Parse(Console.ReadLine());
                    switch (comando)
                    {
                        case 1:
                            Console.WriteLine("You grab the modified lasgun and do some basic maintenance, ensuring everything is\n" +
                                "working fine. This weapon is slower than your standard lasgun but shoots much more accurately.\n" +
                                "you will hardly miss a shot with this weapon. ");

                            heroi.inventory[0] = "Sniper Rifle";
                            heroi.atk = 6;
                            heroi.dmg = 6;
                            if (scope == true)
                            {
                                heroi.atk += 2;
                            }
                            if (steelbarrel == true)
                            {
                                heroi.dmg++;
                            }
                            gotit = true;
                            break;
                        case 2:
                            Console.WriteLine("You want to let your poor comrade rest in peace, and can't bring yourself to loot his equipment\n" +
                                "you pray for the emperor to guide his soul, and also pray that you won't need such guidance today. As you prepare\n" +
                                "to leave to room and look back, it's layout is already changed,the corpse of your comrade forever lost.");
                            gotit = true;
                            break;
                    }
                }
                if (roll2 >= 80 && roll2 <= 95)
                {
                    Console.WriteLine("You find the corpse of your squad scout, still warm and recently killed off by one of the\n" +
                        "metallic creatures, you reckon. His reinforced carapace armor is still intact. Will you take it? ");
                    Console.WriteLine("1 - Yes\n" +
                        "2 - No");
                    comando = int.Parse(Console.ReadLine());
                    switch (comando)
                    {
                        case 1:
                            Console.WriteLine("You grab the armor and quickly wear it, affixing the plates to your vital areas\n" +
                                "with care. You feel the reassuring touch of the cold ceramite throug your uniform, relieved by\n" +
                                "the protective potential of this piece of armor.");

                            heroi.inventory[1] = "Carapace Armor";
                            heroi.AC = 16;
                            if (paddedunim == true)
                            {
                                heroi.AC += 2;
                            }

                            gotit = true;
                            break;
                        case 2:
                            Console.WriteLine("You want to let your poor comrade rest in peace, and can't bring yourself to loot his equipment\n" +
                                "you pray for the emperor to guide his soul, and also pray that you won't need such guidance today. As you prepare\n" +
                                "to leave to room and look back, it's layout is already changed,the corpse of your comrade forever lost.");
                            gotit = true;
                            break;
                    }

                }
                if (roll2 >= 96 && roll2 <= 100)
                {
                    Console.WriteLine("You find the corpse of your squad's demolitioner, still warm and recently killed off by one of the\n" +
                        "metallic creatures, you reckon. His prized missile launcher is still intact, fully loaded with termite missiles.\n" +
                        "Will you take it? ");
                    Console.WriteLine("1 - Yes\n" +
                        "2 - No");
                    comando = int.Parse(Console.ReadLine());
                    switch (comando)
                    {
                        case 1:
                            Console.WriteLine("You grab the missile launcher, the missile pack and calibrate all the aiming systems and\n" +
                                "loading assistants. The weapon is heavy and unwieldy, but it unites the best of both worlds: acurate and\n" +
                                "deadly at the same time, dishing destruction in the form of highly explosive termite packed torpedoes.\n" +
                                "The prey has became the hunter. ");

                            heroi.inventory[0] = "Missile Launcher";
                            heroi.atk = 8;
                            heroi.dmg = 12;
                            if (scope == true)
                            {
                                heroi.atk += 2;
                            }
                            if (steelbarrel == true)
                            {
                                heroi.dmg++;
                            }
                            gotit = true;
                            break;
                        case 2:
                            Console.WriteLine("You want to let your poor comrade rest in peace, and can't bring yourself to loot his equipment\n" +
                                "you pray for the emperor to guide his soul, and also pray that you won't need such guidance today. As you prepare\n" +
                                "to leave to room and look back, it's layout is already changed,the corpse of your comrade forever lost.");
                            gotit = true;
                            break;
                    }

                }
            }// itens 20%
            if (roll >= 21 && roll <= 40)
            {
                roll2 = dado.Next(1, 100);
                if (roll2 >= 1 && roll2 <= 50)
                {
                    Console.WriteLine("As you walk along this oblonged room, the floor suddenly opens with a cruel\n" +
                        "whine, exposing a hidden floor full of plasma spikes, waiting to sear and tear your body\n" +
                        "apart.");
                    roll3 = dado.Next(1, 20);
                    if ((roll3 + heroi.AC) >= 22)
                    {
                        Console.Write("However, you are able to hold the edge of the chasm, and drag yourself up. The\n" +
                            "machinations of this place won't be taking you today.");
                        gotit = true;
                    }
                    else
                    {
                        roll3 = dado.Next(1, 10);
                        heroi.HP -= roll3;
                        if (heroi.HP > 0)
                        {
                            Console.WriteLine("You fall with your entire weight, and feel the plasma spikes impaling you,\n" +
                                "burning through flesh, bone and organs. You are a bloody mess, but somehow alive. You are\n" +
                                "able to climb up and keep exploring, but this trap has surely took it's tool on your health;");
                            Console.WriteLine("you took " + roll3 + " damage from the pitfall.");
                            gotit = true;
                        }
                        else if (heroi.HP <= 0)
                        {
                            Console.WriteLine("You fall with your entire weight, and feel the plasma spikes impaling you,\n" +
                                "burning through flesh, bone and organs. You are a bloody mess, and feels life escaping your\n" +
                                "body with each gasping breath you take. Your duty has ended soldier... with death.");
                            gotit = false;
                            alive = false;
                        }
                    }
            
                }
                if (roll2 >= 51 && roll2 <= 100)
                {
                    Console.WriteLine("As you walk along this shadowy room, small turrets reveal themselves, shooting\n" +
                        "death from their mounted weapons. The desintegrating beams dart towards you, promissing destruction.");

                    roll3 = dado.Next(1, 20);
                    if ((roll3 + heroi.AC) >= 25)
                    {
                        Console.Write("However, you are able to dodge the blasts, leaving the scars of their destruction all\n" +
                            "over the place. The machinations of this place won't be taking you today.");

                        gotit = true;
                    }
                    else
                    {
                        roll3 = dado.Next(1, 8);
                        heroi.HP -= roll3;
                        if (heroi.HP > 0)
                        {
                            Console.WriteLine("The shots graze you, but this is enough damage to make burn huge chunks of your\n" +
                                "flesh, leaving you in a sorry state. At least the shots finally stopped and you're alive to keep\n" +
                                "going.");
                            Console.WriteLine("you took " + roll3 + " damage from the pitfall.");
                            gotit = true;
                        }
                        else if (heroi.HP <= 0)
                        {
                            Console.WriteLine("You take the full brunt of the shots, desintegrating your lungs, heart and other\n" +
                                "important organs. As you lay on the floor, the turrets continue to relentlessy shoot at you\n" +
                                "turning what once was a body into a pulp of blood and burned human remains.\n");

                            gotit = false;
                            alive = false;
                        }
                    }
                }

            }//Traps 20%
            if (roll >= 41 && roll <= 55)
            {
                Console.WriteLine("You find an soldier's corpse. Altough he could be from your squad\n" +
                    "his fatigues are very old, and the man is just a dry husk, as if he was rotting\n" +
                    "in this room for centuries. However, you find a perfectly functional first aid kit.\n");
                Console.WriteLine("You use it to tend to your wounds, restoring your body to a somewhat fighting\n" +
                    "shape. Now, you can continue to explore safely.");
                heroi.HP = 25;
                gotit = true;
            }// First Aid 15%
            if (roll >=56 && roll <= 85)
            {
                grupo.Add(new NPC());
                grupo.Add(new NPC());
                grupo.Add(new NPC());
                grupo[0].criarwarrior();
                grupo[1].criarwarrior();
                grupo[2].criarwarrior();
                grupo[0].introdução();
                normalfight();
                grupo.Clear();
            }// Luta normal 30%
            if (roll >= 86 && roll <= 100)
            {
                inimigo.criarsilent();
                inimigo.introdução();
                bossfight();

            }//bossfight 15%




           

        }


            public void mapcreate()
            {
                for (int i = 0; i < 3; i++)
                {
                    for (int j = 0; j < 3; j++)
                    {
                        dungeon[i, j] = "-@-";

                    }
                }
                //=============================== Gerar Saída ========================================//
                lsaida = dado.Next(0, 3);
                csaida = dado.Next(0, 3);
            // ============================== Gerar Chave ======================================//
            gerarchave:
                lchave = dado.Next(0, 3);
                cchave = dado.Next(0, 3);
                if (lchave == lsaida && cchave == csaida)
                {
                    goto gerarchave;
                }
            // =============================== Gerar Spawn =================================//
            gerarspawn:
                linha = dado.Next(0, 3);
                coluna = dado.Next(0, 3);
                if (dungeon[coluna, linha] == "-@-") { dungeon[coluna, linha] = "-p-"; }
                else { goto gerarspawn; }



                for (int i = 0; i < 3; i++)
                {
                    for (int j = 0; j < 3; j++)
                    {
                        if (dungeon[i, j] == "-@-")
                        {
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.Write(dungeon[i, j]);
                        }
                        else if (dungeon[i, j] == "-p-")
                        {
                            Console.ForegroundColor = ConsoleColor.DarkGreen;
                            Console.Write(dungeon[i, j]);
                            Console.ForegroundColor = ConsoleColor.White;
                        }

                    }
                    Console.WriteLine();
                }

            }
            public void mapshow()
            {
                for (int i = 0; i < 3; i++)
                {
                    for (int j = 0; j < 3; j++)
                    {
                        if (dungeon[i, j] == "-@-")
                        {
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.Write(dungeon[i, j]);
                        }
                        else if (dungeon[i, j] == "-p-")
                        {
                            Console.ForegroundColor = ConsoleColor.DarkGreen;
                            Console.Write(dungeon[i, j]);
                            Console.ForegroundColor = ConsoleColor.White;
                        }
                        else if (dungeon[i, j] == "-s-")
                        {
                            Console.ForegroundColor = ConsoleColor.DarkRed;
                            Console.Write(dungeon[i, j]);
                            Console.ForegroundColor = ConsoleColor.White;
                        }
                        else if (dungeon[i, j] == "-x-")
                        {
                            Console.ForegroundColor = ConsoleColor.DarkBlue;
                            Console.Write(dungeon[i, j]);
                            Console.ForegroundColor = ConsoleColor.White;
                        }

                    }
                    Console.WriteLine();
                }
            }
            public void navigation()
            {
            while (exploring == true)
            {
                Console.WriteLine("-------------------------------");
                heroi.showstats();
                heroi.inventario();
                Console.WriteLine("-------------------------------");
                Console.WriteLine("Which way are you moving, soldier?\n" +
                        "1 - Up\n" +
                        "2 - Down\n" +
                        "3- Left\n" +
                        "4- Right\n");
                    direction = int.Parse(Console.ReadLine());
                    switch (direction)
                    {
                        case 1:
                            if (coluna > 0)
                            {
                                dungeon[coluna, linha] = buffer;
                                coluna--;
                                current = dungeon[coluna, linha];
                                dungeon[coluna, linha] = "-p-";
                                mapshow();
                                if (current == "-@-" && linha == lsaida && coluna == csaida)
                                {
                                    if (chave == true)
                                    {
                                        Console.WriteLine("You find a pair of gargantuous gates, covered in runes caligraphed with rapid\n" +
                                         "and thin strokes. Their green glow guides your way as you try to find a place to open what\n" +
                                           "seems to be your way out of this place. However, it won't open, no matter what you do. Soon,\n" +
                                           "your eyes come upon a slot in the middle of the gates, something clearly designed as a rest for\n" +
                                            "some kind of artifact. The artifact you are carrying glows with even stronger lights, as if begging\n" +
                                            "to be slotted into the gates. You do it, and the gates open with a loud, creaking sound. Sunlight\n" +
                                            "seeps into the darkness and you take your first steps into freedom...");
                                        exploring = false;
                                    }
                                    else
                                    {
                                        Console.WriteLine("You find a pair of gargantuous gates, covered in runes caligraphed with rapid\n" +
                                         "and thin strokes. Their green glow guides your way as you try to find a place to open what\n" +
                                           "seems to be your way out of this place. However, it won't open, no matter what you do. Soon,\n" +
                                           "your eyes come upon a slot in the middle of the gates, something clearly designed as a rest for\n" +
                                            "some kind of artifact. You should be looking for it, if you ever want to leave this place alive.\n" +
                                            "time to look for it in other rooms.");
                                        buffer = "-s-";
                                        foundexit = true;

                                    }

                                }
                                else if (current == "-@-" && linha == lchave && coluna == cchave)
                                {
                                    Console.WriteLine("At the back of the room, you find an pyramidal object hovering in a dome of crystal. \n" +
                                        "you carefully approaches it, and as you come close, the crystal opens itself, inviting you to grab\n" +
                                        "the artifact. You do it, shivering with fear of the consequences, but then... nothing happens. \n" +
                                        "it starts pulsing light in a general direction, as if telling you the way to the exit of this cursed place...");
                                    if (foundexit == true)
                                    {
                                        Console.WriteLine("Something tells you this is the key to the gates you found before. Hope reignites within you. It's\n" +
                                            "time to wake up from this nightmare.");
                                        chave = true;
                                        buffer = "-x-";
                                    }
                                    else
                                    {
                                        Console.Write("The pulsing is as greenish and sickly as everything in this tomb, but a gut feeling tells you that the \n" +
                                            "artifact is showing you the way out. Time to find out if your instincts and this cursed object are to be trusted.");
                                        dungeon[csaida, lsaida] = "-s-";
                                        chave = true;
                                        buffer = "-x-";
                                    }
                                }
                                else if (current == "-@-")
                                {
                                    events();
                                    if (gotit == true)
                                    {
                                        buffer = "-x-";
                                    }
                                    else
                                    {
                                        buffer = "-@-";
                                        if (alive == false)
                                        {
                                            exploring = false;
                                        }
                                    }
                                }
                                else if (current == "-x-")
                                {
                                    Console.Write("Você já passou por essa sala, e apesar das dinâmicas imprevisíveis do lugar, tudo permanece como\n" +
                                        "você lembra. Talvez seja melhor explorar outro lugar.");
                                    buffer = "-x-";
                                }
                                else if (current == "-s-")
                                {
                                    if (foundexit == true)
                                    {
                                        if (chave == true)
                                        {
                                            Console.WriteLine("After the nightmare you have gone through, you finally attach the artifact\n" +
                                              "glowing with sickly green light into the hole etched on the big double gates. It opens with\n" +
                                              "a creaking sound...Sunlight seeps into the darkness and you take your first steps into freedom...");
                                            exploring = false;
                                        }
                                        else
                                        {
                                            Console.WriteLine("You are at the room with the gates again. However, without the artifact that goes in the hole\n" +
                                                "you will never open it. You should explore further.");
                                            buffer = "-s-";


                                        }
                                    }
                                    else
                                    if (chave == true)
                                    {
                                        Console.WriteLine("You find a pair of gargantuous gates, covered in runes caligraphed with rapid\n" +
                                         "and thin strokes. Their green glow guides your way as you try to find a place to open what\n" +
                                           "seems to be your way out of this place. However, it won't open, no matter what you do. Soon,\n" +
                                           "your eyes come upon a slot in the middle of the gates, something clearly designed as a rest for\n" +
                                            "some kind of artifact. The artifact you are carrying glows with even stronger lights, as if begging\n" +
                                            "to be slotted into the gates. You do it, and the gates open with a loud, creaking sound. Sunlight\n" +
                                            "seeps into the darkness and you take your first steps into freedom...");
                                        exploring = false;
                                    }
                                    else
                                    {
                                        Console.WriteLine("You find a pair of gargantuous gates, covered in runes caligraphed with rapid\n" +
                                         "and thin strokes. Their green glow guides your way as you try to find a place to open what\n" +
                                           "seems to be your way out of this place. However, it won't open, no matter what you do. Soon,\n" +
                                           "your eyes come upon a slot in the middle of the gates, something clearly designed as a rest for\n" +
                                            "some kind of artifact. You should be looking for it, if you ever want to leave this place alive.\n" +
                                            "time to look for it in other rooms.");
                                        buffer = "-s-";
                                        foundexit = true;

                                    }
                                }
                            }
                            else
                            {
                                Console.Write("Não é possível se mover nesta direção.");
                            }


                            break;

                        case 2:
                            if (coluna < 2)
                            {
                                dungeon[coluna, linha] = buffer;
                                coluna++;
                                current = dungeon[coluna, linha];
                                dungeon[coluna, linha] = "-p-";
                                mapshow();
                                if (current == "-@-" && linha == lsaida && coluna == csaida)
                                {
                                    if (chave == true)
                                    {
                                        Console.WriteLine("You find a pair of gargantuous gates, covered in runes caligraphed with rapid\n" +
                                         "and thin strokes. Their green glow guides your way as you try to find a place to open what\n" +
                                           "seems to be your way out of this place. However, it won't open, no matter what you do. Soon,\n" +
                                           "your eyes come upon a slot in the middle of the gates, something clearly designed as a rest for\n" +
                                            "some kind of artifact. The artifact you are carrying glows with even stronger lights, as if begging\n" +
                                            "to be slotted into the gates. You do it, and the gates open with a loud, creaking sound. Sunlight\n" +
                                            "seeps into the darkness and you take your first steps into freedom...");
                                        exploring = false;
                                    }
                                    else
                                    {
                                        Console.WriteLine("You find a pair of gargantuous gates, covered in runes caligraphed with rapid\n" +
                                         "and thin strokes. Their green glow guides your way as you try to find a place to open what\n" +
                                           "seems to be your way out of this place. However, it won't open, no matter what you do. Soon,\n" +
                                           "your eyes come upon a slot in the middle of the gates, something clearly designed as a rest for\n" +
                                            "some kind of artifact. You should be looking for it, if you ever want to leave this place alive.\n" +
                                            "time to look for it in other rooms.");
                                        buffer = "-s-";
                                        foundexit = true;

                                    }

                                }
                                else if (current == "-@-" && linha == lchave && coluna == cchave)
                                {
                                    Console.WriteLine("At the back of the room, you find an pyramidal object hovering in a dome of crystal. \n" +
                                        "you carefully approaches it, and as you come close, the crystal opens itself, inviting you to grab\n" +
                                        "the artifact. You do it, shivering with fear of the consequences, but then... nothing happens. \n" +
                                        "it starts pulsing light in a general direction, as if telling you the way to the exit of this cursed place...");
                                    if (foundexit == true)
                                    {
                                        Console.WriteLine("Something tells you this is the key to the gates you found before. Hope reignites within you. It's\n" +
                                            "time to wake up from this nightmare.");
                                        chave = true;
                                        buffer = "-x-";
                                    }
                                    else
                                    {
                                        Console.Write("The pulsing is as greenish and sickly as everything in this tomb, but a gut feeling tells you that the \n" +
                                            "artifact is showing you the way out. Time to find out if your instincts and this cursed object are to be trusted.");
                                        dungeon[csaida, lsaida] = "-s-";
                                        chave = true;
                                        buffer = "-x-";
                                    }
                                }
                                else if (current == "-@-")
                                {
                                    events();
                                    if (gotit == true)
                                    {
                                        buffer = "-x-";
                                    }
                                    else
                                    {
                                        buffer = "-@-";
                                        if (alive == false)
                                        {
                                            exploring = false;
                                        }
                                    }
                                }
                                else if (current == "-x-")
                                {
                                    Console.Write("Você já passou por essa sala, e apesar das dinâmicas imprevisíveis do lugar, tudo permanece como\n" +
                                        "você lembra. Talvez seja melhor explorar outro lugar.");
                                    buffer = "-x-";
                                }
                                else if (current == "-s-")
                                {
                                    if (foundexit == true)
                                    {
                                        if (chave == true)
                                        {
                                            Console.WriteLine("After the nightmare you have gone through, you finally attach the artifact\n" +
                                              "glowing with sickly green light into the hole etched on the big double gates. It opens with\n" +
                                              "a creaking sound...Sunlight seeps into the darkness and you take your first steps into freedom...");
                                            exploring = false;
                                        }
                                        else
                                        {
                                            Console.WriteLine("You are at the room with the gates again. However, without the artifact that goes in the hole\n" +
                                                "you will never open it. You should explore further.");
                                            buffer = "-s-";


                                        }
                                    }
                                    else
                                    if (chave == true)
                                    {
                                        Console.WriteLine("You find a pair of gargantuous gates, covered in runes caligraphed with rapid\n" +
                                         "and thin strokes. Their green glow guides your way as you try to find a place to open what\n" +
                                           "seems to be your way out of this place. However, it won't open, no matter what you do. Soon,\n" +
                                           "your eyes come upon a slot in the middle of the gates, something clearly designed as a rest for\n" +
                                            "some kind of artifact. The artifact you are carrying glows with even stronger lights, as if begging\n" +
                                            "to be slotted into the gates. You do it, and the gates open with a loud, creaking sound. Sunlight\n" +
                                            "seeps into the darkness and you take your first steps into freedom...");
                                        exploring = false;
                                    }
                                    else
                                    {
                                        Console.WriteLine("You find a pair of gargantuous gates, covered in runes caligraphed with rapid\n" +
                                         "and thin strokes. Their green glow guides your way as you try to find a place to open what\n" +
                                           "seems to be your way out of this place. However, it won't open, no matter what you do. Soon,\n" +
                                           "your eyes come upon a slot in the middle of the gates, something clearly designed as a rest for\n" +
                                            "some kind of artifact. You should be looking for it, if you ever want to leave this place alive.\n" +
                                            "time to look for it in other rooms.");
                                        buffer = "-s-";
                                        foundexit = true;

                                    }
                                }
                            }
                            else
                            {
                                Console.Write("Não é possível se mover nesta direção.");
                            }
                            break;
                        case 3:
                            if (linha < 2)
                            {
                                dungeon[coluna, linha] = buffer;
                                linha++;
                                current = dungeon[coluna, linha];
                                dungeon[coluna, linha] = "-p-";
                                buffer = "-@-";
                                mapshow();
                                if (current == "-@-" && linha == lsaida && coluna == csaida)
                                {
                                    if (chave == true)
                                    {
                                        Console.WriteLine("You find a pair of gargantuous gates, covered in runes caligraphed with rapid\n" +
                                         "and thin strokes. Their green glow guides your way as you try to find a place to open what\n" +
                                           "seems to be your way out of this place. However, it won't open, no matter what you do. Soon,\n" +
                                           "your eyes come upon a slot in the middle of the gates, something clearly designed as a rest for\n" +
                                            "some kind of artifact. The artifact you are carrying glows with even stronger lights, as if begging\n" +
                                            "to be slotted into the gates. You do it, and the gates open with a loud, creaking sound. Sunlight\n" +
                                            "seeps into the darkness and you take your first steps into freedom...");
                                        exploring = false;
                                    }
                                    else
                                    {
                                        Console.WriteLine("You find a pair of gargantuous gates, covered in runes caligraphed with rapid\n" +
                                         "and thin strokes. Their green glow guides your way as you try to find a place to open what\n" +
                                           "seems to be your way out of this place. However, it won't open, no matter what you do. Soon,\n" +
                                           "your eyes come upon a slot in the middle of the gates, something clearly designed as a rest for\n" +
                                            "some kind of artifact. You should be looking for it, if you ever want to leave this place alive.\n" +
                                            "time to look for it in other rooms.");
                                        buffer = "-s-";
                                        foundexit = true;

                                    }

                                }
                                else if (current == "-@-" && linha == lchave && coluna == cchave)
                                {
                                    Console.WriteLine("At the back of the room, you find an pyramidal object hovering in a dome of crystal. \n" +
                                        "you carefully approaches it, and as you come close, the crystal opens itself, inviting you to grab\n" +
                                        "the artifact. You do it, shivering with fear of the consequences, but then... nothing happens. \n" +
                                        "it starts pulsing light in a general direction, as if telling you the way to the exit of this cursed place...");
                                    if (foundexit == true)
                                    {
                                        Console.WriteLine("Something tells you this is the key to the gates you found before. Hope reignites within you. It's\n" +
                                            "time to wake up from this nightmare.");
                                        chave = true;
                                        buffer = "-x-";
                                    }
                                    else
                                    {
                                        Console.Write("The pulsing is as greenish and sickly as everything in this tomb, but a gut feeling tells you that the \n" +
                                            "artifact is showing you the way out. Time to find out if your instincts and this cursed object are to be trusted.");
                                        dungeon[csaida, lsaida] = "-s-";
                                        chave = true;
                                        buffer = "-x-";
                                    }
                                }
                                else if (current == "-@-")
                                {
                                    events();
                                    if (gotit == true)
                                    {
                                        buffer = "-x-";
                                    }
                                    else
                                    {
                                        buffer = "-@-";
                                        if (alive == false)
                                        {
                                            exploring = false;
                                        }
                                    }
                                }
                                else if (current == "-x-")
                                {
                                    Console.Write("Você já passou por essa sala, e apesar das dinâmicas imprevisíveis do lugar, tudo permanece como\n" +
                                        "você lembra. Talvez seja melhor explorar outro lugar.");
                                    buffer = "-x-";
                                }
                                else if (current == "-s-")
                                {
                                    if (foundexit == true)
                                    {
                                        if (chave == true)
                                        {
                                            Console.WriteLine("After the nightmare you have gone through, you finally attach the artifact\n" +
                                              "glowing with sickly green light into the hole etched on the big double gates. It opens with\n" +
                                              "a creaking sound...Sunlight seeps into the darkness and you take your first steps into freedom...");
                                            exploring = false;
                                        }
                                        else
                                        {
                                            Console.WriteLine("You are at the room with the gates again. However, without the artifact that goes in the hole\n" +
                                                "you will never open it. You should explore further.");
                                            buffer = "-s-";


                                        }
                                    }
                                    else
                                    if (chave == true)
                                    {
                                        Console.WriteLine("You find a pair of gargantuous gates, covered in runes caligraphed with rapid\n" +
                                         "and thin strokes. Their green glow guides your way as you try to find a place to open what\n" +
                                           "seems to be your way out of this place. However, it won't open, no matter what you do. Soon,\n" +
                                           "your eyes come upon a slot in the middle of the gates, something clearly designed as a rest for\n" +
                                            "some kind of artifact. The artifact you are carrying glows with even stronger lights, as if begging\n" +
                                            "to be slotted into the gates. You do it, and the gates open with a loud, creaking sound. Sunlight\n" +
                                            "seeps into the darkness and you take your first steps into freedom...");
                                        exploring = false;
                                    }
                                    else
                                    {
                                        Console.WriteLine("You find a pair of gargantuous gates, covered in runes caligraphed with rapid\n" +
                                         "and thin strokes. Their green glow guides your way as you try to find a place to open what\n" +
                                           "seems to be your way out of this place. However, it won't open, no matter what you do. Soon,\n" +
                                           "your eyes come upon a slot in the middle of the gates, something clearly designed as a rest for\n" +
                                            "some kind of artifact. You should be looking for it, if you ever want to leave this place alive.\n" +
                                            "time to look for it in other rooms.");
                                        buffer = "-s-";
                                        foundexit = true;

                                    }
                                }
                            }
                            else
                            {
                                Console.Write("Não é possível se mover nesta direção.");
                            }
                            break;
                        case 4:
                            if (linha > 0)
                            {
                                dungeon[coluna, linha] = buffer;
                                linha--;
                                current = dungeon[coluna, linha];
                                dungeon[coluna, linha] = "-p-";
                                mapshow();
                                if (current == "-@-" && linha == lsaida && coluna == csaida)
                                {
                                    if (chave == true)
                                    {
                                        Console.WriteLine("You find a pair of gargantuous gates, covered in runes caligraphed with rapid\n" +
                                         "and thin strokes. Their green glow guides your way as you try to find a place to open what\n" +
                                           "seems to be your way out of this place. However, it won't open, no matter what you do. Soon,\n" +
                                           "your eyes come upon a slot in the middle of the gates, something clearly designed as a rest for\n" +
                                            "some kind of artifact. The artifact you are carrying glows with even stronger lights, as if begging\n" +
                                            "to be slotted into the gates. You do it, and the gates open with a loud, creaking sound. Sunlight\n" +
                                            "seeps into the darkness and you take your first steps into freedom...");
                                        exploring = false;
                                    }
                                    else
                                    {
                                        Console.WriteLine("You find a pair of gargantuous gates, covered in runes caligraphed with rapid\n" +
                                         "and thin strokes. Their green glow guides your way as you try to find a place to open what\n" +
                                           "seems to be your way out of this place. However, it won't open, no matter what you do. Soon,\n" +
                                           "your eyes come upon a slot in the middle of the gates, something clearly designed as a rest for\n" +
                                            "some kind of artifact. You should be looking for it, if you ever want to leave this place alive.\n" +
                                            "time to look for it in other rooms.");
                                        buffer = "-s-";
                                        foundexit = true;

                                    }

                                }
                                else if (current == "-@-" && linha == lchave && coluna == cchave)
                                {
                                    Console.WriteLine("At the back of the room, you find an pyramidal object hovering in a dome of crystal. \n" +
                                        "you carefully approaches it, and as you come close, the crystal opens itself, inviting you to grab\n" +
                                        "the artifact. You do it, shivering with fear of the consequences, but then... nothing happens. \n" +
                                        "it starts pulsing light in a general direction, as if telling you the way to the exit of this cursed place...");
                                    if (foundexit == true)
                                    {
                                        Console.WriteLine("Something tells you this is the key to the gates you found before. Hope reignites within you. It's\n" +
                                            "time to wake up from this nightmare.");
                                        chave = true;
                                        buffer = "-x-";
                                    }
                                    else
                                    {
                                        Console.Write("The pulsing is as greenish and sickly as everything in this tomb, but a gut feeling tells you that the \n" +
                                            "artifact is showing you the way out. Time to find out if your instincts and this cursed object are to be trusted.");
                                        dungeon[csaida, lsaida] = "-s-";
                                        chave = true;
                                        buffer = "-x-";
                                    }
                                }
                                else if (current == "-@-")
                                {
                                    events();
                                    if (gotit == true)
                                    {
                                        buffer = "-x-";
                                    }
                                    else
                                    {
                                        buffer = "-@-";
                                        if (alive == false)
                                        {
                                            exploring = false;
                                        }
                                    }
                                }
                                else if (current == "-x-")
                                {
                                    Console.Write("Você já passou por essa sala, e apesar das dinâmicas imprevisíveis do lugar, tudo permanece como\n" +
                                        "você lembra. Talvez seja melhor explorar outro lugar.");
                                    buffer = "-x-";
                                }
                                else if (current == "-s-")
                                {
                                    if (foundexit == true)
                                    {
                                        if (chave == true)
                                        {
                                            Console.WriteLine("After the nightmare you have gone through, you finally attach the artifact\n" +
                                              "glowing with sickly green light into the hole etched on the big double gates. It opens with\n" +
                                              "a creaking sound...Sunlight seeps into the darkness and you take your first steps into freedom...");
                                            exploring = false;
                                        }
                                        else
                                        {
                                            Console.WriteLine("You are at the room with the gates again. However, without the artifact that goes in the hole\n" +
                                                "you will never open it. You should explore further.");
                                            buffer = "-s-";


                                        }
                                    }
                                    else
                                    if (chave == true)
                                    {
                                        Console.WriteLine("You find a pair of gargantuous gates, covered in runes caligraphed with rapid\n" +
                                         "and thin strokes. Their green glow guides your way as you try to find a place to open what\n" +
                                           "seems to be your way out of this place. However, it won't open, no matter what you do. Soon,\n" +
                                           "your eyes come upon a slot in the middle of the gates, something clearly designed as a rest for\n" +
                                            "some kind of artifact. The artifact you are carrying glows with even stronger lights, as if begging\n" +
                                            "to be slotted into the gates. You do it, and the gates open with a loud, creaking sound. Sunlight\n" +
                                            "seeps into the darkness and you take your first steps into freedom...");
                                        exploring = false;
                                    }
                                    else
                                    {
                                        Console.WriteLine("You find a pair of gargantuous gates, covered in runes caligraphed with rapid\n" +
                                         "and thin strokes. Their green glow guides your way as you try to find a place to open what\n" +
                                           "seems to be your way out of this place. However, it won't open, no matter what you do. Soon,\n" +
                                           "your eyes come upon a slot in the middle of the gates, something clearly designed as a rest for\n" +
                                            "some kind of artifact. You should be looking for it, if you ever want to leave this place alive.\n" +
                                            "time to look for it in other rooms.");
                                        buffer = "-s-";
                                        foundexit = true;

                                    }
                                }
                            }
                            else
                            {
                                Console.Write("Não é possível se mover nesta direção.");
                            }
                            break;

                    }

                }



            }




        
    } }
    


