using System.ComponentModel.DataAnnotations;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Office_1.DataLayer.Services;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.PixelFormats;
using ZXing;
using ZXing.Common;
using ZXing.QrCode;
using ZXing.Rendering;

namespace Office_1.DataLayer.Models;

public class Request
{
    
    public int Id { get; set; }

    [Required] 
    [Comment("Заявитель")]
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

    public (Image qrImage, string qrString) GetQr(int width, int height, int margin)
    {
        var qrString = ToStringForQr();

        var options = new EncodingOptions
        {
            Height = height, Width = width, Margin = margin,
        };
        
        options.Hints.Add(EncodeHintType.CHARACTER_SET, "utf-8");
        
        var barcodeWriter = new ZXing.ImageSharp.BarcodeWriter<Rgba32> { 
            Format = BarcodeFormat.QR_CODE, 
            Options = options
        };
        
        var image = barcodeWriter.Write(qrString);
        
        return (image, qrString);
    }

    protected string ToStringForQr()
    {
        var dict = ToDictionaryForQr();
        var values = dict.Select(p => PrepareRow(p.Key, p.Value));

        return string.Join(" ", values);
    }

    protected string PrepareRow(string key, string value)
    {
        return PrepareValue(key) + ":" + PrepareValue(value);
    }
    
    protected string PrepareValue(string value)
    {
        return value.Replace(' ', '_');
    }

    protected IDictionary<string, string> ToDictionaryForQr()
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
    
}