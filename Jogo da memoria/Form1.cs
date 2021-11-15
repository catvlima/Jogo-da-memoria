using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Jogo_da_memoria
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            PreencherTabela();
           
        }

        Random randi = new Random();

        List<string> Icones = new List<string>()
        {
            "b", "b", "e", "e", "h", "h", "j", "j", "L", "L", "$", "$", ", ", ", ", "l", "l"
        };

        Label PrimeiraClick = null;
        Label SegundaClick = null;

        public void PreencherTabela()
        {
            int indice;

            foreach (Control controlo in tableLayoutPanel1.Controls)
            {
                Label iconelabel = controlo as Label;
                if(iconelabel != null)
                {
                    indice = randi.Next(Icones.Count);
                    iconelabel.Text = Icones[indice];
                    Icones.RemoveAt(indice);
                    iconelabel.ForeColor = iconelabel.BackColor;
                    
                }
            }
        }


        public void Ganhou()
        {
            foreach(Control controlo in tableLayoutPanel1.Controls)
            {
                Label iconelabel = controlo as Label;
                if (iconelabel != null)
                {
                    if (iconelabel.ForeColor == iconelabel.BackColor)
                        return;

                }
            }

            MessageBox.Show("Parabéns!! Ganhou o jogo!");
            Close();
        }

        private void Label_Click(object sender, EventArgs e)
        {
            Label labelclicked = sender as Label;
            if(labelclicked != null)
            {
                if (labelclicked.ForeColor == Color.Thistle)
                    return;
                if(PrimeiraClick == null)
                {
                    PrimeiraClick = labelclicked;
                    PrimeiraClick.ForeColor = Color.Thistle;
                    return;
                }

                SegundaClick = labelclicked;
                SegundaClick.ForeColor = Color.Thistle;

                Ganhou();

                if(PrimeiraClick.Text == SegundaClick.Text)
                {
                    PrimeiraClick = null;
                    SegundaClick = null;
                    return;
                }
                timer1.Start();
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Stop();
            PrimeiraClick.ForeColor = PrimeiraClick.BackColor;
            SegundaClick.ForeColor = SegundaClick.BackColor;

            PrimeiraClick = null;
            SegundaClick = null;
            return;

        }
    }
}
