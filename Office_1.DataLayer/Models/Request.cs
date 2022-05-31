using System.ComponentModel.DataAnnotations;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Office_1.DataLayer.Services;
using ZXing;
using ZXing.Common;
using ZXing.QrCode;

namespace Office_1.DataLayer.Models;

public class Request
{
    
    public int Id { get; set; }

    [Required] 
    [Comment("Заявитель")] 
    public int ClientId { get; set; }
    
    public Client Client { get; set; }

    [Required]
    [Comment("ФИО руководителя")]
    public string DirectorName { get; set; }
    
    [Required]
    [Comment("Тематика")]
    public string Subject { get; set; }
    
    [Required]
    [Comment("Содержание")]
    public string Content { get; set; }
    
    [Required]
    [Comment("Резолюция")]
    public string Resolution { get; set; }
    
    [Required]
    [Comment("Статус")]
    public Status Status { get; set; }
    
    [Comment("Примечание")]
    public string Remark { get; set; }

    public BitMatrix GetQr(int width, int height)
    {
        var writer = new QRCodeWriter();

        var m = writer.encode(ToStringForQr(), BarcodeFormat.QR_CODE, width, height);
        if (m is null)
        {
            throw new NullReferenceException("BitMatrix is null");
        }

        return m;
    }

    public string ToStringForQr()
    {
        var dict = ToDictionaryForQr();
        var values = dict.Select(p => p.Key + ":" + p.Value);

        return string.Join(" ", values);
    }

    public IDictionary<string, string> ToDictionaryForQr()
    {
        return new Dictionary<string, string>
        {
            ["Идентификатор"] = Id.ToString(),
            ["ФИО заявителя"] = Client.Name,
            ["ФИО руководителя"] = DirectorName,
            ["Адрес"] = Client.Address,
            ["Тематика"] = Subject,
            ["Содержание"] = Content,
            ["Резолюция"] = Resolution,
            ["Статус"] = Status.GetDescription() ?? "Неизвестное имя статуса",
            ["Примечание"] = Remark
        };
    }

    public static Request LoadFromQr(BinaryBitmap bitMap)
    {
        var reader = new QRCodeReader();

        var result = reader.decode(bitMap)!;
        if (result is null)
        {
            throw new NullReferenceException("result is null");
        }

        var text = result.Text;
        if (text is null)
        {
            throw new NullReferenceException("text is null");
        }

        return FromQrString(text);
    }

    protected static Request FromQrString(string data)
    {
        var rows = data.Split(' ');
        var values = new Dictionary<string, string>();

        foreach (var row in rows)
        {
            var rowData = row.Split(':', 2);
            
            var key = rowData[0];
            var value = rowData[1];

            values[key] = value;
        }

        return FromQrDictionary(values);
    }

    protected static Request FromQrDictionary(IDictionary<string, string> dict)
    {
        CheckQrDictionary(dict);

        var id = int.Parse(dict["Идентификатор"]);
        var client = ClientService.GetOrCreateClientByName(dict["ФИО заявителя"], dict["Адрес"]);
        var status = EnumExtension.GetValueFromDescription<Status>(dict["Статус"]);
        
        var request = new Request
        {
            Id = id,
            
            Client = client,
            ClientId = client.Id,

            DirectorName = dict["ФИО руководителя"],
            Subject = dict["Тематика"],
            Content = dict["Содержание"],
            Resolution = dict["Резолюция"],
            Status = status,
            Remark = dict["Примечание"]
        };

        RequestService.InsertRequest(request);
        
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