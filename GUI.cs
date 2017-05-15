using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace PrzepływCiepłaTester
{
    public partial class GUI : Form
    {
        public GUI()
        {
            InitializeComponent();
            test = new Test();
            losujPytanie();
            nastepnePytanieButton.Enabled = false;
            aboutBox = new AboutBox();
            autorzyImageBox.Visible = autorzyLabel1.Visible = autorzyLabel2.Visible = false;
        }




        private Test test;

        private void wynikButton_Click(object sender, EventArgs e)
        {
            MessageBox.Show(test.pokazWynik());
        }

        private void nastepnePytanieButton_Click(object sender, EventArgs e)
        {
            losujPytanie();
            odpowiedzLabel.Text = " ";
            nastepnePytanieButton.Enabled = false;
            odpowiedzButton.Enabled = true;
        }

        private void losujPytanie()
        {
            pytanieTresc.Text = test.dajPytanie();

            List<String> odpowiedzi = test.dajOdpowiedzi();
            autorzyImageBox.Visible = autorzyLabel1.Visible = autorzyLabel2.Visible = false;

            int iloscOdpowiedzi = 0;
            for (iloscOdpowiedzi = 0; iloscOdpowiedzi < odpowiedzi.Count; iloscOdpowiedzi++)
                setOdpowiedz(iloscOdpowiedzi, odpowiedzi[iloscOdpowiedzi]);

            switch (odpowiedzi.Count)
            {
                case 3:
                    d_odp_radioButton.Visible = odpowiedz_d.Visible = e_odp_radioButton.Visible = odpowiedz_e.Visible = f_odp_radioButton.Visible = odpowiedz_f.Visible = false;
                    break;

                case 4:
                    e_odp_radioButton.Visible = odpowiedz_e.Visible = f_odp_radioButton.Visible = odpowiedz_f.Visible = false;
                    break;

                case 5:
                    f_odp_radioButton.Visible = odpowiedz_f.Visible = false;
                    break;

            }



        }

        private void setOdpowiedz(int i, String odp)
        {
            switch (i)
            {
                case 0:
                    odpowiedz_a.Text = odp;
                    a_odp_radioButton.Visible = odpowiedz_a.Visible = true;
                    break;

                case 1:
                    odpowiedz_b.Text = odp;
                    b_odp_radioButton.Visible = odpowiedz_b.Visible = true;
                    break;

                case 2:
                    odpowiedz_c.Text = odp;
                    c_odp_radioButton.Visible = odpowiedz_c.Visible = true;
                    break;
                case 3:
                    odpowiedz_d.Text = odp;
                    d_odp_radioButton.Visible = odpowiedz_d.Visible = true;
                    break;

                case 4:
                    odpowiedz_e.Text = odp;
                    e_odp_radioButton.Visible = odpowiedz_e.Visible = true;
                    break;

                case 5:
                    odpowiedz_f.Text = odp;
                    f_odp_radioButton.Visible = odpowiedz_f.Visible = true;
                    break;
            }
        }

        private char getOdp()
        {
            if (a_odp_radioButton.Checked)
                return 'a';
            if (b_odp_radioButton.Checked)
                return 'b';
            if (c_odp_radioButton.Checked)
                return 'c';
            if (d_odp_radioButton.Checked)
                return 'd';
            if (e_odp_radioButton.Checked)
                return 'e';
            else
                return 'f';
        }

        private void odpowiedzButton_Click(object sender, EventArgs e)
        {
            if (test.udzielamOdpowiedzi(getOdp()))
            {
                odpowiedzLabel.Text = "To jest poprawna odpowiedz. Gratulacje!";
                odpowiedzLabel.ForeColor = Color.Green;
                odpowiedzButton.Enabled = false;
                autorzyImageBox.Visible = autorzyLabel1.Visible = autorzyLabel2.Visible = true;

            }
            else
            {
                odpowiedzLabel.Text = "To nie jest poprawna odpowiedz!";
                odpowiedzLabel.ForeColor = Color.Red;
                autorzyImageBox.Visible = autorzyLabel1.Visible = autorzyLabel2.Visible = false;
            }

            wynikProcent.Text = test.getWynik() + "%";
            progressBarWynik.Maximum = 100;
            progressBarWynik.Value = (int)test.getWynik();
            nastepnePytanieButton.Enabled = true;
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void bindingSource1_CurrentChanged(object sender, EventArgs e)
        {

        }

       
        private AboutBox aboutBox;

        private void oProgramieToolStripMenuItem_Click(object sender, EventArgs e)
        {
            aboutBox = new AboutBox();
            aboutBox.Visible = true;
        }
    }
}
