using System.Security.Cryptography;
using System.Text;

public class ServerSettings
{
    public string AppUser { get; set; }
    public string AppPass { get; set; }
    public string server { get; set; }
    public string Port { get; set; }
    public string Instance { get; set; }
    public string Companyname { get; set; }
    public string user { get; set; }
    public string pass { get; set; }
    public string domain { get; set; }

    public void Getsettings(string path)
    {
        using (StreamReader streamReader = new StreamReader(path))
        {
            this.server = streamReader.ReadLine();
            this.Port = streamReader.ReadLine();
            this.user = streamReader.ReadLine();
            this.pass = streamReader.ReadLine();
            this.domain = streamReader.ReadLine();
            this.Companyname = streamReader.ReadLine();
            this.Instance = streamReader.ReadLine();
            this.AppUser = streamReader.ReadLine();
            this.AppPass = streamReader.ReadLine();
        }
    }
}

   