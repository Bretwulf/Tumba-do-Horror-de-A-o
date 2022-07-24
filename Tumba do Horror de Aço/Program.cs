using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tumba_do_Horror_de_Aço
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Engine engine = new Engine();
            PC heroi = new PC();
            string hisname = "";
           
// ============================================ INTRODUÇÃO =============================================== //
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("It is the 41st Millennium. For more than a hundred centuries The Emperor\n" +
                " has sat immobile on the Golden Throne of Earth. He is the Master of Mankind by the will\n" +
                " of the gods, and master of a million worlds by the might of his inexhaustible armies. He\n" +
                " is a rotting carcass writhing invisibly with power from the Dark Age of Technology. He is\n" +
                " the Carrion Lord of the Imperium for whom a thousand souls are sacrificed every day, so that\n" +
                " he may never truly die.Yet even in his deathless state, the Emperor continues his eternal\n" +
                " vigilance.Mighty battlefleets cross the daemon - infested miasma of the Warp, the only route\n" +
                " between distant stars, their way lit by the Astronomican, the psychic manifestation of the\n" +
                " Emperor's will. Vast armies give battle in his name on uncounted worlds. Greatest amongst his\n" +
                " soldiers are the Adeptus Astartes, the Space Marines, bio-engineered super-warriors. Their\n" +
                " comrades in arms are legion: the Imperial Guard and countless planetary defence forces, the\n" +
                " ever vigilant Inquisition and the tech-priests of the Adeptus Mechanicus to name only a few.\n" +
                " But for all their multitudes, they are barely enough to hold off the ever-present threat from\n" +
                " aliens, heretics, mutants - and worse.To be a man in such times is to be one amongst untold\n" +
                " billions.It is to live in the cruelest and most bloody regime imaginable.These are the tales of\n" +
                " those times.Forget the power of technology and science, for so much has been forgotten, never to be\n" +
                " re - learned.Forget the promise of progress and understanding, for in the grim dark future there is\n" +
                " only war. There is no peace amongst the stars, only an eternity of carnage and slaughter, and the\n" +
                " laughter of thirsting gods.");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("--------------------------------------------------------------------------------------------------------------------");
            Console.WriteLine("Among those untold centuries of war, you are a mere guardsmen, one soldier among billions.\n" +
                "after a hard fought battle on the cruel surface of the death world Caesar XVII, your group is backed down by the forces\n" +
                "of chaos to an old ruin, a black pyramid showered in green glow coming from a jagged crystal at it's top. without option\n" +
                "but to face the unknown...");
            Console.WriteLine("You run into the ancient glassy pyramid, but you soon find yourself lost among the shadows and the labyrinthean\n" +
                "walls of the place. A faint green glow is coming from every corner of your vision, and looking back, you see the stuff of nightmares\n" +
                "coming after you: metallic skeletons, with transfixed green eyes, shining in the green light like steel specters, carrying surreal \n" +
                "coiled guns in their hands. You ruin in despair, hiding yourself in a dark corner, not sure if those things can see you the dark. \n" +
                "they pass along, having aparently lost you in the shadows. You have no time for relief. White noise fills your audition as your radio\n" +
                "picks up a signal. Your comissar orders you to find an exit from this damned place and send a signal from there, acting as a beacon for\n" +
                "the rest of the survivors.");
            Console.WriteLine("You gather your courage, check your lasgun, count your power packs, and prepare to engage in battle. However, when you \n" +
                "step in the room you were before, fear fills your heart: the entire layout of the place changed, along with entrances and exits.\n" +
                "however you know there is no option but to go fowards. Your comissar call you again from the radio. This time he asks you a single\n" +
                "question:");
            Console.ForegroundColor= ConsoleColor.Red;
            Console.WriteLine("What's your name, anyway, son?");
            hisname = Console.ReadLine();
            Console.WriteLine("You gather your bearings and walk into the darkness, knowing that you may never see light again...");

            //======================================================= O JOGO ============================================//
           
            engine.heroi.criar(hisname, 25, 12, 3, 6);
            engine.heroi.gerarinventario("Standard Lasgun", "Military Uniform");
            engine.heroi.textoacerto = "Your shot goes through the enemy armor and hits it with force!";
            engine.heroi.textoataque = "You raise your gun to bear, preparing a volley of fire at the enemy!";
            engine.heroi.textocritico = "Your shot hits an weak spot of the enemy armor, destroying many vital\n" +
                "systems and considerably weakening it!";
            engine.mapcreate();
            engine.navigation();
            if (engine.alive == true)
            {
                Console.WriteLine("You finally leave the place. However, as you radio your squadmates, all you hear is whitenoise.\n" +
                    "at the back of the transmission, you can hear a deep bass voice saying: 'You may have survided, human, but your\n" +
                    "soul has not. In your dreams you will wander my tomb again, but this time you will never leave, just like your\n" +
                    "comrades.' The screams of agony and pain you heard after will forever haunt your nightmares... but at least...\n" +
                    "you lived to see another day, another battle, for in the darkness of future... THERE IS ONLY WAR.");
            }
            else 
            {
                Console.WriteLine("Life escapes from you, and your last prayers are lost. You will never know the fate of your comrades\n" +
                    "or the sweet peace that the generals and comissars promissed you after the war. But at least, you found peace in death\n" +
                    "or so you tought, for in the moment that your senses came to a end, something stayed with you: four laughters, mocking\n" +
                    "your death, mocking the existence of another soul for their consumption. Not even in death you find respite from the claws\n" +
                    "of chaos. Even in death, THERE IS ONLY WAR.");
            }

            Console.Read();


        }
    }
}
