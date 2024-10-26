using System.Diagnostics.CodeAnalysis;

namespace SirenStudio;


[SuppressMessage("ReSharper", "InconsistentNaming")]
public partial class MainPage
{
    private string m_project_name = string.Empty;
    private string m_project_path = string.Empty; 
    
    private static readonly FilePickerFileType s_custom_file_type = new FilePickerFileType(
        new Dictionary<DevicePlatform, IEnumerable<string>>
        {
            { DevicePlatform.WinUI, [".srn"] },
            { DevicePlatform.macOS, [".srn"] }, 
        });

    private readonly PickOptions m_options = new()
    {
        PickerTitle = "Please select a project",
        FileTypes = s_custom_file_type,
    };

    public MainPage()
    {
        InitializeComponent();
    }

    private async void OpenExplorerWindow(object sender, EventArgs e)
    {
        try
        {
            var result = await FilePicker.Default.PickAsync(m_options);
            if (result != null)
            {
                m_project_path = result.ToString() ?? string.Empty;
            }

        }
        catch (Exception ex)
        {
            Console.WriteLine(ex);
            throw;
        }
    }

    private void CheckFullPath()
    {
        if (m_project_name != string.Empty && m_project_path != string.Empty)
        {
            PathLabel.Text = $"Project will be created in: {m_project_path}\\{m_project_name}";
        }
    }

    private void OnNameTextChanged(object sender, TextChangedEventArgs e)
    {
        m_project_name = e.NewTextValue;
        CheckFullPath();
    }

    private void OnNameTextCompleted(object sender, EventArgs e)
    {
        m_project_name = ((Entry)sender).Text;
        CheckFullPath();
    }

    private void OnPathTextChanged(object sender, TextChangedEventArgs e)
    {
        m_project_path = e.NewTextValue;
        CheckFullPath();
    }

    private void OnPathCompleted(object sender, EventArgs e)
    {
        m_project_path = ((Entry)sender).Text;
        CheckFullPath();
    }

    private void CreateFolder(object? sender, EventArgs e)
    {
        // Create folder with file
    }
}