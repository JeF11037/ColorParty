using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace ColorParty
{
    public partial class MainPage : ContentPage
    {
        int rr = 0;
        int gg = 0;
        int bb = 0;
        int aa = 0;

        bool goon = true;
        bool rever = false;

        int temp = 0;

        public MainPage()
        {
            InitializeComponent();
        }

        private void ValueChanged(object sender, ValueChangedEventArgs e)
        {
            if (sender == r)
            {
                rl.Text = String.Format("Red = {0:X2}", (int)e.NewValue);
                r.ThumbColor = Color.FromRgb((int)e.NewValue, 0, 0);
                r.BackgroundColor = Color.FromRgb(255 - (int)e.NewValue, 0, 0);
            }
            else if (sender == g)
            {
                gl.Text = String.Format("Green = {0:X2}", (int)e.NewValue);
                g.ThumbColor = Color.FromRgb(0, (int)e.NewValue, 0);
                g.BackgroundColor = Color.FromRgb(0, 255 - (int)e.NewValue, 0);
            }
            else if (sender == b)
            {
                bl.Text = String.Format("Blue = {0:X2}", (int)e.NewValue);
                b.ThumbColor = Color.FromRgb(0, 0, (int)e.NewValue);
                b.BackgroundColor = Color.FromRgb(0, 0, 255 - (int)e.NewValue);
            }
            else if (sender == a)
            {
                al.Text = String.Format("Alpha = {0:X2}", (int)e.NewValue);
            }

            rr = (int)r.Value;
            gg = (int)g.Value;
            bb = (int)b.Value;
            aa = (int)a.Value;

            box.BackgroundColor = Color.FromRgba((int)r.Value, (int)g.Value, (int)b.Value, (int)a.Value);
        }

        // ГЛОБАЛЬНОЕ ИЗМЕНЕНИЕ

        private void CheckAndSetColor() 
        {
            if (rever)
            {
                if (rr < 255) { rr++; }
                else if (gg < 255) { gg++; }
                else if (bb < 255) { bb++; }
                else { rever = false; }

                if (temp >= 4) { aa++; temp = 0; }

            } else
            {
                if (rr > 1) { rr--; }
                else if (gg > 1) { gg--; }
                else if (bb > 1) { bb--; }
                else { rever = true; }

                if (temp >= 4) { aa--; temp = 0; }
            }

            temp++;
        }

        private async void btn_Clicked(object sender, EventArgs e)
        {
            goon = true;

            while (goon)
            {
                await Task.Delay(1);

                CheckAndSetColor();

                a.Value = aa;
                r.Value = rr;
                g.Value = gg;
                b.Value = bb;

                box.BackgroundColor = Color.FromRgba(rr, gg, bb, aa);
            }
        }

        private void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            goon = false;
        }
    }
}
