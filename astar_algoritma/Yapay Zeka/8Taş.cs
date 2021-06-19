using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Yapay_Zeka
{
   public class _8Taş
    {

        public int[] matrisdegerler;
        public int g; 
        public int h;
        public int f; 
        public _8Taş parent;


        private List<_8Taş> list;

        internal List<_8Taş> List { get => list; set => list = value; }

        public _8Taş()
        {
            matrisdegerler = new int[9];
            parent = null;
        }
        public _8Taş(List<_8Taş> l)
        {
            List = l;
        }
        public void FHesapla()
        {
            f = g + h;
        }

       
        public void HHesapla(int [] Matris)
        {
            
            h = 0;
            for (int i = 0; i < 9; i++)
            {
                int sonucIndex = Array.IndexOf(Matris, matrisdegerler[i]);
                int sutun = Math.Abs((i % 3) - (sonucIndex % 3));
                int satir = Math.Abs((i / 3) - (sonucIndex / 3));
                
                h += sutun + satir;
            }
        }

        
        public void Okuma(int[]button)
        {
           for (int i = 0; i < 9; i++)
            {
                matrisdegerler[i] = button[i];
                
            }
        }



        public void SonucYaz(Button[] textBox)
        {
            for (int i = 0; i < 9; i++)
            {
                textBox[i].Visible = true;
            }
            for (int i = 0; i < 9; i++)
            {

                if (matrisdegerler[i] == 0)
                {
                    textBox[i].Text = "  ";
                    textBox[i].Visible = false;
                }
                else
                {
                    textBox[i].Text = matrisdegerler[i].ToString() + "";
                    
                }
                   
            }
            
            MessageBox.Show("Sonraki Adım");

            
        }
       

    }

  
}

