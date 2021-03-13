using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AtelierN1
{
    class Compte
    {
        private static int cmp;
        private readonly int numCompte;
        private readonly Client titulaire;
        private MAD solde;
        private static MAD plafond;
        //Constructeur statique qui sert a initialiser les attributs statiques
        static Compte()
        {
            cmp = 0;
            plafond = new MAD(5000);
        }
        public Compte(Client C, MAD solde)
        {
            cmp++;
            numCompte = cmp;
            titulaire = C;
            this.solde = solde;
        }
        //Methodes
        public void Afficher()
        {
            Console.WriteLine("Numero de compte : "+numCompte+"\nInformations du titulaire : ");
            titulaire.afficher();
            Console.Write("Solde : ");
            solde.print();
            Console.Write("Plafond : ");
            plafond.print();
        }
        public void ConsulterSolde()
        {
            Console.Write("Votre nouveau solde est de : ");
            solde.print();
        }
        public void Crediter(MAD montant)
        {
            if (montant > new MAD() )
            {
                solde.Egal(solde+montant);
                //solde.Egal(solde.Plus(montant));
                Console.WriteLine("Opération de Créditation effectuée avec succès");
            }
            else
                Console.WriteLine("Opération echouée : Montant a créditer non valide");
        }
        public void Debiter(MAD montant)
        {
            if (montant > new MAD() && montant<solde ) { 
                solde.Egal(solde-montant);
                Console.WriteLine("Opération de Débit effectuée avec succès");
            }
            else
                Console.WriteLine("Opération echouée : Montant a débiter non valide");
        }
        public void Retirer(MAD montant)
        {
            if (montant<plafond && montant>new MAD())
            {
                solde.Egal(solde - montant);
                //solde.Egal(solde.Moins(montant));
            }
            else
                Console.WriteLine("Vous ne pouvez pas depasser le plafond designe");
        }
        public void Verser(Compte C,MAD montant)
        {
            this.Debiter(montant);
            C.Crediter(montant);
        }

    }
}
