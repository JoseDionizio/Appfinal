using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace AppFinal
{
    public partial class Index : ContentPage
    {

        public Index()
        {
            InitializeComponent();

            this.FindByName<Button>("Btngraducao").Clicked += PGraduado;
            this.FindByName<Button>("Btnmestrado").Clicked += Mestrado;
            this.FindByName<Button>("Btndoutorado").Clicked += Dourtorado;




        }
        public void PGraduado(object sender, EventArgs e)
        {
            Calcular(this.SalarioBruto.Text, "Graduacao");

        }
        public void Mestrado(object sender, EventArgs e)
        {
            Calcular(this.SalarioBruto.Text, "Mestrado");

        }
        public void Dourtorado(object sender, EventArgs e)
        {
            Calcular(this.SalarioBruto.Text, "Doutorado");
        }

        public void Calcular(string val, string tipo)
        {
            Decimal vencimento = Convert.ToDecimal(val);
            decimal gratific = 0;
            decimal inss = 0;
            decimal base_calc = 0;
            decimal imposto = 0;
            if (tipo.Equals("Doutorado"))
            {
                gratific = 1500;


            }
            if (tipo.Equals("Mestrado"))
            {
                gratific = 1000;

            }
            if (tipo.Equals("Graduacao"))
            {
                gratific = 500;

            }
            decimal perc = 55 / 2;
            inss = ((vencimento + gratific) * 11 / 100);
            base_calc = (vencimento - inss + gratific);
            imposto = ((base_calc * perc / 100) - 869);
            Decimal salariofinal = (base_calc - imposto + 300);

            this.SalarioL.Text = salariofinal.ToString();


            string relatorio = "Inss: " + inss.ToString() + "\nSalario Base: " + base_calc.ToString() + "\nImposto: " + imposto.ToString();

            var newLabel = new Label()
            {
                Text = relatorio
            };


            this.BtnRelatorio.Clicked += (sender, e) =>
            {
                DisplayAlert("Relatorio", newLabel.Text, "OK");
            };



        }

    }
}
