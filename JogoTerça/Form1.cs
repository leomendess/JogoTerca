using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JogoTerça
{
    public partial class Form1 : Form
    {
        private Label primeiroClique = null;
        private Label segundoClique = null; 
        Random random = new Random();

        private List<string> icones = new List<string>()
        {
            // pares de elementos que vão a tabela
            "!", "!", "N", "N", ",", ",", "k", "k",
            "b", "b", "v", "v", "H", "H", "z", "z"

        };

        public object Table { get; private set; }

        // metodo que vai adicionar simbolos aleatorio
        private void AdicionaIconesQuadrados()
        {
            // nosso panel tem 16 quadrados
            // lista contém 16 elemento no caso 8 pares
            // ler a lista e adicionar o icone a tabela


            foreach (Control controle in tblTabuleiro.Controls)
            {
                Label icone = controle as Label;
                if (icone != null)
                {
                    int numeroAleatorio = random.Next(icones.Count);

                    icone.Text = icones[numeroAleatorio];
                    icones.RemoveAt(numeroAleatorio);
                }
            }
        }
        public Form1()
        {
            InitializeComponent();
            AdicionaIconesQuadrados();
        }

        private void AdiconaIcones()
        {
            foreach (Control control in tblTabuleiro.Controls)
            {
                var iconLabel = control as Label;
                if (iconLabel != null)
                {
                    var randomNumber = random.Next(icones.Count);
                    // colocando o ícone referente ao número aleatório na label
                    iconLabel.Text = icones[randomNumber];
                    // Ajustando a cor do ícone para torná-lo invisível
                    iconLabel.ForeColor = iconLabel.BackColor;
                    // remove o ícone adicionado da lista de ícones
                    icones.RemoveAt(randomNumber);
                }
            }
        }



        private void label1_Click(object sender, EventArgs e)
        {
            //sender sera usado para captar o icone o qual o  usario jogador clicou

            Label iconeClicado = sender as Label;

            if (iconeClicado != null)
            {
                if (iconeClicado.ForeColor == Color.Black)
                {
                    return;
                }
                if (primeiroClique == null)
                {
                    primeiroClique = iconeClicado;
                    primeiroClique.ForeColor = Color.Black;
                    return;

                }

                iconeClicado.ForeColor = Color.Black;
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}

     