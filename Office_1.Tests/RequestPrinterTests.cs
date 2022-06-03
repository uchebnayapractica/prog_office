using System.Linq;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using Office_1.DataLayer;
using Office_1.DataLayer.Models;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Formats.Jpeg;
using ZXing;
using ZXing.Common;

namespace Office_1.Tests;

public class RequestPrinterTests
{
    
    [SetUp]
    public void SetUp()
    {
        using var db = new ApplicationContext();

        db.Database.EnsureDeleted();
        db.Database.EnsureCreated();
        db.Database.Migrate();
    }

    [Test]
    public void TestCreation()
    {
        var request = RequestTests.MakeSomeRequest(Status.Created, "Иван", "улица Пушкина");

        var printer = new RequestPrinter(request);
        using var image = printer.Print();
        
        image.SaveAsJpeg("/Users/noliktop/Desktop/office_qr/qr_1.jpeg");
        
        var clientName = string.Concat(Enumerable.Repeat("a", 500));
        request = RequestTests.MakeSomeRequest(Status.Created, "Иван" + clientName, "улица Пушкина");

        printer = new RequestPrinter(request);
        using var image2 = printer.Print();
        
        image2.SaveAsJpeg("/Users/noliktop/Desktop/office_qr/qr_2.jpeg");
    }

    [Test]
    public void TestDecoding()
    {
        
        
        //var source = new RGBLuminanceSource();
        //var binaryBitmap = new BinaryBitmap(new HybridBinarizer(source));
    }
    
}