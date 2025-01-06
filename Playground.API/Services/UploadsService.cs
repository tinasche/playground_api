namespace Playground.API.Services;

public class UploadsService
{
    private List<string> extensions = [".jpg", ".png", ".gif"];
    public string HandleImages(IFormFile file)
    {
        var extension = file.FileName.Substring(file.FileName.LastIndexOf('.'));
        if (!extensions.Contains(extension))
        {
            return "File type not supported";
        }
        var currentFileLocation = Path.GetTempPath();
        return extension;
    }
}