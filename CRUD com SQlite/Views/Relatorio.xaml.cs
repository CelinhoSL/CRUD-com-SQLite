using CRUD_com_SQlite.Models;
using CRUD_com_SQlite.Helpers;
using System.Collections.ObjectModel;

namespace CRUD_com_SQlite.Views;

public partial class Relatorio : ContentPage
{
    ObservableCollection<Produto> lista_categoria = new ObservableCollection<Produto>();

    public Relatorio()
    {
        InitializeComponent();

        lst_categoria.ItemsSource = lista_categoria;
        
    }


    protected async override void OnAppearing()
    {
        base.OnAppearing();

        lista_categoria.Clear();

        try
        {
            List<Produto> tmp = await App.Db.GetTag();
            tmp.ForEach(i => lista_categoria.Add(i));
        }
        catch (Exception ex)
        {
            await DisplayAlert("Ops", ex.Message, "OK");
        }
    }



    private void voltar_Clicked(object sender, EventArgs e)
    {
        Navigation.PopAsync();
    }

    private void lst_categoria_Refreshing(object sender, EventArgs e)
    {
        
    }

}