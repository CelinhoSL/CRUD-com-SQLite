using CRUD_com_SQlite.Models;
using System.Threading.Tasks;

namespace CRUD_com_SQlite.Views;

public partial class NovoProduto : ContentPage
{
	public NovoProduto()
	{
		InitializeComponent();
	}

    private async void ToolbarItem_Clicked(object sender, EventArgs e)
    {
		try
		{
			Produto p = new Produto
			{
                Categoria = txt_categoria.Text,
                Descricao = txt_descricao.Text,
				Quantidade = Convert.ToDouble(txt_quantidade.Text),
				Preco = Convert.ToDouble(txt_preco.Text)
			};

			await App.Db.Insert(p);
			await DisplayAlert("Sucesso", "Salvo com sucesso", "OK");
            await Navigation.PopAsync();
        }
		catch(Exception ex)
		{
			await DisplayAlert("Ops!", ex.Message, "OK");
		}

    }
}