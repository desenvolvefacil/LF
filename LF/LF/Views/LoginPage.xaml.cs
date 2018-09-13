using LF.Models;
using LF.Utils;
using LF.WS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace LF.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class LoginPage : ContentPage
	{

		public LoginPage ()
		{
			InitializeComponent ();
		}

        protected override bool OnBackButtonPressed()
        {
            App.Current.MainPage = new MainPage();

            return true;
        }

            private async void Logar_Clicked(object sender, EventArgs e)
        {
            UsuarioModel usu = new UsuarioModel() { Email=LoginEmail.Text,Senha=LoginSenha.Text};

            usu = await new UsuarioWS().LoginUsuario(usu);

            if (usu!=null && usu.Id > 0)
            {
                Util.UsuarioLogado = usu;

                await Navigation.PopModalAsync();
            }
        }


        private async Task Cadastrar_Clicked(object sender, EventArgs e)
        {
            //valida o nome
            if (String.IsNullOrWhiteSpace(CadastroNome.Text))
            {
                await DisplayAlert("Nome inválido!", "Digite seu nome.", "Cancelar");
                CadastroNome.Focus();
            }
            else
            {
                //valida o email
                if (!IsValidEmail(CadastroEmail.Text))
                {
                    await DisplayAlert("E-mail inválido!", "Digite seu e-mail.", "Cancelar");
                    CadastroEmail.Focus();
                }
                else
                {

                    //valida a senha
                    if (String.IsNullOrWhiteSpace(CadastroSenha.Text) || CadastroSenha.Text.Length < 5)
                    {
                        await DisplayAlert("Senha inválida!", "Digite sua senha.", "Cancelar");
                        CadastroSenha.Focus();
                    }
                    else
                    {
                        //define e cadastra o usuario no ws
                        UsuarioModel usu = new UsuarioModel() { Nome = CadastroNome.Text, Senha = CadastroSenha.Text, Email = CadastroEmail.Text };

                        usu = await new UsuarioWS().AddUsuario(usu);

                        if (usu != null && usu.Id > 0)
                        {
                            Util.UsuarioLogado = usu;

                            await Navigation.PopModalAsync();
                        }
                        else
                        {
                            await DisplayAlert("Erro!", "Erro ao cadastrar!", "Cancelar");
                        }

                    }
                }
            }
        }

        //valida o email
        public static bool IsValidEmail(string strIn)
        {
            if (String.IsNullOrWhiteSpace(strIn))
            {
                return false;
            }
            else
            {

                // Return true if strIn is in valid e-mail format.
                /*return Regex.IsMatch(strIn,
                       @"^(?("")("".+?""@)|(([0-9a-zA-Z]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)(?<=[0-9a-zA-Z])@))" +
                       @"(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([0-9a-zA-Z][-\w]*[0-9a-zA-Z]\.)+[a-zA-Z]{2,6}))$");
        */

                return Regex.IsMatch(strIn, @"[\w\.-]+(\+[\w-]*)?@([\w-]+\.)+[\w-]+");
            }
        }

    }
}