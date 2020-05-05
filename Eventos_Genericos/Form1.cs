using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Eventos_Genericos
{
    public partial class Form1 : Form
    {
        private List<Datos> ListaDatos;
        private class Datos
        {
            public Label Destino;
            public decimal multiplicador;
            public int indice;
        }
        public Form1()
        {
            InitializeComponent();
            ListaDatos = new List<Datos>
            {
                new Datos() {indice=1,multiplicador=200,Destino=label5 },
                new Datos() {indice=2,multiplicador=100,Destino=label6 },
                new Datos() {indice=3,multiplicador=50,Destino=label7 },
                new Datos() {indice=4,multiplicador=0.5M,Destino=label8 }
            };
        }

        private void textBox_KeyPress(object sender, KeyPressEventArgs e)
        {
               //Para obligar a que sólo se introduzcan números
                if (Char.IsDigit(e.KeyChar))
                {
                    e.Handled = false;
                }
                else
                  if (Char.IsControl(e.KeyChar)) //permitir teclas de control como retroceso
                {
                    e.Handled = false;
                }
                else
                {
                    //el resto de teclas pulsadas se desactivan
                    e.Handled = true;
                }
            
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            //Sabemos que sender es un textbox, porque este evento solo atiende textbox
            // porque solo lo usamos para eso
            TextBox tb = (TextBox)sender;
            if (tb.Text.Length < 1) return;
            //ahora buscamos el tag del textbox
            int indice = int.Parse(tb.Tag.ToString());
            //Ahora tengo que ubicar en la lista que arme antes el objeto que tiene este indice
            var d = ListaDatos.First(s => s.indice == indice);
            d.Destino.Text = (d.multiplicador * int.Parse(tb.Text)).ToString();
        }
    }
}
