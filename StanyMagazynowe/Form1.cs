using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StanyMagazynowe
{
    public partial class Form1 : Form
    {
        int IDSzukane;
        public Form1()
        {
            InitializeComponent();
            
        }

        public void ListBoxLoad()
        {
            {
                listBox1.Items.Clear();
                listBox2.Items.Clear();
                using (var db = new ObslugaBazy())
                {
                    var towary = db.Towar.ToList();
                    foreach (var towar in towary)
                    {
                        string powlaczone = towar.Nazwa + " " + towar.Jednostka;
                        listBox1.Items.Add(powlaczone);
                    }
                    ;

                }
                using (var db = new ObslugaBazy())
                {
                        var ilosci = db.StanMagazynowy.ToList();
                        foreach (var Ilosc in ilosci)
                        {

                            listBox2.Items.Add(Ilosc.Ilosc);

                        }

                }


            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            ListBoxLoad();
            string[] wartosci = { textBox1.Text, textBox2.Text, textBox3.Text };
            ObslugaBazy baza = new ObslugaBazy();
            baza.Towar.Add(new Towar { Nazwa = wartosci[0], Jednostka = wartosci[1] });
            baza.SaveChanges();
            IDSzukane = baza.Towar.Count();
            baza.StanMagazynowy.Add(new StanMagazynowy { Ilosc = Convert.ToInt32(wartosci[2]), FKID_Towar = IDSzukane });
            baza.SaveChanges();
            ListBoxLoad();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ListBoxLoad();
        }
    }
}