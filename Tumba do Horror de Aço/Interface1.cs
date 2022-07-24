
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tumba_do_Horror_de_Aço
{
    internal interface StatBase
    {
        void criar(string name, int vida, int armadura, int ataque, int damage);
        void texto_ataque();
        void texto_acerto();
        void texto_critico();
        void texto_morte();
        void cover();

    }
}
