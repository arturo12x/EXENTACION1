using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EXENTACION1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
 

        private void Form1_Load(object sender, EventArgs e)
        {
            //      
            CB1.SelectedIndex = 0;
        }

        private void BTN1_Click(object sender, EventArgs e)
        {
            string  TXTPRODUCTO, TXTCANTIDAD, TXTPRECIO, TXTSUBTOTAL,TXTDESCUENTO,TXTTOTAL,ERROR;
            double CANTIDAD, PRECIO, SUBTOTAL, DESCUENTO, TOTAL,SUB,DESC2,TOTAL2;

            TXTPRODUCTO = CB1.Text;
            TXTCANTIDAD=TXT1.Text;
            TXTPRECIO=TXT2.Text;
            TXTSUBTOTAL="0";
            TXTDESCUENTO="0";
            TXTTOTAL="0";
            TOTAL = 0;
            TOTAL2 = 0;
            ERROR = "";
            TXT1.BackColor = Color.White;
            TXT2.BackColor = Color.White;




            //VALIDACIONES
            if (string.IsNullOrWhiteSpace(TXTCANTIDAD))
            {
                ERROR += " NO PUEDES DEJAR VACIO EL CAMPO CANTIDAD";
                TXT1.BackColor = Color.DarkRed;

            }
            if (string.IsNullOrWhiteSpace(TXTPRECIO))
            {
                ERROR += " NO PUEDES DEJAR VACIO EL CAMPO PRECIO";
                TXT2.BackColor = Color.DarkRed;

            }
            if (ERROR != "")
            {
                MessageBox.Show(ERROR, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }







            SUBTOTAL = Convert.ToDouble(TXTCANTIDAD)*Convert.ToDouble(TXTPRECIO);
            TOTAL = Convert.ToDouble(TXTCANTIDAD) * Convert.ToDouble(TXTPRECIO);


            if (checkBox1.Checked == true)
            {
                TXTDESCUENTO = "20";
                DESCUENTO=(SUBTOTAL*0.20);
                TOTAL =SUBTOTAL-DESCUENTO ;
            }
            TXTSUBTOTAL = SUBTOTAL.ToString();
            TXTTOTAL = TOTAL.ToString();


   



            DGV1.Rows.Add(TXTPRODUCTO, TXTCANTIDAD, TXTPRECIO, TXTSUBTOTAL, TXTDESCUENTO, TXTTOTAL);
            foreach (DataGridViewRow row1 in DGV1.Rows)
            {
                string CHECAR = "";
                CHECAR = Convert.ToString(DGV1[4, row1.Index].Value);
                if (CHECAR == "20")
                {
                    DGV1[4, row1.Index].Style.BackColor = Color.Red;
                    DGV1[5, row1.Index].Style.BackColor = Color.Red;
                }

                TOTAL2 += Convert.ToDouble(DGV1[5, row1.Index].Value);
            }

            label6.Text = Convert.ToString(TOTAL2);
        }

        private void TXT1_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = (char.IsLetter(e.KeyChar) || e.KeyChar == (char)Keys.Space ||  e.KeyChar == '-');
        }

        private void TXT2_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = (char.IsLetter(e.KeyChar) || e.KeyChar == (char)Keys.Space || e.KeyChar == '-');
        }

        private void BTN2_Click(object sender, EventArgs e)
        {
            TXT1.Text = "";
            TXT2.Text = "";
            label6.Text = "";
            CB1.SelectedIndex = 1;
            this.DGV1.Rows.Clear();
     
            TXT1.BackColor = Color.White;
            TXT2.BackColor = Color.White;
        }
    }
}
