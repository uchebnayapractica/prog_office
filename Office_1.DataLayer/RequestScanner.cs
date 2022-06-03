using Office_1.DataLayer.Models;
using Office_1.DataLayer.Services;
using ZXing;
using ZXing.QrCode;

namespace Office_1.DataLayer;

public class RequestScanner
{

    protected FileStream Stream;
    
    public RequestScanner(FileStream stream)
    {
        Stream = stream;
    }

    public static Request LoadFromQr(BinaryBitmap bitmap)
    {
        var reader = new QRCodeReader();

        var result = reader.decode(bitmap);
        if (result is null)
        {
            throw new NullReferenceException("result is null");
        }

        var text = result.Text;
        if (text is null)
        {
            throw new NullReferenceException("text is null");
        }

        return LoadFromQrString(text);
    }
    
    public static Request LoadFromQrString(string data)
    {
        var rows = data.Split(' ');
        var values = new Dictionary<string, string>();

        foreach (var row in rows)
        {
            var (key, value) = ParseRow(row); 

            values[key] = value;
        }

        return LoadFromQrDictionary(values);
    }

    protected static (string key, string value) ParseRow(string row)
    {
        var rowData = row.Split(':', 2);
            
        var key = ParseValue(rowData[0]);
        var value = ParseValue(rowData[1]);

        return (key, value);
    }

    protected static string ParseValue(string preparedValue)
    {
        return preparedValue.Replace('_', ' ');
    }

    protected static Request LoadFromQrDictionary(IDictionary<string, string> dict)
    {
        CheckQrDictionary(dict);

        var id = int.Parse(dict["Идентификатор"]);
        var client = ClientService.GetOrCreateClientByNameAndAddress(dict["ФИО заявителя"], dict["Адрес"]);
        var status = EnumExtension.GetValueFromDescription<Status>(dict["Статус"]);
        
        var request = new Request
        {
            Id = id,
            
            DirectorName = dict["ФИО руководителя"],
            Subject = dict["Тематика"],
            Content = dict["Содержание"],
            Resolution = dict["Резолюция"],
            Status = status,
            Remark = dict["Примечание"]
        };

        RequestService.InsertRequest(request, client);
        
        return request;
    }

    protected static void CheckQrDictionary(IDictionary<string, string> dict)
    {
        string[] requiredParams = { "Идентификатор", "ФИО заявителя", "ФИО руководителя", "Адрес", "Тематика", "Содержание", "Резолюция", "Статус", "Примечание" };
        foreach (var param in requiredParams)
        {
            if (!dict.ContainsKey(param))
            {
                throw new ArgumentException($"Отсутствует параметр \"{param}\" в словаре");
            }
        }
    }

}