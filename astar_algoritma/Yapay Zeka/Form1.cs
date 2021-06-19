using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Yapay_Zeka
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        _8Taş tas;


        int[] Matris = new int[9];
        private void button9_Click(object sender, EventArgs e)
        {
            i = 0;
            j = 0;
            Button[] btn = { button30, button31, button32, button33, button34, button35, button36, button37, button38 };
            for (int i = 0; i < btn.Length; i++)
            {
                Matris[i] = int.Parse(btn[i].Text);
            }
            BulmacayiCoz();
            button9.Enabled = false;
      }

        int[] mevcutd = new int[9];
       bool Kontrol(int[] matrisDegerler, List<int[]> kapaliListe)
        {
            foreach (int[] item in kapaliListe)
            {
                bool isEqual = true;
                for (int i = 0; i < 9; i++)
                {
                    if (item[i] != matrisDegerler[i])
                    {
                        isEqual = false;
                    }
                }
                if (isEqual == true)
                    return true;
            }
            return false;
        }

        _8Taş COCUK(_8Taş tas, int bosluk, int deger)
        {
          
            _8Taş child = new _8Taş();
            Array.Copy(tas.matrisdegerler, child.matrisdegerler, tas.matrisdegerler.Length);

           
            child.g = tas.g + 1;

            
            int temp = child.matrisdegerler[bosluk];
            child.matrisdegerler[bosluk] = child.matrisdegerler[deger];
            child.matrisdegerler[deger] = temp;
            child.HHesapla(Matris);
            child.FHesapla();
            child.parent = tas;
            return child;
        }
        _8Taş YolBul(List<_8Taş> acikListKuyruk)
        {
            int minIndex = 0;
            for (int i = 0; i < acikListKuyruk.Count; i++)
            {
                if (acikListKuyruk[i].f < acikListKuyruk[minIndex].f)
                {
                    minIndex = i;
                    
                }
            }
            return acikListKuyruk[minIndex];
        }






        private bool CozulebilirMi(int[] matrisDegerler, int[] sonucMatrisimiz)
        {
            int cevrim_kontrol = 0;
            for (int i = 0; i < 9; i++)
            {
                for (int j = i + 1; j < 9; j++)
                {
                    for (int k = 0; k < Array.IndexOf(sonucMatrisimiz, matrisDegerler[i]); k++)
                    {
                        if (sonucMatrisimiz[k] == matrisDegerler[j] && matrisDegerler[i] != 0 && matrisDegerler[j] != 0)
                            cevrim_kontrol++;
                    }
                }
            }
            if (cevrim_kontrol % 2 == 0)
                return true;

            return false;
        }


        List<_8Taş> acikListKuyruk;
        int gezilenDugunToplamSayi;
         void BulmacayiCoz()
        {
            gezilenDugunToplamSayi = 0;
            tas = new _8Taş();
            Button[] btn = { button0, button1, button2, button3, button4, button5, button6, button7, button8 };
            int[] mevcutd = new int[9];
            for (int i = 0; i < btn.Length; i++)
            {
                mevcutd[i] = int.Parse(btn[i].Text);
            }
            tas.Okuma(mevcutd);
            acikListKuyruk = new List<_8Taş>();
            List<int[]> kapaliListe = new List<int[]>();
            if (!CozulebilirMi(tas.matrisdegerler, Matris))
            {
                label5.Text = "Problem Çözülemez, Lütfen Tekrar Deneyin";
                return;
            }
            else
                label5.Text = "Problem Çözüldü.";
            tas.HHesapla(Matris);
            tas.FHesapla();
           
            acikListKuyruk.Add(tas);
            Button[] btnn = { button0, button1, button2, button3, button4, button5, button6, button7, button8 };

            do
            {
                tas = YolBul(acikListKuyruk);
                kapaliListe.Add(tas.matrisdegerler);
                int bosluk = Array.IndexOf(tas.matrisdegerler, 0);
                if ((bosluk % 3) != 2)
                {
                    
                    _8Taş cocuk = COCUK(tas, bosluk, bosluk + 1);
                    if (!Kontrol(cocuk.matrisdegerler, kapaliListe))
                    {
                        acikListKuyruk.Add(cocuk);

                    }
                }
                if ((bosluk % 3) != 0)
                {
                   
                    _8Taş cocuk = COCUK(tas, bosluk, bosluk - 1);
                    if (!Kontrol(cocuk.matrisdegerler, kapaliListe))
                    {
                        acikListKuyruk.Add(cocuk);
                   }
                }

                if ((bosluk - 3) >= 0)
                {
                    
                   _8Taş cocuk = COCUK(tas, bosluk, bosluk - 3);
                    if (!Kontrol(cocuk.matrisdegerler, kapaliListe))
                    {
                        acikListKuyruk.Add(cocuk);
                    }
                }

                if ((bosluk + 3) < 9)
                {
                   
                    _8Taş cocuk = COCUK(tas, bosluk, bosluk + 3);
                    if (!Kontrol(cocuk.matrisdegerler, kapaliListe))
                    {
                        acikListKuyruk.Add(cocuk);
                    }
                }
                acikListKuyruk.Remove(tas);
                
                gezilenDugunToplamSayi++;

            } while (tas.h != 0 && acikListKuyruk.Count > 0);
              Sonucyaz(tas, btnn, 0);
           
           }
        private bool Sonucyaz(_8Taş min, Button[] btn, int a)
        {
            Button[] btnn = { button0, button1, button2, button3, button4, button5, button6, button7, button8 };
            if (min == null)
            {
                 return true;
            }

            Sonucyaz(min.parent, btn, a);
            min.SonucYaz(btnn);
            return false;
        }


        int i =0;
        private void yaz(object sender, EventArgs e)
        {
            
            Button btn = (Button)sender;
            Button[] btnn = { button0, button1, button2, button3, button4, button5, button6, button7, button8 };
            
                if(btnn[i].Text=="")
                {
                
                btnn[i].Text = btn.Text;
                i++;
                btn.Enabled = false;
                }
                
         }

        private void button20_Click(object sender, EventArgs e)
        {
            Button[] btnn = { button0, button1, button2, button3, button4, button5, button6, button7, button8 };
            Button[] but = { button11, button12, button13, button14, button15, button16, button17, button18, button19 };
            Button[] butt = { button21, button22, button23, button24, button25, button26, button27, button28, button29 };
            Button[] btn = { button30, button31, button32, button33, button34, button35, button36, button37, button38 };
            for (int i = 0; i < 9; i++)
            {
                btnn[i].Text = "";
                btn[i].Text = "";
                but[i].Enabled = true;
                butt[i].Enabled = true;
                btnn[i].Visible = true;
                btn[i].Visible = true;
                but[i].Visible = true;
                butt[i].Visible = true;
            }
            i = 0;
            button9.Enabled = true;
            label5.Text = "";
        }
        int j = 0;
        private void hedef(object sender, EventArgs e)
        {
            
            Button bt = (Button)sender;
            Button[] btn = { button30, button31, button32, button33, button34, button35, button36, button37, button38 };
            if (btn[j].Text == "")
            {

                btn[j].Text = bt.Text;
                j++;
                bt.Enabled = false;
            }


        }

        private void renk(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            btn.BackColor = Color.Aquamarine;
            btn.ForeColor = Color.DimGray;
        }

        private void renk2(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            btn.BackColor = Color.DimGray;
            btn.ForeColor = Color.Aquamarine;

        }

        private void button40_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button39_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            label5.BackColor = Color.DimGray;
            label5.ForeColor = Color.Aquamarine;
            
        }

        
    }
}
