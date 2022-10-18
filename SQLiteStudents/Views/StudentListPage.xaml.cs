using SQLiteStudents.ViewModels;

namespace SQLiteStudents.Views;

public partial class StudentListPage : ContentPage
{

	private StudentListPageViewModel _viewModel;
	public StudentListPage(StudentListPageViewModel viewModel)
	{
		InitializeComponent();
		_viewModel = viewModel;
		this.BindingContext = viewModel;
	}

	protected override void OnAppearing()
	{
		base.OnAppearing();
		_viewModel.GetStudentsListCommand.Execute(null);

	}
}